CREATE TABLE [dbo].[Order] (
    [Id]                   INT            IDENTITY (1, 1) NOT NULL,
    [ProductId]            INT            NOT NULL,
    [AccountId]            INT            NOT NULL,
    [Price]                MONEY          NOT NULL,
    [Quantity]             INT            NOT NULL,
    [OrderTime]            DATETIME       NOT NULL,
    [ResponsibleAccountId] INT            NULL,
    [OrderState]           VARCHAR (20)   NOT NULL,
    [Remarks]              NVARCHAR (200) NULL,
    [UpdateTime]           DATETIME       NOT NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Order_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([Id]),
    CONSTRAINT [FK_Order_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id]),
    CONSTRAINT [FK_Order_ResponsibleAccount] FOREIGN KEY ([ResponsibleAccountId]) REFERENCES [dbo].[Account] ([Id])
);







