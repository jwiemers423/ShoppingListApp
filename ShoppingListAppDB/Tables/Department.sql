CREATE TABLE [dbo].[Department] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [DepartmentName] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);