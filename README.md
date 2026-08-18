# HotPizza - Administrador de Catálogo de Pizzería

Una aplicación de consola en C# para administrar el catálogo de una pizzería, permitiendo registrar nuevas pizzas y consultar el inventario de forma sencilla y eficiente.

## Características

✨ **Funcionalidades principales:**
- 📝 **Registrar pizzas** - Agregar nuevas pizzas al catálogo con validaciones
- 🔍 **Consultar pizzas** - Ver todas las pizzas registradas en un formato de tabla
- 💾 **Persistencia de datos** - Almacenamiento en archivo JSON local
- ✅ **Validaciones automáticas** - Verificación de datos antes de registrar

## Requisitos

- **.NET 8.0** o superior
- **Windows/Linux/macOS** (multiplataforma)
- **Visual Studio Code** o **Visual Studio** (recomendado)

## Instalación

### 1. Clonar el repositorio
```bash
git clone <repository-url>
cd HotPizzaV2
```

### 2. Restaurar dependencias
```bash
dotnet restore
```

### 3. Compilar el proyecto
```bash
dotnet build
```

## Ejecución

### Ejecutar la aplicación
```bash
dotnet run
```

La aplicación mostrará un menú interactivo con las siguientes opciones:

```
=== Administrador de Catálogo de Pizzería ===

Opciones:
1. Registrar nueva pizza
2. Consultar pizzas registradas
3. Salir
```

## Uso

### Opción 1: Registrar Nueva Pizza

Seleccione la opción `1` e ingrese los datos solicitados:

```
Nombre: Margherita
Descripción: Pizza clásica con tomate y mozzarella
Precio: 12.99
Tamaño (20, 30 o 40 cm): 30

✓ Pizza registrada exitosamente con ID: 1
```

### Validaciones de Registro

La aplicación valida automáticamente los datos ingresados antes de registrar:

| Campo | Regla de Validación | Ejemplo de Error |
|-------|-------------------|------------------|
| **Nombre** | No puede estar vacío o contener solo espacios | "El nombre de la pizza no puede estar vacío." |
| **Precio** | Debe ser mayor a cero (> 0) | "El precio debe ser mayor a cero." |
| **Tamaño** | Solo se aceptan: 20, 30 o 40 centímetros | "El tamaño debe ser 20, 30 o 40 centímetros." |

**Importante**: Las pizzas con datos inválidos **NO se registran** en el catálogo ni se guardan en el archivo de datos.

#### Ejemplos de Validaciones

**1. Nombre Vacío**
```
Nombre: [presionar Enter sin ingresar nada]
Error: El nombre de la pizza no puede estar vacío.
```

**2. Precio Inválido**
```
Precio: 0
Error: El precio debe ser mayor a cero.

Precio: -10
Error: El precio debe ser mayor a cero.
```

**3. Tamaño Inválido**
```
Tamaño: 25
Error: El tamaño debe ser 20, 30 o 40 centímetros.

Tamaño: 50
Error: El tamaño debe ser 20, 30 o 40 centímetros.
```

**4. Datos Válidos**
```
Nombre: Hawaiana
Descripción: Pizza tropical con piña y jamón
Precio: 15.99
Tamaño: 40

✓ Pizza registrada exitosamente con ID: 1
```

### Opción 2: Consultar Pizzas Registradas

Seleccione la opción `2` para ver el catálogo completo:

```
--- Pizzas Registradas ---

ID    Nombre               Descripción                    Precio     Tamaño    
---------------------------------------------------------------------------
1     Margherita           Pizza clásica con tomate y... $12.99     30 cm
2     Pepperoni            Pizza con pepperoni crujiente $14.50     40 cm
3     Vegetariana          Pizza con verduras frescas    $11.99     30 cm
```

Si no hay pizzas registradas, verá:
```
No hay pizzas registradas en el catálogo.
```

### Opción 3: Salir

Seleccione la opción `3` para cerrar la aplicación.

## Estructura del Proyecto

```
HotPizzaV2/
├── HotPizza.csproj          # Configuración del proyecto
├── Program.cs               # Punto de entrada y lógica de menú
├── Models/
│   └── Pizza.cs            # Modelo de datos de Pizza
├── Services/
│   └── PizzaRepository.cs   # Gestión de datos y persistencia
├── .github/
│   └── prompts/            # Prompts personalizados para Copilot
│       ├── create-pizza.prompt.md
│       ├── list-pizzas.prompt.md
│       └── validate-pizzas.prompt.md
├── .gitignore              # Configuración de git
└── README.md               # Este archivo
```

