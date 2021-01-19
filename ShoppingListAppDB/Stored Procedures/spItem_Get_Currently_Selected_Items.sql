CREATE PROCEDURE [dbo].[spItem_Get_Currently_Selected_Items]
	@departmentId int
AS
begin
	set nocount on;

	select *
	from dbo.Item d
	where d.DepartmentId = @departmentId and d.Id in ( select ItemId from dbo.ShoppingList )

end