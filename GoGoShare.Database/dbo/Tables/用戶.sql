CREATE TABLE [dbo].[用戶](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[帳號] [nvarchar](50) NOT NULL,
	[密碼] [nvarchar](50) NOT NULL,
	[名字] [nvarchar](50) NOT NULL,
	[手機] [nvarchar](50) NOT NULL,
	[註冊日期] [nvarchar](50) NOT NULL,
	[大頭貼] [nvarchar](max) NOT NULL,
	[點數] [int] NOT NULL,
 CONSTRAINT [PK_用戶] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]