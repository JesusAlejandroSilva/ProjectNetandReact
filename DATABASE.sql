
CREATE DATABASE Employees;

USE Employees;

-- Crear la tabla Rol
CREATE TABLE Rol (
    IdRol INT PRIMARY KEY IDENTITY(1,1),  -- Clave primaria con incremento autom�tico
    NombreRol NVARCHAR(100) NOT NULL
);

-- Crear la tabla Empleado
CREATE TABLE Empleado (
    IdEmpleado INT PRIMARY KEY IDENTITY(1,1),  -- Clave primaria con incremento autom�tico
    Nombre NVARCHAR(100) NOT NULL,
    Posicion NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255),
    Estado NVARCHAR(50) NOT NULL,
    FechaCreacion DATETIME DEFAULT GETDATE(),
    FechaModificacion DATETIME DEFAULT GETDATE() ON UPDATE GETDATE()
);

-- Crear la tabla Usuario
CREATE TABLE Usuario (
    IdUsuario INT PRIMARY KEY IDENTITY(1,1),  -- Clave primaria con incremento autom�tico
    Username NVARCHAR(100) NOT NULL UNIQUE,  -- Nombre de usuario �nico
    [Password] NVARCHAR(255) NOT NULL,       -- Password protegido
    Email NVARCHAR(100) NOT NULL UNIQUE,     -- Correo electr�nico �nico
    FechaCreacion DATETIME DEFAULT GETDATE(),
    FechaModificacion DATETIME DEFAULT GETDATE() ON UPDATE GETDATE(),
    IdRol INT NOT NULL,                      -- Clave for�nea a la tabla Rol
    CONSTRAINT FK_Usuario_Rol FOREIGN KEY (IdRol) REFERENCES Rol(IdRol)  -- Relaci�n con Rol
);
