CREATE TABLE [dbo].[Account] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [MobilePhone] VARCHAR (10)   NOT NULL,
    [Password]    VARCHAR (50)   NOT NULL,
    [FullName]    NVARCHAR (100) NOT NULL,
    [Role]        VARCHAR (50)   NOT NULL,
    CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [IX_Account] UNIQUE NONCLUSTERED ([MobilePhone] ASC)
);






GO
CREATE NONCLUSTERED INDEX [IX_Account_1]
    ON [dbo].[Account]([MobilePhone] ASC, [Password] ASC);

