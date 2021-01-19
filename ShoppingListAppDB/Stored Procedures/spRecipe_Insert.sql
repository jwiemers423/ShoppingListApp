CREATE PROCEDURE [dbo].[spRecipe_Insert]
	@RecipeName nvarchar(50),
	@RecipeId int
AS
begin
	set nocount on;

	if not exists (select 1 from dbo.Recipe where Id = @RecipeId)
	begin
		insert into dbo.Recipe (RecipeName, Id)
		values (@RecipeName, @RecipeId)
	end
end