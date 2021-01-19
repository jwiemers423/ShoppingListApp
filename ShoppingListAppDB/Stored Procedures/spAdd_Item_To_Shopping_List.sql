CREATE PROCEDURE [dbo].[spAdd_Item_To_Shopping_List]
	@itemId int

AS
begin
	set nocount on;
	
	if not exists (select 1 from dbo.ShoppingList where ItemId = @itemId)
	begin
		insert into dbo.ShoppingList (ItemId)
		values (@itemId)
	end
end