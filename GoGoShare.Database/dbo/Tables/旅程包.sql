CREATE TABLE [dbo].[旅程包]
(
    [Id]          [int] IDENTITY (1,1) NOT NULL,
    [標題]        [nvarchar](50)       NOT NULL,
    [描述]        [nvarchar](max)      NOT NULL,
    [作者用戶_FK] [int]                NULL,
    CONSTRAINT [PK_旅程包] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_旅程包_用戶] FOREIGN KEY ([作者用戶_FK]) REFERENCES [dbo].[用戶] ([Id]),
)