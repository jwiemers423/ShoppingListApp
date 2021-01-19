CREATE PROCEDURE [dbo].[spGet_Items_Ids_In_Recipe]
	@recipeName nvarchar(50)
AS
begin
	set nocount on;

	select * from dbo.Item where Id IN
	(select ItemId from dbo.Recipe b where b.RecipeName = @recipeName)
end
