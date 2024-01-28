CREATE TABLE [dbo].[文章]
(
    [Id]           [int] IDENTITY (1,1) NOT NULL,
    [標題]         [nvarchar](50)       NOT NULL,
    [作者用戶_FK]  [int]                NULL,
    [內容]         [nvarchar](max)      NOT NULL,
    [日期起始]     [datetime]           NOT NULL,
    [日期結束]     [datetime]           NOT NULL,
    [圖片_FK]      [int]                NULL,
    [地點]         [nvarchar](max)      NOT NULL,
    [接待人數]     [int]                NOT NULL,
    [類型]         [nvarchar](50)       NULL,
    [點數]         [int]                NOT NULL DEFAULT ((0)),
    [文章註冊時間] [smalldatetime]      NULL,
    CONSTRAINT [PK_文章] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_文章_圖片] FOREIGN KEY ([圖片_FK]) REFERENCES [dbo].[圖片] ([Id]),
    CONSTRAINT [FK_文章_用戶] FOREIGN KEY ([作者用戶_FK]) REFERENCES [dbo].[用戶] ([Id])
)