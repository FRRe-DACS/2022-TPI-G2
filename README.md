# TPI-FanturApp
Trabajo Practico Integrador de la materia Desarrollo de Aplicaciones Cliente-Servidor 2022 UTN.

Aplicacion de venta y administracion de paquetes turisticos.

FanturApp

Requerimientos:

Visual Studio 2022 (con los siguientes complementos y paquetes)
  Web y Nube: Desarrollo de ASP.NET y Web
  Otros conjuntos de herramientas: Almacenamiento y procesamiento de datos
  
NuGet Packages: 
  AutoMapper
  AutoMapper.Extensiones.Microsoft.DependencyInjection
  Microsoft.EntityFrameworkCore.Design
  Microsoft.EntityFrameworkCore.SqlServer
  Microsoft.EntityFrameworkCore.Tools
  Swashbuckle.AspNetCore
  
 SQL Express:
  Para vincular la aplicacion con su servidor sql local, se debe ir al archivo appsettings.json ubicado en la raiz de
  FanturApp.Services y modificar el string de conexion a partir de 'Data Source=' en el campo "DefaultConnection" por el de su local.
  
  {
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=LAMAMI\\SQLEXPRESS;Initial Catalog=FanturDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
  },
 
  Luego se debe agregar una migracion desde el NugetTerminal estando posicionado en la capa DataAccess: Add-migration nuevamigracion
  y por ultimo correr un update de la base de datos para que esta se cree: update-database
  
  Luego si su version de visual studio no le indica que deba instalarse ningun componente adicional, solo queda correr la app y se le abrira una venta de navegador
  con Swagger donde estaran expuestos los endpoints y podran probarse.
