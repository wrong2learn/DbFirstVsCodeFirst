CREATE TABLE [dbo].[ALBUMS]
(
    [Id]                INT IDENTITY(1,1)           NOT NULL,
    [IdBand]            INT                         NOT NULL,
    [Name]              VARCHAR(1000)               NOT NULL,
    CONSTRAINT [PK_ALBUMS] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ALBUMS_BANDS] FOREIGN KEY ([IdBand]) REFERENCES [dbo].[BANDS] ([Id])
)
