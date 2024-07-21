CREATE PROCEDURE dbo.CustomersListWithPagination
(
	@PageNumber int,
	@PageSize int
)
AS
BEGIN
	SELECT CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax
	FROM Customers 
	order by CustomerId
	OFFSET (@PageNumber-1)*@PageSize Rows
	Fetch Next @PageSize Rows Only
END
