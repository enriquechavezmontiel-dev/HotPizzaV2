---
name: validate-pizzas
description: Prompt para agregar validaciones en el registro de pizzas en la aplicación de consola.
---

# Validador de Catálogo de Pizzería

## Objetivo
Extender la aplicación de consola en C# para implementar validaciones de datos al registrar pizzas. Como administrador de la pizzería, necesito que los datos de las pizzas cumplan con las reglas establecidas para el catálogo.

## Reglas de Validación

### Nombre de la Pizza
- No se permiten pizzas con nombre vacío o que contenga únicamente espacios.

### Precio
- No se permiten precios menores o iguales a cero.

### Tamaño
- No se permiten tamaños distintos de **20, 30 o 40 centímetros**.

## Requisitos Funcionales

### Validación de Entrada
Cuando alguno de los datos no cumpla con estas reglas, la aplicación debe informar al usuario del error y no registrar la pizza.

### Integridad Funcional
No modifiques las funcionalidades existentes para registrar y consultar pizzas.

### Persistencia de Datos
Continúa utilizando el almacenamiento en archivo local.

## Ejecución
Al finalizar, ejecuta la aplicación y verifica que las validaciones funcionen correctamente para:
- Datos válidos (se registren correctamente)
- Datos no válidos (se rechacen con mensajes de error claros)