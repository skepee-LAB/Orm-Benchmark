CREATE PROCEDURE [dbo].[PortfolioIns]
	@portfolioCode varchar(100),
	@portfolioName varchar(100),
	@portfolioType varchar(100),
	@portfolioStatus varchar(100)
AS
BEGIN

insert into portfolio(
	portfolioCode, 
	portfolioName, 
	portfolioType, 
	portfolioStatus
)
values(
	@portfolioCode, 
	@portfolioName, 
	@portfolioType, 
	@portfolioStatus
)

END