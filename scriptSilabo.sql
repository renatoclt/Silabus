delete from SilabusDB_2.dbo.SilaboDivisiones;
delete from SilabusDB_2.dbo.Silabos;
delete from SilabusDB_2.dbo.Asignaturas;
delete from SilabusDB_2.dbo.PlanFuncionamientos;
delete from SilabusDB_2.dbo.PlanEstudios;
delete from SilabusDB_2.dbo.Escuelas;
delete from SilabusDB_2.dbo.Departamentos;
delete from SilabusDB_2.dbo.Facultades;
delete from SilabusDB_2.dbo.Docentes;
delete from SilabusDB_2.dbo.TipoDocentes;
delete from SilabusDB_2.dbo.Estadoes;
delete from SilabusDB_2.dbo.Divisiones;


SET IDENTITY_INSERT SilabusDB_2.dbo.Divisiones ON
insert into SilabusDB_2.dbo.Divisiones (Id , Titulo , Estado , FechaCreacion, UsuarioCreacion) 
			values((SELECT ISNULL(MAX(Id) + 1, 1) FROM SilabusDB_2.dbo.Divisiones) , 'IDENTIFICACIÓN ACADÉMICA', 1 , getdate(), 'admin'   ) ;
insert into SilabusDB_2.dbo.Divisiones (Id , Titulo , Estado , FechaCreacion, UsuarioCreacion) 
			values((SELECT ISNULL(MAX(Id) + 1, 1) FROM SilabusDB_2.dbo.Divisiones) , 'SUMILLA ', 1 , getdate(), 'admin'   ) ;
insert into SilabusDB_2.dbo.Divisiones (Id , Titulo , Estado , FechaCreacion, UsuarioCreacion) 
			values((SELECT ISNULL(MAX(Id) + 1, 1) FROM SilabusDB_2.dbo.Divisiones) , 'COMPETENCIAS DE LA ASIGNATURA QUE APOYAN AL PERFIL DE EGRESO ', 1 , getdate(), 'admin'   ) ;
insert into SilabusDB_2.dbo.Divisiones (Id , Titulo , Estado , FechaCreacion, UsuarioCreacion) 
			values((SELECT ISNULL(MAX(Id) + 1, 1) FROM SilabusDB_2.dbo.Divisiones) , 'CONTENIDOS BÁSICOS POR UNIDADES DE APRENDIZAJE', 1 , getdate(), 'admin'   ) ;
insert into SilabusDB_2.dbo.Divisiones (Id , Titulo , Estado , FechaCreacion, UsuarioCreacion) 
			values((SELECT ISNULL(MAX(Id) + 1, 1) FROM SilabusDB_2.dbo.Divisiones) , 'EVALUACIÓN DE COMPETENCIAS ADQUIRIDAS ', 1 , getdate(), 'admin'   ) ;
insert into SilabusDB_2.dbo.Divisiones (Id , Titulo , Estado , FechaCreacion, UsuarioCreacion) 
			values((SELECT ISNULL(MAX(Id) + 1, 1) FROM SilabusDB_2.dbo.Divisiones) , 'BIBLIOGRAFÍA', 1 , getdate(), 'admin'   ) ;
SET IDENTITY_INSERT SilabusDB_2.dbo.Divisiones OFF ;


SET IDENTITY_INSERT SilabusDB_2.dbo.Estadoes ON
insert into SilabusDB_2.dbo.Estadoes(Id , descripcion , Estado , FechaCreacion, UsuarioCreacion) 
			values((SELECT ISNULL(MAX(Id) + 1, 1) FROM SilabusDB_2.dbo.Estadoes) , 'Abierto', 1 , getdate(), 'admin'   ) ;
insert into SilabusDB_2.dbo.Estadoes(Id , descripcion , Estado , FechaCreacion, UsuarioCreacion) 
			values((SELECT ISNULL(MAX(Id) + 1, 1) FROM SilabusDB_2.dbo.Estadoes) , 'Proceso', 1 , getdate(), 'admin'   ) ;
