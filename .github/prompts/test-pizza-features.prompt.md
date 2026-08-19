---
name: test-pizza-features
description: "Analiza y completa las pruebas unitarias de las funcionalidades del catálogo de pizzas."
argument-hint: "Requisitos adicionales de pruebas (opcional)"
agent: agent
---

# Pruebas del Catálogo de Pizzería

## Objetivo
La aplicación ya cuenta con pruebas unitarias. Analiza las pruebas existentes y agrega únicamente las pruebas necesarias para verificar el comportamiento de las funcionalidades implementadas hasta ahora.

## Cobertura mínima
Las pruebas deben verificar como mínimo:
- El registro correcto de una pizza.
- La consulta de las pizzas registradas.
- El rechazo de pizzas con nombre vacío o que contenga únicamente espacios.
- El rechazo de precios menores o iguales a cero.
- El rechazo de tamaños distintos de 20, 30 o 40 centímetros.
- La persistencia de las pizzas registradas.

## Reglas de implementación
- Localiza el proyecto de pruebas, la implementación de producción y los patrones de prueba existentes antes de editar.
- Reutiliza el framework, las convenciones y los auxiliares de prueba ya presentes en el repositorio.
- Añade solo las pruebas faltantes o ajusta pruebas que sean incorrectas; no modifiques las funcionalidades de producción para que las pruebas pasen.
- Aísla la persistencia para que las pruebas no dependan de datos previos ni modifiquen archivos de producción.
- Para cada comportamiento inválido, comprueba tanto el rechazo como que la pizza no quede registrada.
- Si detectas un comportamiento incorrecto en la aplicación, no lo corrijas: indícalo claramente con la prueba que lo evidencia y el resultado observado.
- Considera requisitos adicionales proporcionados por el usuario: ${input:requisitos adicionales}.

## Validación final
1. Ejecuta las pruebas unitarias del proyecto.
2. Confirma cuáles pruebas se agregaron o modificaron y el resultado de la ejecución.
3. Si alguna prueba falla debido a un defecto de producción, explica el defecto sin modificar el código de la aplicación.