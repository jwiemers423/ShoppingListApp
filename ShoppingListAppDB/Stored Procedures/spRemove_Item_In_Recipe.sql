CREATE PROCEDURE [dbo].[spRemove_Item_In_Recipe]
	@itemId int
AS

begin
	set nocount on;
	delete
	from dbo.Recipe
	where ItemId = @itemId
end
