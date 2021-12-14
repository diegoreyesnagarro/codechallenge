using Cox.CodeChallenge.Domain.Command;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Cox.CodeCallenge.Vehcile.Service
{
    public class CsvFileReaderService : ICsvFileReaderService
    {
        static readonly Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)", RegexOptions.Compiled);

        public List<VehicleDealCommand> ImportData(Stream input)
        {
            var returnList = new List<VehicleDealCommand>();
            input.Position = 0;
            var dataStr = new StreamReader(input).ReadToEnd();

            var allRecords = dataStr.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)
                    .Skip(1)
                    .ToList();

            foreach (var record in allRecords)
            {
                if (string.IsNullOrEmpty(record))
                    continue;
                try
                {
                    var rec = CSVParser.Split(record);
                    var newRec = new VehicleDealCommand
                    {
                        DealNumber = Convert.ToInt32(rec[0]),
                        CustomerName = rec[1]?.ToString(),
                        DealershipName = rec[2]?.ToString(),
                        Vehicle = rec[3]?.ToString(),
                        Price = Convert.ToDecimal(rec[4]?.Replace("\"", "")?.ToString()),
                        Date = DateTime.ParseExact(rec[5], "M/d/yyyy", CultureInfo.InvariantCulture)
                };
                    returnList.Add(newRec);
                }
                catch (Exception)
                {
                    //TODO: Manage record exception.
                }


            }

            return returnList;
        }

    }
}
