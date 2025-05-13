# Configuraci�n para ejecuci�n

Instala Docker Desktop o por medio de WSL a una distribuci�n Unix e instala docker engine y docker-compose.

En el directorio raiz dentro de API ubicaras el archivo docker-compose donde deber�s especificar tus credenciales de base de datos.

### Docker Desktop
Ubicate desde la terminal en la raiz del proyecto:

	1 Redireccionate a la carpeta/proyecto API: �cd ./api�
	2. Ejecuta el comando �docker-compose run�
### Docker por medio de WSL
	1. Asegurate de tener activada la conexi�n WSL2 en windows
	2. Copia el contenido en ./API/docker-compose.yml y pegalo en un directorio de tu servidor Unix:
		- �touch docker-compose.yml�
		- �vi docker-compose.yml�
		- Una vez pegadp... presiona **ESC** y digita �:wq� y enter para guardar y salir
	3. Desde la misma ubiacion ejecuta �docker-compose run� o �docker compose run�
	4. Verifica la descarga e instalacion con �docker ps�

	**Conexi�n con tu SGDB o con el proyecto**
	En tu distribuacion Unix, ejecuta el comando: �ip addr show eth0�, encuentra la ip que se encuentra alado de "inex 192.168._._/20". Esa ser� la ip que te permitira conectar como host.

### Conexi�n de Base de datos Mysql con el proyecto

Establece tus credenciales de acceso de base de datos dentro del archivo �.env� ubicado en �./API�.
(Primero verifica con tu SGDB la correcta conexi�n de la base de datos)

### Ejecuci�n
Primero realizamos la migracion de las entidades, para ello ejecutamos el siguiente comando en el directorio ra�z del proyecto:

	dotnet ef migrations add EjecucionInicial --project Infraestructura --startup-project API

Una vez realizado la migraci�n aplica los cambios a la base de datos por medio de:

	dotnet ef database update --project API

Ejecuta con: 

	dotnet run --project API

### Variables de entorno para Autenticaci�n

Establece tu configuraci�n para la generaci�n del token de autenticidad

	JWT_SECRET	-> clave secreta
	JWT_ISSUE	-> Url del Host
	JWT_URL_AUDIENCE=	-> Url de emisi�n de solicitud
	JWT_TIME_EXPIRATION=	-> tiempo de v�lidez