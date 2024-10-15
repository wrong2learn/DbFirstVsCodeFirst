CREATE TABLE [dbo].[ARTISTS]
(
    [Id]                INT IDENTITY(1,1)           NOT NULL,
    [FirstName]         VARCHAR(1000)               NOT NULL,
    [LastName]          VARCHAR(1000)               NOT NULL,
    [BirthDate]         DATETIME2                   NOT NULL,
    CONSTRAINT [PK_ARTISTS] PRIMARY KEY CLUSTERED ([Id] ASC)
)
