CREATE TABLE [dbo].[圖片]
(
    [Id]          [int] IDENTITY (1,1) NOT NULL,
    [上傳用戶_FK] [int]                NULL,
    [路徑]        [nvarchar](max)      NOT NULL,
    CONSTRAINT [PK_圖片] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_圖片_用戶] FOREIGN KEY ([上傳用戶_FK]) REFERENCES [dbo].[用戶] ([Id]),
)