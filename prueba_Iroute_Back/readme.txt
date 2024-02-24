Cadena de conexión (Consola de paquetes nutGet):

Scaffold-DbContext 'Server=localhost,2526;Initial Catalog=prueba_Iroute_DB;Persist Security Info=False;User ID=sa;Password=root1992*;MultipleActiveResultSets=False;Encrypt=false;TrustServerCertificate=False;Connection Timeout=30;' Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models/ -f -NoPluralize



Dependencias: EntityFrameworkCore
EntityFrameworkCore.SqlServer
EntityFrameworkCore.Tools



Comando para levantar servicio sql contenedor docker (Ejecutar en poswershell):
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=root1992*" -p 2526:2526 -d mcr.microsoft.com/mssql/server:2022-latest



Script base de datos (Database first):
create database prueba_Iroute_DB;
use prueba_Iroute_DB;
create table clienteEntity
(

	id int identity not null,
	identificacion varchar(10) not null,
	primerNombre varchar(50) not null,	
	segundoNombre varchar(50),
	apellidos varchar(10) not null,
	mail varchar(50) not null,
	estado bit not null,
	primary key(id)
);
