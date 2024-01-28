CREATE TABLE [dbo].[文章Hashtag]
(
    [文章_FK]    [int] NOT NULL,
    [Hashtag_FK] [int] NOT NULL,
    CONSTRAINT [PK_文章Hashtag] PRIMARY KEY CLUSTERED ([文章_FK] ASC, [Hashtag_FK] ASC),
    CONSTRAINT [FK_文章Hashtag_文章] FOREIGN KEY ([文章_FK]) REFERENCES [dbo].[文章] ([Id]),
    CONSTRAINT [FK_文章Hashtag_Hashtag] FOREIGN KEY ([Hashtag_FK]) REFERENCES [dbo].[Hashtag] ([Id]),
)