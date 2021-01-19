/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

begin
    insert into dbo.Item(ItemName, Quantity, QuantityMeasurementType, DepartmentId)
    values ('Chicken', '3', 'Pounds', '8'),
    ('Kidney Beans', '14', 'Ounces', '6'),
    ('Lettuce', '1', 'Units', '1'),
    ('Broth', '20', 'Ounces', '6');
end

if not exists (select 1 from dbo.Department)
begin
    insert into dbo.Department(DepartmentName)
    values ('Produce'),
           ('Paper Goods'),
           ('Pasta and Condiments'),
           ('Dairy'),
           ('Deli And Bread'),
           ('Dry Goods and Canned Items'),
           ('Frozen'),
           ('Meat and Seafood'),
           ('Pet'),
           ('Other');
end

if not exists (select 1 from dbo.Recipe)
begin
    declare @itemId1 int;
    declare @itemId2 int;
    declare @itemId3 int;
    declare @itemId4 int;

    select @itemId1 = Id from dbo.Item where ItemName = 'Chicken'
    select @itemId2 = Id from dbo.Item where ItemName = 'Kidney Beans'
    select @itemId3 = Id from dbo.Item where ItemName = 'Lettuce'
    select @itemId4 = Id from dbo.Item where ItemName = 'Broth'

    insert into dbo.Recipe (RecipeName, ItemId)
    values ('Test Soup', @itemId1),
    ('Test Soup', @itemId2),
    ('Test Soup', @itemId3),
    ('Test Soup', @itemId4);

end

begin
    insert into dbo.ShoppingList(ItemId)
    values ('1'), ('2'), ('3'), ('4');
end

