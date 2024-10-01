
CREATE DATABASE Employees;

USE Employees;

-- Crear la tabla Rol
CREATE TABLE Rol (
    IdRol INT PRIMARY KEY IDENTITY(1,1),  -- Clave primaria con incremento automático
    NombreRol NVARCHAR(100) NOT NULL
);

-- Crear la tabla Empleado
CREATE TABLE Empleado (
    IdEmpleado INT PRIMARY KEY IDENTITY(1,1),  -- Clave primaria con incremento automático
    Nombre NVARCHAR(100) NOT NULL,
    Posicion NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255),
    Estado NVARCHAR(50) NOT NULL,
    FechaCreacion DATETIME DEFAULT GETDATE(),
    FechaModificacion DATETIME DEFAULT GETDATE() ON UPDATE GETDATE()
);

-- Crear la tabla Usuario
CREATE TABLE Usuario (
    IdUsuario INT PRIMARY KEY IDENTITY(1,1),  -- Clave primaria con incremento automático
    Username NVARCHAR(100) NOT NULL UNIQUE,  -- Nombre de usuario único
    [Password] NVARCHAR(255) NOT NULL,       -- Password protegido
    Email NVARCHAR(100) NOT NULL UNIQUE,     -- Correo electrónico único
    FechaCreacion DATETIME DEFAULT GETDATE(),
    FechaModificacion DATETIME DEFAULT GETDATE() ON UPDATE GETDATE(),
    IdRol INT NOT NULL,                      -- Clave foránea a la tabla Rol
    CONSTRAINT FK_Usuario_Rol FOREIGN KEY (IdRol) REFERENCES Rol(IdRol)  -- Relación con Rol
);
