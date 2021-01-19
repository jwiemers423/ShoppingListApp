CREATE PROCEDURE [dbo].[spRemove_Item]
	@itemName nvarchar(50)
AS

begin
	set nocount on;
	delete
	from dbo.Item
	where ItemName = @itemName
end
