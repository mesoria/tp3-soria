use master
DECLARE @dbname nvarchar(128)
SET @dbname = N'SORIA_TP3'

IF(EXISTS(SELECT name FROM master.dbo.sysdatabases WHERE('[' + name + ']' = @dbname
OR name = @dbname)))
drop database SORIA_TP3

GO
use master
GO
CREATE DATABASE SORIA_TP3
GO
USE SORIA_TP3
GO
SET DATEFORMAT 'YMD'
GO
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
--esto agrega cien vouchers automaticamente.Que crack soy...de nada.
    DECLARE @cnt INT = 0;
WHILE @cnt < 100
BEGIN
INSERT INTO SORIA_TP3.dbo.Vouchers(CodigoVoucher) VALUES(DEFAULT);
SET @cnt = @cnt + 1;
WAITFOR DELAY '00:00:00.002'
END;

--select * from Vouchers
--select * from Productos
--select * from Clientes

INSERT INTO SORIA_TP3.dbo.Productos(Titulo, Descripcion, URLImagen) VALUES('Disco Sólido', 'Disco Ssd 120GB Kingston Mod. A400', 'https://http2.mlstatic.com/kingston-disco-ssd-120gb-a400-estado-solido-mkm-D_NQ_NP_703251-MLA31117941996_062019-W.webp');
INSERT INTO SORIA_TP3.dbo.Productos(Titulo, Descripcion, URLImagen) VALUES('Gabinete Gamer', 'Gabinete Sentey iluminación LED, acrílico', 'https://http2.mlstatic.com/gabinete-gaming-sentey-stealth-ii-led-blue-usb-30-acrilico-D_NQ_NP_863800-MLA31459885093_072019-W.webp');
INSERT INTO SORIA_TP3.dbo.Productos(Titulo, Descripcion, URLImagen) VALUES('Teclado y Mouse Gamer', 'Teclado y Mouse Gamer USB iluminado', 'https://http2.mlstatic.com/teclado-y-mouse-gamer-usb-retro-iluminado-led-2400dpi-combo-kit-D_NQ_NP_827235-MLA31036328746_062019-O.webp');
INSERT INTO SORIA_TP3.dbo.Productos(Titulo, Descripcion, URLImagen) VALUES('Auriculares Gaming', 'Auriculares varios colores según disponibilidad', 'https://http2.mlstatic.com/auriculares-bluetooth-super-bajos-vincha-garantia-gamer24hs-D_NQ_NP_830033-MLA32374309860_092019-F.webp');
INSERT INTO SORIA_TP3.dbo.Productos(Titulo, Descripcion, URLImagen) VALUES('Auriculares Gamer', 'Auriculares Starwave con micrófono stereo', 'https://http2.mlstatic.com/D_Q_NP_854864-MLA31352915260_072019-AB.webp');
INSERT INTO SORIA_TP3.dbo.Productos(Titulo, Descripcion, URLImagen) VALUES('Teclado y mouse Genius', 'Kit teclado y mouse inalambrico Slimstar', 'https://http2.mlstatic.com/kit-teclado-mouse-inalambrico-genius-slimstar-8006-smart-tv-D_NQ_NP_946247-MLA31023120490_062019-V.webp');


