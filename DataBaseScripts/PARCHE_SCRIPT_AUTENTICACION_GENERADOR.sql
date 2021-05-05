/*
Proyecto: Todos los proyectos (Generador de Código)
Autor/Desarrollador: Jorge Medina	
Fecha: 19/01/2021
Descripcion: - Crea SP necesarios para la Autenticacion por BD.
             - Corrige problemas al momento de realizar Login a BD, Crea nuevo SP "Proc_Autenticacion_VerificaUsuario" y 
			 - Cambio en el password por defcto del usuario admin.
Prerequisitos: Crear la BD del Sistema y apuntar a ella al ejecutar el presente script.
Postrequisitos: Ninguno.
*/

CREATE TABLE [dbo].[Autenticacion](
	[IDAutenticacion] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](50) NULL,
	[Password] [varchar](max) NULL,
	[SesionIniciada] [bit] NULL,
	[FechaUltimaSesionIniciada] [datetime] NULL,
	[FechaUltimaSesionCerrada] [datetime] NULL,
	[Estado] [bit] NOT NULL
)

GO

Create procedure [dbo].[Proc_Autenticacion_Login]
	@Usuario varchar(50),
	@Password varchar(MAX)	
as

IF NOT EXISTS(SELECT * FROM AUTENTICACION Where AUTENTICACION.Usuario = @Usuario And AUTENTICACION.Estado = 1)
BEGIN
	RAISERROR ('Usuario no registrado!',16,1)
	Return 0
END
	DECLARE @HASHED_PASSWORD varchar(MAX)
	SET @HASHED_PASSWORD = (SELECT HASHBYTES('SHA2_256',@Password))
	select @HASHED_PASSWORD 
	
	IF NOT EXISTS(SELECT * FROM AUTENTICACION Where AUTENTICACION.Usuario = @Usuario And AUTENTICACION.Password = @HASHED_PASSWORD And AUTENTICACION.Estado = 1)
	BEGIN
		RAISERROR ('El Usuario y/o Password son erroneos!',16,1)
		Return 0
	END
	ELSE
	BEGIN
		Update AUTENTICACION 
		set AUTENTICACION.SesionIniciada = 1,
			AUTENTICACION.FechaUltimaSesionIniciada = SYSDATETIME() 	
	END
GO 

Create procedure [dbo].[Proc_Autenticacion_Logout]
	@Usuario varchar(50)
as

IF NOT EXISTS(SELECT * FROM AUTENTICACION Where AUTENTICACION.Usuario = @Usuario And AUTENTICACION.Estado = 1)
BEGIN
	RAISERROR ('Usuario no registrado!',16,1)
	Return 0
END

IF NOT EXISTS(SELECT * FROM AUTENTICACION Where AUTENTICACION.Usuario = @Usuario And AUTENTICACION.Estado = 1 And AUTENTICACION.SesionIniciada = 0)
BEGIN
	RAISERROR ('La sesión se encuentra cerrada!',16,1)
	Return 0
END

BEGIN
	Update AUTENTICACION 
	set AUTENTICACION.SesionIniciada = 0,
		AUTENTICACION.FechaUltimaSesionCerrada = SYSDATETIME()
END

GO

Create procedure [dbo].[Proc_Autenticacion_VerificaUsuario]
	@Usuario varchar(50)
as

IF NOT EXISTS(SELECT * FROM AUTENTICACION Where AUTENTICACION.Usuario = @Usuario And AUTENTICACION.Estado = 1)
BEGIN
	RAISERROR ('Usuario no registrado!',16,1)
	Return 0
END

GO 

-- INSERTS

Insert into Autenticacion 
Values ('admin',
		'Í¢ç>¸©4’ÞZJ¥ö×`|?C) àÌQ‹e:hÈ3', --'Alpha123' Borrar el dato
		0,
		SYSDATETIME(),
		SYSDATETIME(),
		1)