insert into SilabusDB_2.dbo.Estadoes(Id , descripcion , Estado , FechaCreacion, UsuarioCreacion) 
			values((SELECT ISNULL(MAX(Id) + 1, 1) FROM SilabusDB_2.dbo.Estadoes) , 'Aprobado', 1 , getdate(), 'admin'   ) ;
insert into SilabusDB_2.dbo.Estadoes(Id , descripcion , Estado , FechaCreacion, UsuarioCreacion) 
			values((SELECT ISNULL(MAX(Id) + 1, 1) FROM SilabusDB_2.dbo.Estadoes) , 'Concluido', 1 , getdate(), 'admin'   ) ;
insert into SilabusDB_2.dbo.Estadoes(Id , descripcion , Estado , FechaCreacion, UsuarioCreacion) 
			values((SELECT ISNULL(MAX(Id) + 1, 1) FROM SilabusDB_2.dbo.Estadoes) , 'Cerrado', 1 , getdate(), 'admin'   ) ;
SET IDENTITY_INSERT SilabusDB_2.dbo.Estadoes OFF ;


SET IDENTITY_INSERT SilabusDB_2.dbo.TipoDocentes ON

insert into SilabusDB_2.dbo.TipoDocentes (Id , descripcion , Estado , FechaCreacion, UsuarioCreacion) 
			values((SELECT ISNULL(MAX(Id) + 1, 1) FROM SilabusDB_2.dbo.TipoDocentes) , 'Docente', 1 , getdate(), 'admin'   ) 

SET IDENTITY_INSERT SilabusDB_2.dbo.TipoDocentes OFF;




SET IDENTITY_INSERT SilabusDB_2.dbo.Docentes ON 

Declare @TotalDocentes int
Declare @RowActual int
set @TotalDocentes = 3
set @RowActual = 0
 
while @RowActual < @TotalDocentes
begin
	set @RowActual = @RowActual + 1
	insert into SilabusDB_2.dbo.Docentes(Id , Nombres , ApellidoPaterno , ApellidoMaterno , Codigo , IdTipoDocentes,  Estado , FechaCreacion, UsuarioCreacion) 
			values((SELECT ISNULL(MAX(Id) + 1, 1) FROM SilabusDB_2.dbo.Docentes) , 'Nombre' + (select cast(@RowActual as varchar)) ,
			 'Apellido P' + (select cast(@RowActual as varchar)) , 'Apellido M' + (select cast(@RowActual as varchar)) ,  (select (CAST(RAND() * 9999 + 1000 AS INT)) AS VARCHAR) , 1 , 1 , getdate(), 'admin'   ) 
	
end

SET IDENTITY_INSERT SilabusDB_2.dbo.Docentes OFF;



SET IDENTITY_INSERT SilabusDB_2.dbo.Facultades ON 

Declare @TotalFacultades int
set @TotalFacultades = 2
set @RowActual = 0
 
while @RowActual < @TotalFacultades
begin
	set @RowActual = @RowActual + 1
	insert into SilabusDB_2.dbo.Facultades(Id , Nombre, Estado , FechaCreacion, UsuarioCreacion) 
			values((SELECT ISNULL(MAX(Id) + 1, 1) FROM SilabusDB_2.dbo.Facultades) , 'Facultad ' + (select cast(@RowActual as varchar)) , 1 , getdate(), 'admin'   ) 
	
end

SET IDENTITY_INSERT SilabusDB_2.dbo.Facultades OFF;


SET IDENTITY_INSERT SilabusDB_2.dbo.Departamentos ON 

Declare @TotalDepartamentos int
set @TotalDepartamentos = 2
set @RowActual = 0
 
while @RowActual < @TotalDepartamentos
begin
	set @RowActual = @RowActual + 1
	insert into SilabusDB_2.dbo.Departamentos(Id , Nombre, FacultadId ,Estado  ,  FechaCreacion, UsuarioCreacion) 
			values((SELECT ISNULL(MAX(Id) + 1, 1) FROM SilabusDB_2.dbo.Departamentos) , 'Departamento '
			+ (select cast(@RowActual as varchar)) , (select top 1 percent id from SilabusDB_2.dbo.Facultades order by newid())  , 1 , getdate(), 'admin'   ) 
end

