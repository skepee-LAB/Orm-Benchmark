CREATE PROCEDURE [dbo].[JsonInsert](
	@jsonItem nvarchar(max))
AS
BEGIN

INSERT INTO [dbo].[portfolio] (portfolioCode, portfolioName, portfolioType, portfolioStatus)
SELECT portfolioCode, portfolioName, portfolioType, portfolioStatus
FROM OPENJSON(@jsonItem)
     WITH (
	 PortfolioId int,
	 PortfolioCode nvarchar(100) '$.PortfolioCode', 
	 PortfolioName nvarchar(100) '$.PortfolioName', 
	 PortfolioType nvarchar(100) '$.PortfolioType', 
	 PortfolioStatus nvarchar(100) '$.PortfolioStatus')

END