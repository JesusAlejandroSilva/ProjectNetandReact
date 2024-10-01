CREATE PROCEDURE sp_GetAllEmpleados
AS
BEGIN
    SELECT * FROM Empleado
END
GO

CREATE PROCEDURE sp_GetEmpleadoById
    @IdEmpleado INT
AS
BEGIN
    SELECT * FROM Empleado WHERE IdEmpleado = @IdEmpleado
END
GO

CREATE PROCEDURE sp_AddEmpleado
    @Nombre NVARCHAR(100),
    @Posicion NVARCHAR(100),
    @Descripcion NVARCHAR(255),
    @Estado BIT
AS
BEGIN
    INSERT INTO Empleado (Nombre, Posicion, Descripcion, Estado, FechaCreacion)
    VALUES (@Nombre, @Posicion, @Descripcion, @Estado, GETDATE())
END
GO

CREATE PROCEDURE sp_UpdateEmpleado
    @IdEmpleado INT,
    @Nombre NVARCHAR(100),
    @Posicion NVARCHAR(100),
    @Descripcion NVARCHAR(255),
    @Estado BIT
AS
BEGIN
    UPDATE Empleado
    SET Nombre = @Nombre,
        Posicion = @Posicion,
        Descripcion = @Descripcion,
        Estado = @Estado,
        FechaModificacion = GETDATE()
    WHERE IdEmpleado = @IdEmpleado
END
GO

CREATE PROCEDURE sp_DeleteEmpleado
    @IdEmpleado INT
AS
BEGIN
    DELETE FROM Empleado WHERE IdEmpleado = @IdEmpleado
END
GO
