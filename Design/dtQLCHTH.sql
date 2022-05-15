CREATE DATABASE QLCHTH
GO

USE QLCHTH
GO

--Create Table
CREATE TABLE TypeAccount
(
	idTypeAccount INT IDENTITY PRIMARY KEY NOT NULL,
	nameTypeAccount NVARCHAR(100) NOT NULL
)
GO

CREATE TABLE AccountD
(
	userName NVARCHAR(100) PRIMARY KEY NOT NULL ,
	displayName NVARCHAR(100) NOT NULL ,
	password NVARCHAR(1000) NOT NULL , 
	idTypeAccount INT NOT NULL ,

	FOREIGN KEY (idTypeAccount) REFERENCES TypeAccount(idTypeAccount) 
)
GO
CREATE TABLE Supplier
(
	idSupplier INT IDENTITY PRIMARY KEY NOT NULL,
	nameSupplier NVARCHAR(100) NOT NULL,
	addressSupplier NVARCHAR(200) NOT NULL,
	kindproduct NVARCHAR(200) NOT NULL,
	pnSupplier NVARCHAR(100) NOT NULL
)
Go
CREATE TABLE Products
(
	idProduct INT IDENTITY PRIMARY KEY NOT NULL,
	nameProduct NVARCHAR(100) NOT NULL, 
	price float NOT NULL,
	idSupplier INT NOT NULL,
	FOREIGN KEY (idSupplier) REFERENCES dbo.Supplier (idSupplier)
)
GO
CREATE TABLE NhanVien
(
	idNhanVien INT IDENTITY PRIMARY KEY,
	maNhanVien NVARCHAR(10) NOT NULL,
	tenNhanVien NVARCHAR(100) NOT NULL,
)
GO
CREATE TABLE Bill
(
	idBill INT IDENTITY PRIMARY KEY,
	idNhanVien INT NOT NULL,
	idProduct INT NOT NULL,
	tenNhanVien NVARCHAR(100)NOT NULL,
	getIn DATETIME NOT NULL DEFAULT GETDATE(),
	nameProduct NVARCHAR(100) NOT NULL,
	numberP int NOT NULL,
	price FLOAT NOT NULL DEFAULT 0,
	totalPrice FLOAT NOT NULL DEFAULT 0, 
	FOREIGN KEY (idNhanVien) REFERENCES NhanVien (idNhanVien),
	FOREIGN KEY (idProduct) REFERENCES Products (idProduct)
)
GO
CREATE TABLE Storage
(
	stt INT IDENTITY PRIMARY KEY,
	tenKho NVARCHAR(100) NOT NULL,
	idProduct INT NOT NULL,
	ngaynhap DATETIME NOT NULL,
	slconlai INT NOT NULL,
	FOREIGN KEY (idProduct) REFERENCES dbo.Products (idProduct)
)
GO 
--INSERT Table

-- TypeAccount
INSERT TypeAccount
(
	nameTypeAccount
)
VALUES
(
	N'admin'
)
INSERT TypeAccount
(
	nameTypeAccount
)
VALUES
(
	N'user'
)
GO
-- AccountD
INSERT AccountD
(
	userName, displayName , password , idTypeAccount
)
VALUES
(	N'admin', N'Nhan' , N'123456' , 1)
GO
--Create proc
CREATE PROC USP_CheckLogin
@useName NVARCHAR(100),
@password NVARCHAR(1000)
AS
BEGIN
	SELECT * FROM AccountD WHERE userName = @useName AND password = @password
END
GO

CREATE PROC USP_AddAccountByUserName
@userName NVARCHAR(100),
@displayName NVARCHAR(100),
@idTypeAccount INT,
@password NVARCHAR(1000)
AS
BEGIN
	INSERT AccountD
	(
		userName , displayName , idTypeAccount , password
	)
	VALUES
	(
		@userName , @displayName , @idTypeAccount , @password
	)
END
GO

CREATE PROC USP_UpdateAccountByUserNameNoPass
@userName NVARCHAR(100) , 
@displayName NVARCHAR(100) , 
@idTypeAccount INT
AS
BEGIN
	UPDATE AccountD
	SET displayName = @displayName , idTypeAccount = @idTypeAccount
	WHERE userName = @userName
END
GO

CREATE PROC USP_UpdateAccountByUserName
@userName NVARCHAR(100),
@displayName NVARCHAR(100),
@idTypeAccount INT,
@password NVARCHAR(1000)
AS
BEGIN
	UPDATE AccountD
	SET displayName = @displayName , idTypeAccount = @idTypeAccount , password = @password
	WHERE userName = @userName
END
GO

















