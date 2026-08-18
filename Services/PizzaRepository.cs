using System.Text.Json;
using HotPizza.Models;

namespace HotPizza.Services;

public class PizzaRepository
{
    private readonly string _dataFilePath;
    private List<Pizza> _pizzas = new();

    public PizzaRepository(string dataFilePath = "pizzas.json")
    {
        _dataFilePath = dataFilePath;
        LoadData();
    }

    public int CreatePizza(string nombre, string descripcion, decimal precio, int tamanio)
    {
        // Validación: nombre
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new ArgumentException("El nombre de la pizza no puede estar vacío.");
        }

        // Validación: precio
        if (precio <= 0)
        {
            throw new ArgumentException("El precio debe ser mayor a cero.");
        }

        // Validación: tamaño
        if (tamanio != 20 && tamanio != 30 && tamanio != 40)
        {
            throw new ArgumentException("El tamaño debe ser 20, 30 o 40 centímetros.");
        }

        var newId = _pizzas.Any() ? _pizzas.Max(p => p.Id) + 1 : 1;

        var pizza = new Pizza
        {
            Id = newId,
            Nombre = nombre,
            Descripcion = descripcion,
            Precio = precio,
            Tamanio = tamanio
        };

        _pizzas.Add(pizza);
        SaveData();

        return newId;
    }

    public List<Pizza> GetAllPizzas()
    {
        return _pizzas.ToList();
    }

    private void SaveData()
    {
        try
        {
            var json = JsonSerializer.Serialize(_pizzas, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_dataFilePath, json);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error al guardar los datos: {ex.Message}", ex);
        }
    }

    private void LoadData()
    {
        try
        {
            if (File.Exists(_dataFilePath))
            {
                var json = File.ReadAllText(_dataFilePath);
                _pizzas = JsonSerializer.Deserialize<List<Pizza>>(json) ?? new List<Pizza>();
            }
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error al cargar los datos: {ex.Message}", ex);
        }
    }
}
