USE [RADICACIONESDB]
GO
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES 
           WHERE ROUTINE_NAME = 'RADICACIONES_PRO_APP_INSERTAR_RADICACIONES' 
             AND ROUTINE_SCHEMA = 'dbo' 
             AND ROUTINE_TYPE = 'PROCEDURE')
 EXEC ('DROP PROCEDURE dbo.RADICACIONES_PRO_APP_INSERTAR_RADICACIONES');
GO

CREATE PROCEDURE RADICACIONES_PRO_APP_INSERTAR_RADICACIONES
@Usuario_Auditoria VARCHAR(120),
@Usuario_Remitente  BIGINT,
@Usuario_Destinatario  BIGINT,
@Tipo_Archivo  BIGINT,
@Observaciones  	VARCHAR(MAX), 
@Url_Archivo  	VARCHAR(MAX), 
@Codigo_Respuesta	INT OUTPUT,
@Id_Generado BIGINT OUTPUT,
@Mensaje			VARCHAR(MAX) OUTPUT
AS
/****************************************************************************************************
*
* Autor:		John Alexander Jimenez. <jhonalexjm@gmail.com>
* Fecha:		22/03/2021
* Descripci�n:	Permite insertar radicaciones
*
* Historia de Modificaciones
* Autor			Fecha			 Descripci�n
*
****************************************************************************************************/
SET NOCOUNT ON;

-- Declaraci?n de cursores
	DECLARE CU_ARCHIVOS_INTERNOS CURSOR LOCAL FOR
  		SELECT COUNT(1)
		  FROM Archivo
		  WHERE TipoArchivoId = 1;

	DECLARE CU_ARCHIVOS_EXTERNOS CURSOR LOCAL FOR
  		SELECT COUNT(1)
		  FROM Archivo
		  WHERE TipoArchivoId = 2;


-- Declaracion de Variables
	DECLARE @va_Procedure VARCHAR(MAX);
	DECLARE @va_Id_Radicacion VARCHAR(MAX);
	

	DECLARE @int_Id_Ultima_Radicacion INT;

	DECLARE @nu_Cantidad_Archivos_Internos BIGINT = 0;
	DECLARE @nu_Cantidad_Archivos_Externos BIGINT = 0;
	DECLARE @nu_Caracteres INT;
	DECLARE @nu_Agregar_Caracteres INT;
	DECLARE @nu_contador INT = 1;
	DECLARE @nu_Usuario BIGINT;
	

