CREATE TABLE [dbo].[文章](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[標題] [nvarchar](50) NOT NULL,
	[作者用戶_FK] [int] NULL,
	[內容] [nvarchar](max) NOT NULL,
	[日期起始] [datetime] NOT NULL,
	[日期結束] [datetime] NOT NULL,
	[圖片_FK] [int] NULL,
	[地點] [nvarchar](max) NOT NULL,
	[接待人數] [int] NOT NULL,
	[類型] [nvarchar](50) NULL,
	[點數] [int] NOT NULL,
	[文章註冊時間] [smalldatetime] NULL,
 CONSTRAINT [PK_文章] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]