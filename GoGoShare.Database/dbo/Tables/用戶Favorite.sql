CREATE TABLE [dbo].[用戶Favorite]
(
    [收藏文章_FK] [int] NOT NULL,
    [用戶_FK]     [int] NOT NULL,
    CONSTRAINT [PK_用戶Favorite] PRIMARY KEY CLUSTERED ([收藏文章_FK] ASC, [用戶_FK] ASC),
    CONSTRAINT [FK_用戶Favorite_用戶] FOREIGN KEY ([用戶_FK]) REFERENCES [dbo].[用戶] ([Id]),
    CONSTRAINT [FK_用戶Favorite_文章] FOREIGN KEY ([收藏文章_FK]) REFERENCES [dbo].[文章] ([Id]),
)