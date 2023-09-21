CREATE PROCEDURE [dbo].[PortfolioIns]
	@portfolioId int,
	@portfolioCode varchar(100),
	@portfolioName varchar(100),
	@portfolioType varchar(100),
	@portfolioStatus varchar(100)
AS
BEGIN

insert into portfolio(
	portfolioId,
	portfolioCode, 
	portfolioName, 
	portfolioType, 
	portfolioStatus
)
values(
	@portfolioId,
	@portfolioCode, 
	@portfolioName, 
	@portfolioType, 
	@portfolioStatus
)

END