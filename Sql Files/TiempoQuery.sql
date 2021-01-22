CREATE DATABASE ExerciseTiempo

use ExerciseTiempo

CREATE TABLE Customer (
    Id int NOT NULL IDENTITY     PRIMARY KEY,
    FirstName VARCHAR(100)  NOT NULL,
    LastName VARCHAR(100)  NOT NULL,
	DateOfBirth  datetime NOT NULL,
	IsEnabled   BIT
);

INSERT INTO Customer (FirstName, LastName, DateOfBirth,IsEnabled)
VALUES ('Marco', 'Perez',GETDATE() ,1);

select * from Customer

CREATE PROCEDURE Get_All_Customers
AS
Select * from Customer
GO;

EXEC Get_All_Customers
