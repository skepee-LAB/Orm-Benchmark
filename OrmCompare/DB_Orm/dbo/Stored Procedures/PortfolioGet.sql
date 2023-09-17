/****** Object:  StoredProcedure [dbo].[PortfolioList]    Script Date: 17/09/2023 19:53:17 ******/
CREATE PROCEDURE [dbo].[PortfolioGet]
	@portfolioId int
AS
BEGIN

    SELECT portfolioId, portfolioCode, portfolioName, portfolioType, portfolioStatus 
	FROM portfolio
	where portfolioId=@portfolioId

END