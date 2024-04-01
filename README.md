# Instrucciones para ejecutar la aplicación

Esta aplicación es una API REST desarrollada en .NET Core y C# que gestiona usuarios almacenados en una base de datos MySQL. A continuación se detallan los pasos para ejecutarla en JetBrains Rider y acceder a su documentación en Swagger.

## Requisitos previos

- Tener instalado MySQL Server.
- Tener acceso a JetBrains Rider.

## Configuración de la base de datos

1. Abra MySQL Workbench u otra herramienta de administración de bases de datos.
2. Ejecute el script `create_database.sql` proporcionado en la raíz del proyecto para crear la base de datos y la tabla necesaria.
3. Modifique el archivo `appsettings.json` en el proyecto WebApi para que la cadena de conexión apunte a su instancia de MySQL.

## Ejecución de la aplicación en JetBrains Rider

1. Abra el proyecto en JetBrains Rider.
2. Asegúrese de que la configuración de ejecución esté apuntando al proyecto WebApi.
3. Ejecute la aplicación.

## Acceso a Swagger

Una vez que la aplicación esté en funcionamiento, puede acceder a la documentación de la API utilizando Swagger:

1. Abra un navegador web.
2. Navegue a la dirección `https://localhost:{puerto}/swagger/index.html`, donde `{puerto}` es el puerto en el que se está ejecutando la aplicación (por defecto, el puerto es 5237).
3. Se abrirá la interfaz de Swagger, donde puede explorar y probar los endpoints de la API.

