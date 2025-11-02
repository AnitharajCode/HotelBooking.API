
CREATE TABLE [dbo].[RoomTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,	
	[HotelId] [int] NOT NULL,
	[RoomType] [nvarchar](15) NOT NULL,
	[Capacity] [int] NOT NULL,
	[PricePerNight] [decimal](18,0) not null
) ON [PRIMARY]
