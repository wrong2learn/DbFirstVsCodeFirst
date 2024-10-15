CREATE TABLE [dbo].[SONGS]
(
    [Id]                INT IDENTITY(1,1)           NOT NULL,
    [IdAlbum]           INT                         NOT NULL,
    [Name]              VARCHAR(1000)               NOT NULL,
    CONSTRAINT [PK_SONGS] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SONGS_ALBUMS] FOREIGN KEY ([IdAlbum]) REFERENCES [dbo].[ALBUMS] ([Id])
)
