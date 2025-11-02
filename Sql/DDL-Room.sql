USE [Hotel]
GO

/****** Object:  Table [dbo].[Room]    Script Date: 01/11/2025 13:35:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rooms]') AND type in (N'U'))
DROP TABLE [dbo].[Rooms]
GO

/****** Object:  Table [dbo].[Room]    Script Date: 01/11/2025 13:35:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Rooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HotelId] [int] NOT NULL,
		[RoomTypeId] [int] NOT NULL,
	[RoomNumber] [nvarchar](10) NOT NULL,
	[Capacity] [int] NOT NULL,
	[PricePerNight] [decimal](18, 0) NOT NULL
) ON [PRIMARY]
GO


