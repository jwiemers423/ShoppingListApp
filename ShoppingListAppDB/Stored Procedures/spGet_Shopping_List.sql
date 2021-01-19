CREATE PROCEDURE [dbo].[spGet_Shopping_List]
AS
begin
	set nocount on;

	

	SELECT i.*
	FROM dbo.Item i
	INNER JOIN dbo.ShoppingList s
	ON i.Id = s.ItemId


end