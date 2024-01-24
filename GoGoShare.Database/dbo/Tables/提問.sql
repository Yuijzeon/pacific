CREATE TABLE [dbo].[提問]
(
    [Id]          [int] IDENTITY (1,1) NOT NULL,
    [問題]        [nvarchar](max)      NOT NULL,
    [回答]        [nvarchar](max)      NOT NULL,
    [提問用戶_FK] [int]                NULL,
    CONSTRAINT [PK_提問] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_提問_用戶] FOREIGN KEY ([提問用戶_FK]) REFERENCES [dbo].[用戶] ([Id]),
)