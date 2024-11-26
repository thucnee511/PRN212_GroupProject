-- Create a new database called 'TheCoffeeStore'
-- Connect to the 'master' database to run this snippet
USE master
GO
-- Create the new database if it does not exist already
IF NOT EXISTS (
    SELECT [name]
        FROM sys.databases
        WHERE [name] = N'TheCoffeeStore'
)
CREATE DATABASE TheCoffeeStore
GO  

USE TheCoffeeStore

-- Create a new table called '[accounts]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[accounts]', 'U') IS NOT NULL
DROP TABLE [dbo].[accounts]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[accounts]
(
    [Id] VARCHAR(255) NOT NULL PRIMARY KEY , -- Primary Key column
    [Username] NVARCHAR(50) NOT NULL UNIQUE,
    [Password] VARCHAR(255) NOT NULL,
    [Role] INT NOT NULL,
    [Status] VARCHAR(10) DEFAULT ('ACTIVE'),
    [CreatedAt] DATETIME DEFAULT (GETDATE()),
    [UpdatedAt] DATETIME DEFAULT (GETDATE()),
);
GO

-- Create a new table called '[employees]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[employees]', 'U') IS NOT NULL
DROP TABLE [dbo].[employees]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[employees]
(
    [Id] VARCHAR(255) NOT NULL PRIMARY KEY, -- Primary Key column
    [FirstName] NVARCHAR(50) NOT NULL,
    [MiddleName] NVARCHAR(50) NULL,
    [LastName] NVARCHAR(50) NOT NULL,
    [Email] VARCHAR(50) NOT NULL,
    [PhoneNumber] VARCHAR(20) NOT NULL,
    [BaseSalary] INT NOT NULL,
    [CreatedAt] DATETIME DEFAULT (GETDATE()),
    [UpdatedAt] DATETIME DEFAULT (GETDATE()),
    [Status] VARCHAR(10) DEFAULT ('ACTIVED')
);
GO

-- Create a new table called '[duties]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[duties]', 'U') IS NOT NULL
DROP TABLE [dbo].[duties]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[duties]
(
    [Id] VARCHAR(255) NOT NULL PRIMARY KEY, -- Primary Key column
    [EmployeeId] VARCHAR(255) NOT NULL,
    [StartTime] DATETIME NOT NULL,
    [EndTime] DATETIME NULL,
    [SalaryRate] FLOAT DEFAULT (1.0),
    [CreatedAt] DATETIME DEFAULT(GETDATE()),
    [UpdatedAt] DATETIME DEFAULT(GETDATE()),
    [Status] VARCHAR(10) DEFAULT('WORKING')
);
GO

-- Add constraint to table '[categories]' in schema '[dbo]'
ALTER TABLE [dbo].[duties]
    ADD CONSTRAINT FK_Duties_Employees
        FOREIGN KEY ([EmployeeId]) 
        REFERENCES [dbo].[employees]([Id])


-- Create a new table called '[categories]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[categories]', 'U') IS NOT NULL
DROP TABLE [dbo].[categories]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[categories]
(
    [Id] VARCHAR(255) NOT NULL PRIMARY KEY, -- Primary Key column
    [Name] NVARCHAR(50) NOT NULL,
    [CreatedAt] DATETIME DEFAULT (GETDATE()),
    [UpdatedAt] DATETIME DEFAULT (GETDATE()),
    [Status] VARCHAR(10) DEFAULT ('ACTIVED'),
);
GO

-- Create a new table called '[items]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[items]', 'U') IS NOT NULL
DROP TABLE [dbo].[items]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[items]
(
    [Id] VARCHAR(255) NOT NULL PRIMARY KEY, -- Primary Key column
    [CategoryId] VARCHAR(255),
    [Name] NVARCHAR(100) NOT NULL,
    [Price] INT NOT NULL,
    [CreatedAt] DATETIME DEFAULT(GETDATE()),
    [UpdatedAt] DATETIME DEFAULT(GETDATE()),
    [Status] VARCHAR(10) DEFAULT('ACTIVED'),
);
GO

-- Add constraint to table '[items]' in schema '[dbo]'
ALTER TABLE [dbo].[items]
    ADD CONSTRAINT FK_Items_Categories
        FOREIGN KEY ([CategoryId])
        REFERENCES [dbo].[categories]([Id])

-- Create a new table called '[vouchers]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[vouchers]', 'U') IS NOT NULL
DROP TABLE [dbo].[vouchers]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[vouchers]
(
    [Id] VARCHAR(255) NOT NULL PRIMARY KEY, -- Primary Key column
    [Name] NVARCHAR(50) NOT NULL,
    [Discount] INT DEFAULT(0),
    [Quantity] INT DEFAULT(1),
    [CreatedAt] DATETIME DEFAULT(GETDATE()),
    [UpdatedAt] DATETIME DEFAULT(GETDATE()),
    [Status] VARCHAR(10) DEFAULT('VALID')
);
GO

-- Create a new table called '[orders]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[orders]', 'U') IS NOT NULL
DROP TABLE [dbo].[orders]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[orders]
(
    [Id] VARCHAR(255) NOT NULL PRIMARY KEY, -- Primary Key column
    [TotalPrice] INT NOT NULL,
    [PaymentMethod] VARCHAR(10) DEFAULT('CASH'),
    [VoucherId] VARCHAR(255) NULL,
    [CreatedAt] DATETIME DEFAULT(GETDATE()), 
    [UpdatedAt] DATETIME DEFAULT(GETDATE()), 
    [Status] VARCHAR(10) DEFAULT('PENDING')
);
GO

-- Add constraint to table '[orders]' in schema '[dbo]'
ALTER TABLE [dbo].[orders]
    ADD CONSTRAINT FK_Orders_Vouchers
        FOREIGN KEY ([VoucherId])
        REFERENCES [dbo].[vouchers]([Id])

-- Create a new table called '[order_details]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[order_details]', 'U') IS NOT NULL
DROP TABLE [dbo].[order_details]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[order_details]
(
    [Id] VARCHAR(255) NOT NULL PRIMARY KEY, -- Primary Key column
    [OrderId] VARCHAR(255) NOT NULL,
    [ItemId] VARCHAR(255) NOT NULL,
    [Price] INT NOT NULL,
    [Quantity] INT NOT NULL,
);
GO

-- Add constraint to table '[order_details]' in schema '[dbo]'
ALTER TABLE [dbo].[order_details]
    ADD CONSTRAINT FK_OrderDetails_Orders
        FOREIGN KEY ([OrderId])
        REFERENCES [dbo].[orders]([Id])

ALTER TABLE [dbo].[order_details]
    ADD CONSTRAINT FK_OrderDetails_Items
        FOREIGN KEY ([ItemId])
        REFERENCES [dbo].[items]([Id])