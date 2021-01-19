CREATE PROCEDURE [dbo].[spAdd_Items_To_Recipe]
	@RecipeName nvarchar(50),
	@ItemId int
AS
begin
	set nocount on;
	if not exists (select 1 from dbo.Recipe where RecipeName = @RecipeName)
	begin
		insert into dbo.Recipe(RecipeName, ItemId)
		values (@RecipeName, @ItemId);
	end
end