# EntregasADomicilio

# Objetivo

En el ambito laboral la mayoria de proyectos donde se trabajan ya estan iniciados o son platillas. En este proyecto tendra construido algunos modulos y otros se completaran para que vean la integración de elementos y creación de modulos.

Lucky sushi es un restaurant de comida japonesa, el cual tiene una app para que realices tu pedido, el pago es contraentrega, ya sea en efectivo o pago con tarjeta.

El sistema cuenta a grandes rasgos con os siguientes componentes.

**App movil**, donde el usuario realiza el pedido, previo registro de datos generales y domicilio.

**Página administrativa** donde se gestionan los platillos y promociones.

**Página de comandas**, donde los encargados de cocina ven los pedidos y cambian es estatus del pedido y se indica al repartidor la entrega y el metodo de pago.
## Diagrama del sistema

```mermaid
flowchart TD
    A[App movil] -->B[Api Rest]
    B --> C[Logica de negocio]
    C --> D[(Base de datos)]
    E[Página de administracion]-->C
    F[Página de comandas] -->C
    G[Página] --> C
```

## Entidad relaciones

```mermaid
erDiagram
    
    Categoria ||--|{ Platillo : contains
    Pedido ||--|{ DetalleDePedido : contains
    DetalleDePedido ||--|{ Platillo : contains
    Pedido ||--|{ Cliente : contains
    Cliente ||--|{ DireccionDeEntrega : contains
```

## Herramientas a usar

Github/Git para respaldar el codigo y hacer integraciones

Visual Studio IDE, para el desarrollo del sistema

SqlServer, motor de base de datos

Management Studio, visor de base de datos

Docker, administrador de imagenes y contenedores

## Instalación del Admin

De permisos a la carpeta de wwwroot
Click derecho en la carpeta
Pestaña de seguridad
De permiso de escritura y modificar al usuario IIS_...

## Docker para Seq

docker run --name entregas-a-domicilio-seq -d --restart unless-stopped -e ACCEPT_EULA=Y -v C:\Users\vmartinez\Documents\EntregasADomiclioSeq:/data -p 8081:80 datalust/seq

Instalar Serilog
	  Serilog
	  Serilog.AspNetCore
	  Serilog.Enrichers.Process
	  Serilog.Settings.Configuration	  
	  Serilog.Sinks.Seq

Agregar en el program
'''
builder.Host.UseSerilog((hostContext, services, configuration) =>
{
    configuration.ReadFrom.Configuration(hostContext.Configuration);
});
'''

## Inspector de mensajes

Agregue en el program el middleware

app.UseMiddleware<RequestInspectorMiddleware>();

y 

builder.Services.AddRequestInpector();

Agregue la cadena de conexion

'''
 "ConnectionStrings": {   
    "RequestInspector": "Data Source=192.168.1.86; Initial Catalog=EntregasADomicilioLog; Persist Security Info=True;User ID=sa;Password=Macross#2012; TrustServerCertificate=True;"
  },
'''


prueba
2023/07/26