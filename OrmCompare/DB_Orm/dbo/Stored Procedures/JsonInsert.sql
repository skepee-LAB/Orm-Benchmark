CREATE PROCEDURE [dbo].[JsonInsert](
	@jsonItem nvarchar(max))
AS
BEGIN

INSERT INTO [dbo].[portfolio] (portfolioId, portfolioCode, portfolioName, portfolioType, portfolioStatus)
SELECT portfolioId, portfolioCode, portfolioName, portfolioType, portfolioStatus
FROM OPENJSON(@jsonItem)
     WITH (
	 PortfolioId int '$.PortfolioId', 
	 PortfolioCode nvarchar(100) '$.PortfolioCode', 
	 PortfolioName nvarchar(100) '$.PortfolioName', 
	 PortfolioType nvarchar(100) '$.PortfolioType', 
	 PortfolioStatus nvarchar(100) '$.PortfolioStatus')

END