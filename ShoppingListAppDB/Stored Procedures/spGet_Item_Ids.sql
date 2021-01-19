CREATE PROCEDURE [dbo].[spGet_Item_Ids]
	@itemName nvarchar (50)
	
AS
begin
	set nocount on;

	select Id from dbo.Item 
	where ItemName = @itemName
end