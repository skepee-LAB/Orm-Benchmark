CREATE PROCEDURE [dbo].[JsonList]
AS
BEGIN

SELECT portfolioId, portfolioCode, portfolioName, portfolioType, portfolioStatus 
FROM portfolio 
FOR JSON PATH

END