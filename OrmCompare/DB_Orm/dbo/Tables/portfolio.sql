CREATE TABLE [dbo].[portfolio] (
    [PortfolioId]     INT            IDENTITY (1, 1) NOT NULL,
    [PortfolioCode]   NVARCHAR (100) NOT NULL,
    [PortfolioName]   NVARCHAR (100) NOT NULL,
    [PortfolioType]   NVARCHAR (100) NOT NULL,
    [PortfolioStatus] NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([PortfolioId] ASC)
);



