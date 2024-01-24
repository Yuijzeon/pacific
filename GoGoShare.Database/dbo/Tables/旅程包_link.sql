CREATE TABLE [dbo].[旅程包_link]
(
    [旅程包_FK] [int] NOT NULL,
    [文章_FK]   [int] NOT NULL,
    [索引]      [int] NOT NULL,
    CONSTRAINT [PK_旅程包_link_1] PRIMARY KEY CLUSTERED ([旅程包_FK] ASC, [索引] ASC),
    CONSTRAINT [FK_旅程包_link_文章] FOREIGN KEY ([文章_FK]) REFERENCES [dbo].[文章] ([Id]),
    CONSTRAINT [FK_旅程包_link_旅程包] FOREIGN KEY ([旅程包_FK]) REFERENCES [dbo].[旅程包] ([Id]),
)