## Persistencia de Datos

Los datos se almacenan en un archivo JSON local llamado `pizzas.json` ubicado en el directorio de ejecución:

```json
[
  {
    "Id": 1,
    "Nombre": "Margherita",
    "Descripcion": "Pizza clásica con tomate y mozzarella",
    "Precio": 12.99,
    "Tamanio": 30
  },
  {
    "Id": 2,
    "Nombre": "Pepperoni",
    "Descripcion": "Pizza con pepperoni crujiente",
    "Precio": 14.50,
    "Tamanio": 40
  }
]
```

## Modelo de Datos

### Pizza

```csharp
public class Pizza
{
    public int Id { get; set; }              // Identificador único (auto-generado)
    public string Nombre { get; set; }       // Nombre de la pizza
    public string Descripcion { get; set; }  // Descripción detallada
    public decimal Precio { get; set; }      // Precio en moneda local
    public int Tamanio { get; set; }         // Tamaño en centímetros
}
```

## Ejemplos de Uso

### Ejemplo 1: Registrar una Pizza Válida
```
Opción: 1
Nombre: Hawaiana
Descripción: Pizza tropical con piña y jamón
Precio: 13.50
Tamaño: 40

✓ Pizza registrada exitosamente con ID: 1
```

### Ejemplo 2: Error de Validación - Precio Inválido
```
Opción: 1
Nombre: 4Quesos
Descripción: Mezcla de cuatro quesos
Precio: -5
Tamaño: 30

Error: El precio debe ser mayor a cero.
```

### Ejemplo 3: Error de Validación - Tamaño Inválido
```
Opción: 1
Nombre: Clásica
Descripción: La pizza clásica
Precio: 10.00
Tamaño: 25

Error: El tamaño debe ser 20, 30 o 40 centímetros.
```

## Próximas Características

Características planeadas para futuras versiones:
- 🔄 Actualizar datos de pizzas existentes
- 🗑️ Eliminar pizzas del catálogo
- 🔎 Buscar/filtrar pizzas por criterios (nombre, precio, tamaño)
- 📊 Estadísticas del catálogo
- 🎨 Interfaz gráfica mejorada

## Documentación de Validaciones

Para información detallada sobre las validaciones implementadas, incluyendo:
- Descripción técnica de cada validación
- Casos de prueba ejecutados
- Resultados de validación
- Integridad de datos

Consulte: [VALIDATIONS_REPORT.md](VALIDATIONS_REPORT.md)

## Desarrollo

### Compilar solo
```bash
dotnet build
```

### Ejecutar tests (cuando estén disponibles)
```bash
dotnet test
```

### Limpiar artefactos de compilación
```bash
dotnet clean
```

## Contribución

Las contribuciones son bienvenidas. Para cambios importantes:
1. Cree una rama con su característica (`git checkout -b feature/AmazingFeature`)
2. Realice sus cambios
3. Haga commit (`git commit -m 'Add AmazingFeature'`)
4. Envíe un push a la rama (`git push origin feature/AmazingFeature`)
5. Abra un Pull Request

## Licencia

Este proyecto está bajo licencia MIT. Consulte el archivo `LICENSE` para más detalles.

## Soporte

Para reportar problemas o sugerencias:
1. Abra un issue en el repositorio
2. Proporcione detalles sobre el error o la sugerencia
3. Incluya pasos para reproducir el problema (si aplica)

## Notas Técnicas

- **Framework**: .NET 8.0
- **Lenguaje**: C# 12
- **Persistencia**: JSON (System.Text.Json)
- **Patrón**: Repository Pattern
- **IDE Recomendado**: Visual Studio Code o Visual Studio 2022+

## Changelog

### Versión 1.0.0 (2026-08-18)
- ✨ Funcionalidad inicial de registro de pizzas
- ✨ Consulta de catálogo
- ✨ Validaciones de datos
- ✨ Persistencia en JSON
- 📚 Documentación completa

---

**Desarrollado con ❤️ para administradores de pizzerías**
