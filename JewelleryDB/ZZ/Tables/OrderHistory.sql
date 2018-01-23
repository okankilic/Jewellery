CREATE TABLE [ZZ].[OrderHistory] (
    [HID]                  INT            IDENTITY (1, 1) NOT NULL,
    [OrderId]              INT            NOT NULL,
    [ProductId]            INT            NOT NULL,
    [AccountId]            INT            NOT NULL,
    [Price]                MONEY          NOT NULL,
    [Quantity]             INT            NOT NULL,
    [ResponsibleAccountId] INT            NULL,
    [OrderState]           VARCHAR (20)   NOT NULL,
    [Remarks]              NVARCHAR (200) NULL,
    [UpdateTime]           DATETIME       NOT NULL,
    CONSTRAINT [PK_OrderHistory] PRIMARY KEY CLUSTERED ([HID] ASC),
    CONSTRAINT [FK_OrderHistory_Order] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([Id])
);



