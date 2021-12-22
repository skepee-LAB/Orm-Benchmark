CREATE PROCEDURE JsonUpdate(@jsonItem nvarchar(max))
AS
BEGIN

UPDATE portfolio
 SET 
 PortfolioCode = json.PortfolioCode,
 PortfolioName = json.PortfolioName,
 PortfolioType = json.PortfolioType,
 PortfolioStatus = json.PortfolioStatus
 FROM OPENJSON(@jsonItem)
 WITH (
 	 PortfolioId int,
	 PortfolioCode nvarchar(100), 
	 PortfolioName nvarchar(100), 
	 PortfolioType nvarchar(100), 
	 PortfolioStatus nvarchar(100))
 AS json
 WHERE Portfolio.PortfolioId = json.PortfolioId 
END