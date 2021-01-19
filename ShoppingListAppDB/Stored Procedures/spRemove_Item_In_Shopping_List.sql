CREATE PROCEDURE [dbo].[spRemove_Item_In_Shopping_List]
	@itemId int
AS

begin
	set nocount on;
	delete
	from dbo.ShoppingList
	where ItemId = @itemId
end
