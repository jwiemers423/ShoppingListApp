CREATE PROCEDURE [dbo].[spGet_Recipes]
AS
begin
	set nocount on;
	select [RecipeName]
	from dbo.Recipe
end
