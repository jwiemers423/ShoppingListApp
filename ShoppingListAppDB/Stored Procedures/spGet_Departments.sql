CREATE PROCEDURE [dbo].[spGet_Departments]
AS
begin
	set nocount on;
	select [Id], [DepartmentName]
	from dbo.Department
end
