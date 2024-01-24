CREATE TABLE [dbo].[用戶]
(
    [Id]       [int] IDENTITY (1,1) NOT NULL,
    [帳號]     [nvarchar](50)       NOT NULL,
    [密碼]     [nvarchar](50)       NOT NULL,
    [名字]     [nvarchar](50)       NOT NULL,
    [手機]     [nvarchar](50)       NOT NULL,
    [註冊日期] [nvarchar](50)       NOT NULL DEFAULT (getdate()),
    [大頭貼]   [nvarchar](max)      NOT NULL DEFAULT (N'初始照片.jpg'),
    [點數]     [int]                NOT NULL DEFAULT ((0)),
    CONSTRAINT [PK_用戶] PRIMARY KEY CLUSTERED ([Id] ASC),
)