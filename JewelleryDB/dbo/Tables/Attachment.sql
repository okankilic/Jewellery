CREATE TABLE [dbo].[Attachment] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [ProductId]  INT           NOT NULL,
    [FilePath]   VARCHAR (255) NOT NULL,
    [CreateTime] DATETIME      CONSTRAINT [DF_Attachment_CreateTime] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_Attachment] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Attachment_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id])
);

