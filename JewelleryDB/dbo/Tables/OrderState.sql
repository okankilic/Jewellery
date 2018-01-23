CREATE TABLE [dbo].[OrderState] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [OrderId]       INT            NOT NULL,
    [FromAccountId] INT            NOT NULL,
    [ToAccountId]   INT            NOT NULL,
    [OrderState]    VARCHAR (50)   NOT NULL,
    [StartTime]     DATETIME       NOT NULL,
    [EndTime]       DATETIME       NOT NULL,
    [Remarks]       NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_OrderState] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_OrderState_FromAccount] FOREIGN KEY ([FromAccountId]) REFERENCES [dbo].[Account] ([Id]),
    CONSTRAINT [FK_OrderState_Order] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([Id]),
    CONSTRAINT [FK_OrderState_ToAccount] FOREIGN KEY ([ToAccountId]) REFERENCES [dbo].[Account] ([Id])
);

