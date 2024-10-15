CREATE TABLE [dbo].[BANDS]
(
    [Id]                INT IDENTITY(1,1)           NOT NULL,
    [IdGenre]           INT                         NOT NULL,
    [Name]              VARCHAR(1000)               NOT NULL,
    CONSTRAINT [PK_BANDS] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BANDS_GENRE] FOREIGN KEY ([IdGenre]) REFERENCES [Lookup].[GENRES] ([Id])
)
