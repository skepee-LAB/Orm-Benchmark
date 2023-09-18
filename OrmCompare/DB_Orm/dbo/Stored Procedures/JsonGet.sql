create PROCEDURE [dbo].[JsonGet]
	@portfolioId int
AS
BEGIN

SELECT portfolioId, portfolioCode, portfolioName, portfolioType, portfolioStatus 
FROM portfolio 
where portfolioId=@portfolioId
FOR JSON PATH

END