﻿CREATE TABLE [dbo].[旅程包](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[標題] [nvarchar](50) NOT NULL,
	[描述] [nvarchar](max) NOT NULL,
	[作者用戶_FK] [int] NULL,
 CONSTRAINT [PK_旅程包] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]