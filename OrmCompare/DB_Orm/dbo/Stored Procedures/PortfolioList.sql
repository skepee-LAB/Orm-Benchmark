CREATE PROCEDURE PortfolioList
AS
BEGIN

    SELECT portfolioId, portfolioCode, portfolioName, portfolioType, portfolioStatus 
	FROM portfolio

END