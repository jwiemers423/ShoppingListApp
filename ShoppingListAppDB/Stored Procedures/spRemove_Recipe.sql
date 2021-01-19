CREATE PROCEDURE [dbo].[spRemove_Recipe]
	@RecipeName nvarchar(50)
AS
begin
	set nocount on;
	delete 
	from dbo.Recipe
	where RecipeName = @RecipeName
end