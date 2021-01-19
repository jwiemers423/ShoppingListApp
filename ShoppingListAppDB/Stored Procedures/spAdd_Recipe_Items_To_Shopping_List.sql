CREATE PROCEDURE [dbo].[spAdd_Recipe_Items_To_Shopping_List]
	@recipeName nvarchar(50),
	@itemId nvarchar(50)
AS
begin
	set nocount on;
	
	if not exists (select 1 from dbo.ShoppingList where ItemId = @itemId)
	begin
		insert into dbo.ShoppingList (ItemId)
		select ItemId
		from dbo.Recipe
		where (@recipeName = RecipeName)
		group by ItemId

	end
end