BEGIN TRY
	
	PRINT 'TIPO ARCHIVO'
	PRINT @Tipo_Archivo 
	IF(@Tipo_Archivo = 1)
		BEGIN  
		-- INTERNO
			OPEN CU_ARCHIVOS_INTERNOS;
				FETCH CU_ARCHIVOS_INTERNOS INTO @nu_Cantidad_Archivos_Internos;
			CLOSE CU_ARCHIVOS_INTERNOS;
			DEALLOCATE CU_ARCHIVOS_INTERNOS;	

			IF(@nu_Cantidad_Archivos_Internos <> 0)
				BEGIN
					SELECT TOP(1) @int_Id_Ultima_Radicacion =  CAST(SUBSTRING(NumeroRadicado, 3, 8) AS INT)
					FROM Archivo
					WHERE TipoArchivoId = 1 
					ORDER BY Id Desc;
					PRINT 'NUMERO RADICACION'
					PRINT @int_Id_Ultima_Radicacion
					SET @int_Id_Ultima_Radicacion = @int_Id_Ultima_Radicacion + 1;
					PRINT 'NUMERO RADICACION SUMADO'
					PRINT @int_Id_Ultima_Radicacion
					SET @va_Id_Radicacion = CAST(@int_Id_Ultima_Radicacion AS VARCHAR);

					SELECT @nu_Caracteres =  LEN(@va_Id_Radicacion);
					--8
					SELECT  @nu_Agregar_Caracteres = 9 - @nu_Caracteres;

					WHILE @nu_contador < @nu_Agregar_Caracteres
						BEGIN
							SET @va_Id_Radicacion = '0' + @va_Id_Radicacion;
							SET @nu_contador = @nu_contador + 1;
						END
					SET @va_Id_Radicacion = 'CI' + @va_Id_Radicacion
				
				END
			ELSE
				BEGIN
					SET @va_Id_Radicacion = 'CI00000001'
				END
		END
	ELSE
		BEGIN
		--EXTERNO
			OPEN CU_ARCHIVOS_EXTERNOS;
				FETCH CU_ARCHIVOS_EXTERNOS INTO @nu_Cantidad_Archivos_Externos;
			CLOSE CU_ARCHIVOS_EXTERNOS;
			DEALLOCATE CU_ARCHIVOS_EXTERNOS;
			PRINT 'INGRESO'
			PRINT 'CANTIDAD DE ARCHIVO EXTERNOS'
			PRINT @nu_Cantidad_Archivos_Externos
			IF(@nu_Cantidad_Archivos_Externos <> 0)
				BEGIN
					SELECT TOP(1) @int_Id_Ultima_Radicacion =  CAST(SUBSTRING(NumeroRadicado, 3, 8) AS INT)
					FROM Archivo
					WHERE TipoArchivoId = 2 
					ORDER BY Id Desc;
					PRINT 'NUMERO RADICACION'
					PRINT @int_Id_Ultima_Radicacion
					SET @int_Id_Ultima_Radicacion = @int_Id_Ultima_Radicacion + 1;
					PRINT 'DESPUES DE SUMADO'
					PRINT @int_Id_Ultima_Radicacion
					SET @va_Id_Radicacion = CAST(@int_Id_Ultima_Radicacion AS VARCHAR);
					PRINT 'CONVERTIDO A VARCHAR'
					PRINT @va_Id_Radicacion
					SELECT @nu_Caracteres =  LEN(@va_Id_Radicacion);
					--8
					SELECT  @nu_Agregar_Caracteres = 9 - @nu_Caracteres;

					WHILE @nu_contador < @nu_Agregar_Caracteres
						BEGIN
							SET @va_Id_Radicacion = '0' + @va_Id_Radicacion;
							SET @nu_contador = @nu_contador + 1;
						END
					SET @va_Id_Radicacion = 'CE' + @va_Id_Radicacion

				END
			ELSE
				BEGIN
					SET @va_Id_Radicacion = 'CE00000001'
					PRINT @va_Id_Radicacion
				END
		END

	INSERT INTO Archivo
					(	FechaCreacion
					   ,UsuarioCreacion
					   ,FechaActualizacion
					   ,UsuarioActualizacion
					   ,NumeroRadicado
					   ,FechaRadicado
					   ,UrlArchivo
					   ,TipoArchivoId
					)
				VALUES
					( 
						GETDATE(),
						@Usuario_Auditoria,
						GETDATE(),
						@Usuario_Auditoria,
						@va_Id_Radicacion,
						GETDATE(),
						@Url_Archivo,
						@Tipo_Archivo )
					
	 SET @Id_Generado = SCOPE_IDENTITY();
	 PRINT 'ARCHIVO ID '
	 PRINT @Id_Generado
	 IF(@Id_Generado <> 0)
		BEGIN
			SET @nu_contador = 0;
			PRINT 'CONTADOR'
			SET @nu_Usuario = @Usuario_Remitente
			WHILE @nu_contador < 2
				BEGIN	
					
					IF( @nu_contador = 1)
						BEGIN
							SET @nu_Usuario = @Usuario_Destinatario
						END
					PRINT 'USUARIO A INSERTAR'
					PRINT @nu_Usuario
					INSERT INTO GestionDocumento
					(	FechaCreacion
					   ,UsuarioCreacion
					   ,FechaActualizacion
					   ,UsuarioActualizacion
					   ,Observaciones
					   ,FechaEnvio
					   ,ArchivoId
					   ,UsuarioId
					)
					VALUES
					( 
						GETDATE(),
						@Usuario_Auditoria,
						GETDATE(),
						@Usuario_Auditoria,
						@Observaciones,
						GETDATE(),
						@Id_Generado,
						@nu_Usuario )
					SET @nu_contador = @nu_contador + 1;
					
				END
		END
	
END TRY
BEGIN CATCH
	SET @Codigo_Respuesta = ERROR_NUMBER();
	SET @Mensaje = CONCAT('Linea: ',ERROR_LINE(),' - ',ERROR_MESSAGE());  
	SET @va_Procedure = ERROR_PROCEDURE();
END CATCH
GO