SET IDENTITY_INSERT SilabusDB_2.dbo.Departamentos OFF;


SET IDENTITY_INSERT SilabusDB_2.dbo.Escuelas ON 

Declare @TotalEscuelas int
set @TotalEscuelas = 2
set @RowActual = 0
 
while @RowActual < @TotalEscuelas
begin
	set @RowActual = @RowActual + 1
	insert into SilabusDB_2.dbo.Escuelas(Id , Nombre, FacultadId ,Estado  ,  FechaCreacion, UsuarioCreacion) 
			values((SELECT ISNULL(MAX(Id) + 1, 1) FROM SilabusDB_2.dbo.Escuelas) , 'Escuelas '
			+ (select cast(@RowActual as varchar)) , (select top 1 percent id from SilabusDB_2.dbo.Facultades order by newid())  , 1 , getdate(), 'admin'   ) 
end

SET IDENTITY_INSERT SilabusDB_2.dbo.Escuelas OFF;


SET IDENTITY_INSERT SilabusDB_2.dbo.PlanEstudios ON 

Declare @TotalPlaPlanEstudios int
set @TotalPlaPlanEstudios = 3
set @RowActual = 0
 
while @RowActual < @TotalPlaPlanEstudios
begin
	set @RowActual = @RowActual + 1
	insert into SilabusDB_2.dbo.PlanEstudios(Id , IdEscuela, Estado  ,  FechaCreacion, UsuarioCreacion) 
			values((SELECT ISNULL(MAX(Id) + 1, 1) FROM SilabusDB_2.dbo.PlanEstudios) , (select top 1 percent id from SilabusDB_2.dbo.Escuelas order by newid())  , 1 , getdate(), 'admin'   ) 
end

SET IDENTITY_INSERT SilabusDB_2.dbo.PlanEstudios OFF;


SET IDENTITY_INSERT SilabusDB_2.dbo.Asignaturas ON 

Declare @TotalAsignaturas int
set @TotalAsignaturas = 30
set @RowActual = 0
 
while @RowActual < @TotalAsignaturas
begin
	set @RowActual = @RowActual + 1
	insert into SilabusDB_2.dbo.Asignaturas(Id , Nombre, Codigo, Semestre , Creditos,
	  HorasSemanalesPracticaAula,  HorasSemanalesPracticaJefe , HorasSemanalesTeoricas,HorasSemanalesVirtuales, 
	 HorasSemestralesPractica, HorasSemestralesTeorica,HorasSemestralesVirtuales ,IdDepartamento ,  IdPlanEstudio
	 , Estado  ,  FechaCreacion, UsuarioCreacion) 
	 		values((SELECT ISNULL(MAX(Id) + 1, 1) FROM SilabusDB_2.dbo.Asignaturas) , 'Asignatura  '+ (select cast(@RowActual as varchar)),  (select (CAST(RAND() * 9999 + 1000 AS INT)) AS VARCHAR) , 
			(select (CAST(RAND() * 10 + 1 AS INT)) AS VARCHAR ), (select (CAST(RAND() * 6 + 1 AS INT))) ,
			(select (CAST(RAND() * 4 + 1 AS INT))) , (select (CAST(RAND() * 4 + 1 AS INT))), (select (CAST(RAND() * 4 + 1 AS INT))),(select (CAST(RAND() * 4 + 1 AS INT))),
			(select (CAST(RAND() * 4 + 1 AS INT))),(select (CAST(RAND() * 4 + 1 AS INT))),(select (CAST(RAND() * 4 + 1 AS INT))), (select top 1 percent id from SilabusDB_2.dbo.Departamentos order by newid()), 
			(select top 1 percent id from SilabusDB_2.dbo.PlanEstudios order by newid())
			, 1 , getdate(), 'admin'   ) 
end

SET IDENTITY_INSERT SilabusDB_2.dbo.Asignaturas OFF;




SET IDENTITY_INSERT SilabusDB_2.dbo.PlanFuncionamientos ON 

Declare @TotalPlanFuncionamientos int
set @TotalPlanFuncionamientos = 1
set @RowActual = 0
 
