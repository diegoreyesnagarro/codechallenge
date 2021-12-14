using Cox.CodeChallenge.Domain.Command;
using System.Collections.Generic;
using System.IO;

namespace Cox.CodeCallenge.Vehcile.Service
{
    public interface ICsvFileReaderService
    {
        List<VehicleDealCommand> ImportData(Stream input);
    }
}