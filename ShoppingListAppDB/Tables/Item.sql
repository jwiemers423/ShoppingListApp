CREATE TABLE [dbo].[Item] (
    [Id]                      INT           IDENTITY (1, 1) NOT NULL,
    [ItemName]                NVARCHAR (50) NOT NULL,
    [Quantity]                INT           NOT NULL,
    [QuantityMeasurementType] NVARCHAR (50) NOT NULL,
    [DepartmentId]            INT           NOT NULL

    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([QuantityMeasurementType]='Units' OR [QuantityMeasurementType]='Teaspoon' OR [QuantityMeasurementType]='Tablespoon' OR [QuantityMeasurementType]='FluidOunces' OR [QuantityMeasurementType]='Cups' OR [QuantityMeasurementType]='Pints' OR [QuantityMeasurementType]='Quarts' OR [QuantityMeasurementType]='Gallon' OR [QuantityMeasurementType]='Ounces' OR [QuantityMeasurementType]='Pounds')
);
