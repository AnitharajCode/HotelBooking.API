USE [Hotel]
GO

/****** Object:  Table [dbo].[Booking]    Script Date: 01/11/2025 13:35:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
drop table [dbo].[Bookings]
CREATE TABLE [dbo].[Bookings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomId] [int] NOT NULL,
	[Reference]  [nvarchar](70) NOT NULL,	
	[CheckInDate] [date] NOT NULL,
	[CheckOutDate] [date] NOT NULL,
	[GuestName] [nvarchar](50) NOT NULL,
	[NumberOfGuests] [int] NOT NULL,
	[TotalPrice] [decimal](18, 0) NOT NULL,
	HotelId [int] NOT NULL
	
	
) ON [PRIMARY]
GO


