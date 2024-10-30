	-- Crear la base de datos
DROP DATABASE PERFILES_SA;
CREATE DATABASE PERFILES_SA;

GO
USE PERFILES_SA;
GO

-- Crear tabla de Departamentos
CREATE TABLE Departamentos (
    IdDepartamento INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Estado BIT NOT NULL DEFAULT 1, 
    FechaCreacion DATETIME DEFAULT GETDATE()
);
GO

-- Crear tabla de Empleados
CREATE TABLE Empleados (
    IdEmpleado INT PRIMARY KEY IDENTITY(1,1),
    Nombres NVARCHAR(100) NOT NULL,
    DPI CHAR(13) NOT NULL UNIQUE,
    FechaNacimiento DATE NOT NULL,
    Genero CHAR(1) CHECK (Genero IN ('M', 'F')),
    FechaIngreso DATE NOT NULL,
    Edad AS DATEDIFF(YEAR, FechaNacimiento, GETDATE()), 
    Direccion NVARCHAR(250) NULL,
    NIT CHAR(9) NULL,
    IdDepartamento INT NOT NULL,
    FOREIGN KEY (IdDepartamento) REFERENCES Departamentos(IdDepartamento)
);
GO

-- ------------------------------Departamento
-- ---------------Crear
CREATE PROCEDURE sp_CrearDepartamento
    @Nombre NVARCHAR(100)
AS
BEGIN
    INSERT INTO Departamentos (Nombre)
    VALUES (@Nombre);
END;
GO

-- ---------------Mostrar Departamentos 
CREATE PROCEDURE sp_LeerDepartamentos
AS
BEGIN
	-- Devuelve todos los departamentos
	SELECT IdDepartamento, Nombre, Estado, FechaCreacion
	FROM Departamentos;
END;
GO

-- ---------------Mostrar Departamento
CREATE PROCEDURE sp_LeerDepartamento
    @IdDepartamento INT = NULL
AS
    BEGIN
        -- Devuelve el departamento específico
        SELECT IdDepartamento, Nombre, Estado, FechaCreacion
        FROM Departamentos
        WHERE IdDepartamento = @IdDepartamento;
    END;
GO

-- ---------------Actualizar
CREATE PROCEDURE sp_ActualizarDepartamento
    @IdDepartamento INT,
    @Nombre NVARCHAR(100),
    @Estado BIT
AS
BEGIN
    UPDATE Departamentos
    SET Nombre = @Nombre,
        Estado = @Estado
    WHERE IdDepartamento = @IdDepartamento;
END;
GO

-- ---------------Eliminar
CREATE PROCEDURE sp_EliminarDepartamento
    @IdDepartamento INT
AS
BEGIN
    UPDATE Departamentos
    SET Estado = 0
    WHERE IdDepartamento = @IdDepartamento;
END;
GO

-- ------------------------------Empleados
-- ---------------Crear
CREATE PROCEDURE sp_CrearEmpleado
    @Nombres NVARCHAR(100),
    @DPI CHAR(13),
    @FechaNacimiento DATE,
    @Genero CHAR(1),
    @FechaIngreso DATE,
    @Direccion NVARCHAR(250) = NULL,
    @NIT CHAR(9) = NULL,
    @IdDepartamento INT
AS
BEGIN
    INSERT INTO Empleados (Nombres, DPI, FechaNacimiento, Genero, FechaIngreso, Direccion, NIT, IdDepartamento)
    VALUES (@Nombres, @DPI, @FechaNacimiento, @Genero, @FechaIngreso, @Direccion, @NIT, @IdDepartamento);
END;
GO

-- ---------------Mostrar Empleados 
CREATE PROCEDURE sp_LeerEmpleados
AS
BEGIN
	-- Devuelve todos los empleados
	SELECT 
		e.IdEmpleado, e.Nombres, e.DPI, e.FechaNacimiento, e.Genero, e.FechaIngreso, e.Edad, e.Direccion, e.NIT, d.IdDepartamento, d.Nombre
	FROM 
		Empleados e
	INNER JOIN Departamentos d on d.IdDepartamento = e.IdDepartamento;
END;
GO

-- ---------------Mostrar Empleados 
CREATE PROCEDURE sp_LeerEmpleado
    @IdEmpleado INT = NULL
AS
BEGIN
	-- Devuelve un empleado específico
	SELECT 
		e.IdEmpleado, e.Nombres, e.DPI, e.FechaNacimiento, e.Genero, e.FechaIngreso, e.Edad, e.Direccion, e.NIT, d.IdDepartamento, d.Nombre
	FROM 
		Empleados e
	INNER JOIN Departamentos d on d.IdDepartamento = e.IdDepartamento
	WHERE 
		e.IdEmpleado = @IdEmpleado;
END;
GO

-- ---------------Actualizar Empleados 
CREATE PROCEDURE sp_ActualizarEmpleado
    @IdEmpleado INT,
    @Nombres NVARCHAR(100),
    @DPI CHAR(13),
    @FechaNacimiento DATE,
    @Genero CHAR(1),
    @FechaIngreso DATE,
    @Direccion NVARCHAR(250) = NULL,
    @NIT CHAR(9) = NULL,
    @IdDepartamento INT
AS
BEGIN
    UPDATE Empleados
    SET 
        Nombres = @Nombres,
        DPI = @DPI,
        FechaNacimiento = @FechaNacimiento,
        Genero = @Genero,
        FechaIngreso = @FechaIngreso,
        Direccion = @Direccion,
        NIT = @NIT,
        IdDepartamento = @IdDepartamento
    WHERE 
        IdEmpleado = @IdEmpleado;
END;
GO

-- ---------------Eliminar Empleados 
CREATE PROCEDURE sp_EliminarEmpleado
    @IdEmpleado INT
AS
BEGIN
    DELETE FROM Empleados
    WHERE IdEmpleado = @IdEmpleado;
END;
GO

-- ---------------Reportes empleados
CREATE PROCEDURE sp_ReporteEmpleados
    @IdDepartamento INT = NULL,
    @Estado BIT = NULL,
    @FechaIngresoInicio DATE = NULL,
    @FechaIngresoFin DATE = NULL
AS
BEGIN
    SELECT 
        e.IdEmpleado,
        e.Nombres,
        e.DPI,
        e.FechaNacimiento,
        DATEDIFF(YEAR, e.FechaNacimiento, GETDATE()) AS Edad,
        e.Genero,
        e.FechaIngreso,
        e.Direccion,
        e.NIT,
        d.Nombre AS Departamento,
        d.Estado AS EstadoDepartamento
    FROM 
        Empleados e
    JOIN 
        Departamentos d ON e.IdDepartamento = d.IdDepartamento
    WHERE 
        (@IdDepartamento IS NULL OR e.IdDepartamento = @IdDepartamento)
        AND (@Estado IS NULL OR d.Estado = @Estado)
        AND (@FechaIngresoInicio IS NULL OR e.FechaIngreso >= @FechaIngresoInicio)
        AND (@FechaIngresoFin IS NULL OR e.FechaIngreso <= @FechaIngresoFin)
    ORDER BY 
        d.Nombre, e.Nombres;
END;
GO
