USE [Vehicles]
GO

/****** Object:  Table [dbo].[VehicleDeals]    Script Date: 12/14/2021 5:46:28 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VehicleDeals](
	[VehicleDealId] [int] IDENTITY(1,1) NOT NULL,
	[DealNumber] [int] NULL,
	[CustomerName] [nvarchar](300) NULL,
	[DealershipName] [nvarchar](400) NULL,
	[Vehicle] [nvarchar](400) NULL,
	[Price] [decimal](18, 2) NULL,
	[Date] [date] NULL
) ON [PRIMARY]
GO