CREATE PROCEDURE [dbo].[spUpdate_Item]
	@itemName nvarchar(50),
	@quantity int,
	@quantityMeasurementType nvarchar(50),
	@departmentId nvarchar(50),
	@isChecked bit
As

begin
	set nocount on;
	
	update dbo.Item
	set ItemName = @itemName, Quantity = @quantity, QuantityMeasurementType = @quantityMeasurementType, DepartmentId = @departmentId
	where ItemName = @itemName

end