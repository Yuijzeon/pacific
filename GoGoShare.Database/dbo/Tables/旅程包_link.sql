﻿CREATE TABLE [dbo].[旅程包_link](
	[旅程包_FK] [int] NOT NULL,
	[文章_FK] [int] NOT NULL,
	[索引] [int] NOT NULL,
 CONSTRAINT [PK_旅程包_link_1] PRIMARY KEY CLUSTERED 
(
	[旅程包_FK] ASC,
	[索引] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]