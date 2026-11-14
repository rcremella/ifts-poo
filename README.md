# ifts-poo

Desarrollo de Sistemas Orientado a Objetos - Proyecto Integrador

Sistema de gestión para un club deportivo desarrollado en C# con Windows Forms y MySQL.

## Requisitos

- Windows
- Visual Studio 2026 con la carga de trabajo "Desarrollo de escritorio de .NET"
- .NET 10

## Cómo abrir el proyecto

1. Clonar el repositorio:

```bash
git clone https://github.com/rcremella/ifts-poo.git
```

2. Abrir `proyectoClub.slnx`.
3. Configurar la cadena de conexión (ver [Configurar la conexión a la base de datos](#configurar-la-conexión-a-la-base-de-datos)).
4. Ejecutar con F5.

## Configurar la conexión a la base de datos

La cadena de conexión no está en el código: se lee de los **user secrets** de .NET con la clave `ConnectionStrings:Club`. Los secretos se guardan en tu máquina (fuera del repositorio), así que cada integrante tiene que cargarlos una vez después de clonar.

El proyecto ya tiene un `UserSecretsId` en `proyectoClub.csproj`, así que no hace falta correr `dotnet user-secrets init`.

Desde la carpeta del proyecto (donde está `proyectoClub.csproj`), ejecutar:

```bash
dotnet user-secrets set "ConnectionStrings:Club" "user=USUARIO;host=HOST;port=PUERTO;database=BASE;pwd=CONTRASEÑA"
```

Reemplazar `USUARIO`, `HOST`, `PUERTO`, `BASE` y `CONTRASEÑA` con los datos que se comparten por privado en el grupo (no subirlos al repositorio).

Para comprobar que quedó guardado:

```bash
dotnet user-secrets list
```

También se puede hacer desde Visual Studio: clic derecho sobre el proyecto → **Administrar secretos de usuario** y completar el `secrets.json` así:

```json
{
  "ConnectionStrings": {
    "Club": "user=USUARIO;host=HOST;port=PUERTO;database=BASE;pwd=CONTRASEÑA"
  }
}
```

Si falta el secreto, la aplicación lanza el error `Falta ConnectionStrings:Club en los secretos de usuario.`

## Estructura

- `Program.cs`: punto de entrada del sistema.
- `Datos/Conexion.cs`: configuración de conexión a MySQL.
- `Datos/Validador.cs`: validación del documento, compartida por los formularios.
- `Datos/Mensajes.cs`: aviso de error de conexión, compartido por los formularios.

### Formularios (`Formularios/`)

- `FrmLogin`: pantalla de inicio de sesión.
- `FrmOpciones`: menú principal.
- `FrmRegistrarCliente`: alta de socios y no socios.
- `FrmPagar`: cobro de la cuota (se busca a la persona por documento).
- `FrmEntregarCarnet`: búsqueda del carnet de un socio. Solo se entrega si la cuota está paga.
- `FrmListarVencimientos`: grilla con los socios que vencen hoy o ya tienen la cuota vencida.

### Entidades (`Entidades/`)

- `Persona`: clase base con los datos de cualquier persona y el acceso a la tabla `persona`.
- `Socio` y `noSocio`: heredan de `Persona`. Cada una guarda sus datos en su tabla (`cliente` y `no_cliente`) con `registrarCliente`.
- `Usuario`: usuario del sistema, valida el login.
- `Vencimiento`: consulta de los vencimientos de hoy y los atrasados.

## Base de datos

Las tablas que usa el sistema son `persona`, `cliente` (socios), `no_cliente`, `carnet`, `pago`, `precio` y `usuario`. El script de la carpeta `DB` puede estar desactualizado respecto a la base que usa el grupo, así que ante cualquier duda hay que confirmar el esquema real.

## Trabajo en grupo

Antes de empezar:

```bash
git pull
```

Crear una rama:

```bash
git checkout -b nombre-rama
```

Ejemplo:

```bash
git checkout -b mejorar-ui
```

Guardar cambios:

```bash
git add .
git commit -m "Descripción del cambio"
git push -u origin nombre-rama
```

Evitar que dos personas trabajen sobre el mismo formulario al mismo tiempo.

## Notas

Las carpetas `bin` y `obj` son generadas automáticamente por Visual Studio y no se suben al repositorio. Fueron añadidas al archivo .gitignore para que GitHub los ignore.
