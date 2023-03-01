/* Create database named AZBank */
USE master;
GO
CREATE DATABASE AZBank
ON
( NAME = AZBank_dat,
	FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL15.NGHIA\MSSQL\DATA\azbankdat.mdf',
	SIZE = 10,
	MAXSIZE = 50,
	FILEGROWTH = 5 )
LOG ON
( NAME = AZBank_log,
	FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL15.NGHIA\MSSQL\DATA\azbanklog.ldf',
	SIZE = 5,
	MAXSIZE = 25,
	FILEGROWTH = 5 );
GO

/* Create tables */
USE AZBank;
GO
CREATE TABLE Customer(
	CustomerId INT PRIMARY KEY,
	[Name] NVARCHAR(50),
	City NVARCHAR(50),
	Country NVARCHAR(50),
	Phone NVARCHAR(15),
	Email NVARCHAR(50)
);
GO
CREATE TABLE CustomerAccount(
	AccountNumber CHAR(9) PRIMARY KEY,
	CustomerId INT NOT NULL FOREIGN KEY REFERENCES Customer(CustomerId),
	Balance MONEY NOT NULL,
	MinAccount MONEY
);
GO
CREATE TABLE CustomerTransaction(
	TransactionId INT PRIMARY KEY,
	AccountNumber CHAR(9) FOREIGN KEY REFERENCES CustomerAccount(AccountNumber),
	TransactionDate SMALLDATETIME,
	Amount MONEY,
	DepositorWithdraw BIT
);
GO

/* Insert into each table at least 3 records */
USE AZBank;
GO
INSERT INTO Customer(CustomerId, [Name], City, Country, Phone, Email) VALUES
(1, 'La Trong Nghia', 'Hanoi', 'Vietnam', '0399308301', 'leonghiacnn@gmail.com'),
(2, 'Trinh Dinh Quoc', 'Thanh Hoa', 'Vietnam', '0986504232', 'quoctrinh204@gmail.com'),
(3, 'Truong Van Nhu', 'Vinh Phuc', 'Vietnam', '0988594690', 'truongnhu96@gmail.com');
GO
INSERT INTO CustomerAccount(AccountNumber, CustomerId, Balance, MinAccount) VALUES
('099143560', 1, 125000, 2500),
('099148529', 2, 280000, 3600),
('099144904', 3, 170000, 2700);
GO
INSERT INTO CustomerTransaction(TransactionId, AccountNumber, TransactionDate, Amount, DepositorWithdraw) VALUES
(1, '099143560', '2023-03-01 10:30:00', 10000, 1),
(2, '099148529', '2023-02-28 15:00:00', 5000, 0),
(3, '099144904', '2023-02-28 16:45:00', 12000, 1);
GO

/* Write a query to get all customers from Customer table who live in Hanoi */
SELECT * FROM Customer WHERE City = 'Hanoi';
GO

/* Write a query to get account information of the customers */
SELECT c.Name, c.Phone, c.Email, ca.AccountNumber, ca.Balance
FROM Customer c
JOIN CustomerAccount ca
	ON c.CustomerId = ca.CustomerId;
GO

/* Create a CHECK constraint on Amount column of CustomerTransaction table */
ALTER TABLE CustomerTransaction
ADD CHECK (Amount > 0 AND Amount <= 1000000);
GO

/* Create a view named vCustomerTransactions */
CREATE VIEW vCustomerTransactions
AS
SELECT c.Name, ca.AccountNumber, ct.TransactionDate, ct.Amount, ct.DepositorWithdraw
FROM Customer c
JOIN CustomerAccount ca
	ON c.CustomerId = ca.CustomerId
JOIN CustomerTransaction ct
	ON ca.AccountNumber = ct.AccountNumber;
GO