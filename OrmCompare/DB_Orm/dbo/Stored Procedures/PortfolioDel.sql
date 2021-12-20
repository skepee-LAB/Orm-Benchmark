
create PROCEDURE [dbo].[PortfolioDel]
	@portfolioId int
AS
BEGIN

delete 
	from portfolio
where 	
	portfolioId = @portfolioId

END