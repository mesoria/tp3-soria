use master
DECLARE @dbname nvarchar(128)
SET @dbname = N'TP_WEB'

IF(EXISTS(SELECT name FROM master.dbo.sysdatabases WHERE('[' + name + ']' = @dbname
OR name = @dbname)))
drop database TP_WEB

GO
use master
go
CREATE DATABASE TP_WEB
GO
USE TP_WEB
Go
CREATE TABLE Productos(
    Id BIGINT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    Titulo VARCHAR(50) NOT NULL CHECK(LEN(Titulo) > 0),
    Descripcion VARCHAR(250) NOT NULL CHECK(LEN(Descripcion) > 0),
    URLImagen VARCHAR(1000) NOT NULL CHECK(LEN(URLImagen) > 0)
);

CREATE TABLE Clientes(
    Id BIGINT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    DNI INT UNIQUE NOT NULL CHECK(DNI > 0),
    Nombre VARCHAR(50) NOT NULL CHECK(LEN(Nombre) > 0),
    Apellido VARCHAR(50) NOT NULL CHECK(LEN(Apellido) > 0),
    Email VARCHAR(100) NOT NULL CHECK(LEN(Email) > 0),
    Direccion VARCHAR(50) NOT NULL CHECK(LEN(Direccion) > 0),
    Ciudad VARCHAR(50) NOT NULL CHECK(LEN(Ciudad) > 0),
    CodigoPostal VARCHAR(8) NOT NULL CHECK(LEN(CodigoPostal) > 0),
    FechaRegistro DATETIME NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Vouchers(
    Id INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    CodigoVoucher VARCHAR(32) UNIQUE DEFAULT CONVERT(VARCHAR(32), HashBytes('MD5', CONVERT(varchar, SYSDATETIME(), 121)), 2) CHECK(LEN(CodigoVoucher) = 32),
    Estado BIT NOT NULL DEFAULT 0 CHECK(Estado IN(1, 0)),
    IdCliente BIGINT DEFAULT NULL FOREIGN KEY REFERENCES Clientes(Id),
    IdProducto BIGINT DEFAULT NULL FOREIGN KEY REFERENCES Productos(Id),
    FechaRegistro DATETIME NULL DEFAULT NULL
);
--esto agrega 50 vouchers automaticamente.Que crack soy...de nada.
    DECLARE @cnt INT = 0;
WHILE @cnt < 50
BEGIN
INSERT INTO TP_WEB.dbo.Vouchers(CodigoVoucher) VALUES(DEFAULT);
SET @cnt = @cnt + 1;
WAITFOR DELAY '00:00:00.002'
END;


select count(id) from Vouchers