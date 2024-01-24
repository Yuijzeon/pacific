﻿CREATE TABLE [dbo].[Hashtag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[名稱] [nvarchar](50) NOT NULL,
	[類別] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Hashtag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]