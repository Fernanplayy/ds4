/*-------- Creacion de la BD -------- */
CREATE DATABASE BancoWebDB;
GO

USE BancoWebDB;
GO

/*---------- CREACION DE TABLAS ----------*/
CREATE TABLE Usuario (
    UsuarioId INT IDENTITY PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    FechaCreacion DATETIME DEFAULT GETDATE(),
    Activo BIT DEFAULT 1
);
GO

CREATE TABLE Cuenta (
    CuentaId INT IDENTITY PRIMARY KEY,
    NumeroCuenta NVARCHAR(20) NOT NULL UNIQUE,
    UsuarioId INT NOT NULL,
    Saldo DECIMAL(18,2) NOT NULL DEFAULT 0,
    Estado BIT DEFAULT 1,
    CONSTRAINT FK_Cuenta_Usuario
        FOREIGN KEY (UsuarioId) REFERENCES Usuario(UsuarioId)
);
GO

CREATE TABLE Movimiento (
    MovimientoId INT IDENTITY PRIMARY KEY,
    CuentaId INT NOT NULL,
    Tipo NVARCHAR(10) NOT NULL, -- DEBITO / CREDITO
    Monto DECIMAL(18,2) NOT NULL,
    Fecha DATETIME DEFAULT GETDATE(),
    SaldoAnterior DECIMAL(18,2),
    SaldoNuevo DECIMAL(18,2),
    CONSTRAINT FK_Movimiento_Cuenta
        FOREIGN KEY (CuentaId) REFERENCES Cuenta(CuentaId)
);
GO

/* ---------- PROCEDIMIENTOS ALMACENADOS ---------- */

------[REGISTRAR USUARIO]------
CREATE PROCEDURE sp_RegistrarUsuario
    @Nombre NVARCHAR(100),
    @Email NVARCHAR(100),
    @Password NVARCHAR(255)
AS
BEGIN
    INSERT INTO Usuario (Nombre, Email, Password)
    VALUES (@Nombre, @Email, @Password);

    DECLARE @UsuarioId INT = SCOPE_IDENTITY();

    INSERT INTO Cuenta (NumeroCuenta, UsuarioId, Saldo)
    VALUES (
        CONCAT('1001', FORMAT(@UsuarioId, '00000')),
        @UsuarioId, 0
    );
END;
GO

------[LOGIN USUARIO]------
CREATE PROCEDURE sp_LoginUsuario
    @Email NVARCHAR(100),
    @Password NVARCHAR(255)
AS
BEGIN
    SELECT UsuarioId, Nombre
    FROM Usuario
    WHERE Email = @Email
      AND Password = @Password
      AND Activo = 1;
END;
GO

-----[TRANSFERIR DINERO]-----
CREATE PROCEDURE sp_TransferirSimple
    @CuentaOrigenId INT,
    @NumeroCuentaDestino NVARCHAR(20),
    @Monto DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @CuentaDestinoId INT;
    DECLARE @SaldoOrigen DECIMAL(18,2);
    DECLARE @SaldoDestino DECIMAL(18,2);

    -- Validar cuenta destino
    SELECT 
        @CuentaDestinoId = CuentaId,
        @SaldoDestino = Saldo
    FROM Cuenta
    WHERE NumeroCuenta = @NumeroCuentaDestino;

    IF @CuentaDestinoId IS NULL
    BEGIN
        RAISERROR('Cuenta destino no existe', 16, 1);
        RETURN;
    END

    -- Obtener saldo origen
    SELECT @SaldoOrigen = Saldo
    FROM Cuenta
    WHERE CuentaId = @CuentaOrigenId;

    IF @SaldoOrigen < @Monto
    BEGIN
        RAISERROR('Saldo insuficiente', 16, 1);
        RETURN;
    END

    BEGIN TRANSACTION;

    -- Actualizar saldo cuenta origen
    UPDATE Cuenta
    SET Saldo = Saldo - @Monto
    WHERE CuentaId = @CuentaOrigenId;

    -- Actualizar saldo cuenta destino
    UPDATE Cuenta
    SET Saldo = Saldo + @Monto
    WHERE CuentaId = @CuentaDestinoId;

    -- Registrar movimientos
    INSERT INTO Movimiento (CuentaId, Tipo, Monto, SaldoAnterior, SaldoNuevo)
    VALUES
        (@CuentaOrigenId, 'DEBITO',  @Monto, @SaldoOrigen,  @SaldoOrigen - @Monto),
        (@CuentaDestinoId,'CREDITO', @Monto, @SaldoDestino, @SaldoDestino + @Monto);

    COMMIT TRANSACTION;
END;
GO

