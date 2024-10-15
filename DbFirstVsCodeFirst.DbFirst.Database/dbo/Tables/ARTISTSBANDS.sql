CREATE TABLE [dbo].[ARTISTSBANDS]
(
	[Id]                INT IDENTITY(1,1)           NOT NULL,
    [IdArtist]          INT                         NOT NULL,
    [IdBand]            INT                         NOT NULL,
    CONSTRAINT [PK_ARTISTSBANDS] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ARTISTSBANDS_ARTISTS] FOREIGN KEY ([IdArtist]) REFERENCES [dbo].[ARTISTS] ([Id]),
    CONSTRAINT [FK_ARTISTSBANDS_BANDS] FOREIGN KEY ([IdBand]) REFERENCES [dbo].[BANDS] ([Id])
)
