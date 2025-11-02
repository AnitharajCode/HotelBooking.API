USE [Hotel]
GO

/****** Object:  Table [dbo].[Hotel]    Script Date: 01/11/2025 13:33:30 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Hotels]') AND type in (N'U'))
DROP TABLE [dbo].[Hotels]
GO

/****** Object:  Table [dbo].[Hotel]    Script Date: 01/11/2025 13:33:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Hotels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,

	
	
) ON [PRIMARY]
GO


