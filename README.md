# Taller Franky — Gestión de reparación de barcos

Aplicación de escritorio en **C# .NET** desarrollada como proyecto de la materia **Laboratorio de Computación II** (Tecnicatura Superior en Programación, UTN).

Simula la gestión de un taller naval: permite dar de alta barcos, consultarlos, modificarlos, eliminarlos, ejecutar el proceso de reparación y persistir la información tanto en una base de datos MySQL como en archivos XML.

El objetivo del trabajo fue aplicar **programación orientada a objetos** de punta a punta en una solución con arquitectura en capas, sumando serialización, manejo de excepciones y acceso a datos.

---

## Tecnologías

- C# / .NET Framework 4.7.2
- Windows Forms
- ADO.NET + MySQL (`MySql.Data`)
- Serialización XML (`System.Xml.Serialization`)
- Visual Studio

---

## Estructura de la solución

```
SP_LABORATORIO_II_A221_Diez_Natalia.sln
│
├── Entidades/          Biblioteca de clases: modelo de dominio y persistencia
│   ├── Barco.cs            Clase abstracta base
│   ├── Pirata.cs           Clase derivada
│   ├── Marina.cs           Clase derivada
│   ├── Taller.cs           Colección de barcos y lógica de reparación
│   ├── EOperacion.cs       Enumerados (EOperacion, ETipoBarco)
│   ├── IArchivos.cs        Interfaz de persistencia en archivos
│   ├── XmlManager.cs       Implementación de IArchivos (serialización XML)
│   ├── AccesoDatos.cs      Capa de acceso a MySQL (ADO.NET)
│   └── GenerarRandom.cs    Clase estática de utilidades
│
├── TallerFrankyUI/     Aplicación Windows Forms
│   ├── FrmPrincipal.cs     Menú principal
│   ├── FrmBarco.cs         Alta y modificación de barcos
│   ├── FrmMostrar.cs       Listado en DataGridView, modificar y eliminar
│   └── FrmReparacion.cs    Proceso de reparación
│
└── PruebaConsola/      Proyecto de consola usado para probar las entidades
```

La separación en tres proyectos permite que la lógica de negocio viva en una biblioteca de clases independiente de la interfaz, y que pueda consumirse tanto desde Windows Forms como desde consola.

---

## Conceptos de POO aplicados

| Concepto | Dónde |
|---|---|
| **Clase abstracta** | `Barco`, con atributos protegidos y constructores sobrecargados |
| **Herencia** | `Pirata` y `Marina` heredan de `Barco` |
| **Polimorfismo** | `CalcularCosto()` y `Tripulacion` son abstractos y cada derivada los resuelve con su propia regla |
| **Sobrescritura** | `ToString()` reescrito en la base y extendido en las derivadas con `base.ToString()` |
| **Interfaces** | `IArchivos` define `Guardar` / `Leer`; `XmlManager` la implementa |
| **Encapsulamiento** | Atributos `protected` / `private` expuestos mediante propiedades |
| **Enumerados** | `EOperacion` (tipo de reparación) y `ETipoBarco` |
| **Clases estáticas** | `GenerarRandom` y `AccesoDatos` |
| **Manejo de excepciones** | `try / catch` en serialización, acceso a datos y validación de formularios |

---

## Funcionalidades

- **Alta de barcos** con validación de campos y selección de tipo (Pirata / Marina) y operación a realizar.
- **Listado** de los barcos cargados en un `DataGridView`, con modificación y baja del registro seleccionado (con confirmación previa).
- **Reparación**: recorre los barcos del taller, calcula el costo de forma polimórfica según el tipo y actualiza su estado.
- **Persistencia en MySQL** mediante ADO.NET con operaciones ABM completas (`INSERT`, `SELECT`, `UPDATE`, `DELETE`) sobre la tabla `taller`, usando **consultas parametrizadas** para evitar inyección SQL.
- **Serialización XML** de la lista de barcos, para exportar y recuperar el estado del taller desde archivo.
- **Confirmación de cierre** de la aplicación desde el evento `FormClosing`.

---

## Base de datos

La aplicación se conecta a una base MySQL local con una tabla `taller`:

| Campo | Descripción |
|---|---|
| `nombre` | Nombre del barco |
| `costo` | Costo de la reparación |
| `tipo` | Pirata / Marina |
| `operacion` | Operación a realizar |
| `tripulacion` | Cantidad de tripulantes |
| `estado_reparacion` | Reparado / sin reparar |

La cadena de conexión se define en el constructor estático de `AccesoDatos`. Para ejecutar el proyecto hay que ajustarla a la configuración local del servidor MySQL.

---

## Cómo ejecutarlo

1. Clonar el repositorio.
2. Abrir `SP_LABORATORIO_II_A221_Diez_Natalia.sln` en Visual Studio.
3. Restaurar los paquetes NuGet (`MySql.Data`).
4. Crear la base de datos y la tabla `taller` en MySQL.
5. Ajustar la cadena de conexión en `Entidades/AccesoDatos.cs`.
6. Establecer `TallerFrankyUI` como proyecto de inicio y ejecutar.

---

## Documentación

Las clases y métodos están documentados con **comentarios XML** (`<summary>`, `<param>`, `<returns>`), de modo que IntelliSense muestre la descripción de cada miembro.

En el repositorio se incluye además el enlace al video de defensa del proyecto.

---

## Autora

**Natalia Diez** — Tecnicatura Superior en Programación, UTN
[GitHub](https://github.com/Nataliadiez) · [Portfolio](https://natalia-diez-portfolio.vercel.app)
