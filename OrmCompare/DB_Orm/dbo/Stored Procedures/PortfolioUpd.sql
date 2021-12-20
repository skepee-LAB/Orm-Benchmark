create PROCEDURE [dbo].[PortfolioUpd]
	@portfolioId int,
	@portfolioCode varchar(100),
	@portfolioName varchar(100),
	@portfolioType varchar(100),
	@portfolioStatus varchar(100)
AS
BEGIN

update portfolio
set	
	portfolioCode=@portfolioCode, 
	portfolioName=@portfolioName, 
	portfolioType=@portfolioType, 
	portfolioStatus=@portfolioStatus
where 	
	portfolioId = @portfolioId

END