while @RowActual < @TotalPlanFuncionamientos
begin
	set @RowActual = @RowActual + 1
	insert into SilabusDB_2.dbo.PlanFuncionamientos(Id , Anio, Semestre,  Estado  ,  FechaCreacion, UsuarioCreacion) 
	 		values((SELECT ISNULL(MAX(Id) + 1, 1) FROM SilabusDB_2.dbo.PlanFuncionamientos) , 2018, 1
			, 1 , getdate(), 'admin'   ) 
end

SET IDENTITY_INSERT SilabusDB_2.dbo.PlanFuncionamientos OFF;


SET IDENTITY_INSERT SilabusDB_2.dbo.Silabos ON 

DECLARE @IdAsignatura int
DECLARE ASIGNATURE_CURSOR CURSOR FOR  
SELECT Id FROM SilabusDB_2.dbo.Asignaturas
OPEN ASIGNATURE_CURSOR;  
FETCH NEXT FROM ASIGNATURE_CURSOR INTO @IdAsignatura;  
WHILE @@FETCH_STATUS = 0  
   BEGIN  
   insert into SilabusDB_2.dbo.Silabos(Id , AmbientePractica , AmbienteTeoria , 
								AnioAcademico, IdAsignatura , IdEstado , 
								IdPlanFuncionamiento,  Sumilla,
								EstadoAuditoria ,  FechaCreacion, UsuarioCreacion) 
	values ((SELECT ISNULL(MAX(Id)+1, 1)  FROM SilabusDB_2.dbo.Silabos) , CONCAT ((char(cast((90 - 65 )*rand() + 65 as integer))) ,  CAST(RAND() * 999 + 100 AS INT)) ,  CONCAT ((char(cast((90 - 65 )*rand() + 65 as integer))) ,  CAST(RAND() * 999 + 100 AS INT)),
	2018, @IdAsignatura , (select top 1 percent id from SilabusDB_2.dbo.Estadoes  order by newid()) , (SELECT top 1 Id FROM SilabusDB_2.dbo.PlanFuncionamientos where Estado = 1), 'sumilla' , 1 , getdate(), 'admin'  )
      FETCH NEXT FROM ASIGNATURE_CURSOR INTO @IdAsignatura;  
   END;  
CLOSE ASIGNATURE_CURSOR;  
DEALLOCATE ASIGNATURE_CURSOR;  
GO  
SET IDENTITY_INSERT SilabusDB_2.dbo.Silabos OFF;


SET IDENTITY_INSERT SilabusDB_2.dbo.SilaboDivisiones ON 

DECLARE @IdSilabo int
DECLARE @IdDivision int
DECLARE SILABO_CURSOR CURSOR FOR  
SELECT Id FROM SilabusDB_2.dbo.Silabos
OPEN SILABO_CURSOR;  
FETCH NEXT FROM SILABO_CURSOR INTO @IdSilabo;  
WHILE @@FETCH_STATUS = 0  
   BEGIN  
		DECLARE DIVISION_CURSOR CURSOR FOR  
		SELECT Id FROM SilabusDB_2.dbo.Divisiones
		OPEN DIVISION_CURSOR;  
		FETCH NEXT FROM DIVISION_CURSOR INTO @IdDivision;  
		WHILE @@FETCH_STATUS = 0  
			BEGIN
				insert into SilabusDB_2.dbo.SilaboDivisiones(Id ,IdSilabo , IdDivision , estado ,  FechaCreacion, UsuarioCreacion) 
				values ((SELECT ISNULL(MAX(Id)+1, 1)  FROM SilabusDB_2.dbo.SilaboDivisiones) , @IdSilabo, @IdDivision , 1 , getdate(), 'admin'  )
				FETCH NEXT FROM DIVISION_CURSOR INTO @IdDivision;  
			END;
		CLOSE DIVISION_CURSOR;  
		DEALLOCATE DIVISION_CURSOR;
      FETCH NEXT FROM SILABO_CURSOR INTO @IdSilabo;  
   END;  
CLOSE SILABO_CURSOR;  
DEALLOCATE SILABO_CURSOR;  
GO  
SET IDENTITY_INSERT SilabusDB_2.dbo.SilaboDivisiones OFF;


