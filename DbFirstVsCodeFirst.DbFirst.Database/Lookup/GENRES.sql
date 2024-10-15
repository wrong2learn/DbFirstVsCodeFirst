CREATE TABLE [Lookup].[GENRES]
(
	[Id]                INT                         NOT NULL,
    [Name]              VARCHAR(1000)               NOT NULL,
    CONSTRAINT [PK_GENRES] PRIMARY KEY CLUSTERED ([Id] ASC),
)
