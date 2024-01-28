CREATE TABLE [dbo].[用戶Hashtag]
(
    [用戶_FK]    [int] NOT NULL,
    [Hashtag_FK] [int] NOT NULL,
    CONSTRAINT [PK_用戶Hashtag] PRIMARY KEY CLUSTERED ([用戶_FK] ASC, [Hashtag_FK] ASC),
    CONSTRAINT [FK_用戶Hashtag_用戶] FOREIGN KEY ([用戶_FK]) REFERENCES [dbo].[用戶] ([Id]),
    CONSTRAINT [FK_用戶Hashtag_Hashtag] FOREIGN KEY ([Hashtag_FK]) REFERENCES [dbo].[Hashtag] ([Id]),
)