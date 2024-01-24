CREATE TABLE [dbo].[評級]
(
    [Id]          [int] IDENTITY (1,1) NOT NULL,
    [分數]        [int]                NOT NULL,
    [評分用戶_FK] [int]                NULL,
    [文章_FK]     [int]                NULL,
    [評論]        [nvarchar](max)      NOT NULL DEFAULT (''),
    CONSTRAINT [PK_評級] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_評級_文章] FOREIGN KEY ([文章_FK]) REFERENCES [dbo].[文章] ([Id]),
    CONSTRAINT [FK_評級_用戶] FOREIGN KEY ([評分用戶_FK]) REFERENCES [dbo].[用戶] ([Id]),
)