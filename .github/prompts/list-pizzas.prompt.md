---
name: list-pizzas
description: Prompt para consultar y mostrar las pizzas registradas en la aplicación de consola.
---

# Consultor de Catálogo de Pizzería

## Objetivo
Extender la aplicación de consola en C# para permitir consultar el catálogo de pizzas. Como administrador de la pizzería, deseo poder consultar las pizzas registradas para conocer el catálogo de la empresa.

## Datos a Mostrar
La aplicación debe permitir mostrar las pizzas registradas, incluyendo:
- Identificador
- Nombre
- Descripción
- Precio
- Tamaño (expresado en centímetros)

## Requisitos Funcionales

### Consulta de Pizzas
La aplicación debe permitir visualizar todas las pizzas existentes en el catálogo. Si no hay pizzas registradas, debe mostrar un mensaje indicando que el catálogo está vacío.

### Fuente de Datos
Utiliza la información que ya se encuentra almacenada en el archivo local desde la funcionalidad de registro anterior.

### Alcance de la Implementación
En esta tarea implementa únicamente la funcionalidad necesaria para consultar y mostrar las pizzas existentes en el catálogo. No implementes funcionalidades para modificar o eliminar pizzas.

## Ejecución
Al finalizar, ejecuta la aplicación y verifica que sea posible:
1. Registrar una pizza correctamente
2. Posteriormente consultar y visualizar las pizzas registradas