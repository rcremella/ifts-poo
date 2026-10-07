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
3. Ejecutar con F5.

## Estructura

- `Program.cs`: punto de entrada del sistema.
- `frmLogin`: pantalla de inicio de sesión.
- `frmOpciones`: menú principal.
- `frmRegistrarCliente`: alta de socios.
- `Persona.cs` y `Usuario.cs`: entidades del sistema.
- `Conexion.cs`: configuración de conexión a MySQL.

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
