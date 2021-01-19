CREATE PROCEDURE [dbo].[spItems_Insert]
	@ItemName nvarchar(50),
	@Quantity int,
	@QuantityMeasurementType nvarchar(50),
	@DepartmentId int
AS
begin
	set nocount on;

	if not exists (select 1 from dbo.Item where ItemName = @ItemName)
	begin
		insert into dbo.Item (ItemName, Quantity, QuantityMeasurementType, DepartmentId)
		values (@ItemName, @Quantity, @QuantityMeasurementType, @DepartmentId);
	end
end