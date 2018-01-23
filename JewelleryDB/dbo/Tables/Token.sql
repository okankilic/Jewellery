CREATE TABLE [dbo].[Token] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [AccountId]   INT          NOT NULL,
    [TokenString] VARCHAR (50) NOT NULL,
    [StartTime]   DATETIME     NOT NULL,
    [EndTime]     DATETIME     NOT NULL,
    CONSTRAINT [PK_Token] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Token_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([Id])
);

