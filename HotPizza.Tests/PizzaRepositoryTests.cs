using HotPizza.Services;
using Xunit;

namespace HotPizza.Tests;

public sealed class PizzaRepositoryTests : IDisposable
{
    private readonly string _dataFilePath = Path.Combine(
        Path.GetTempPath(),
        $"hotpizza-tests-{Guid.NewGuid():N}.json");

    [Fact]
    public void CreatePizza_WithValidData_RegistersPizzaAndReturnsId()
    {
        var repository = CreateRepository();

        var pizzaId = repository.CreatePizza("Margarita", "Tomate y mozzarella", 12.50m, 30);

        var registeredPizza = Assert.Single(repository.GetAllPizzas());
        Assert.Equal(1, pizzaId);
        Assert.Equal(pizzaId, registeredPizza.Id);
        Assert.Equal("Margarita", registeredPizza.Nombre);
        Assert.Equal("Tomate y mozzarella", registeredPizza.Descripcion);
        Assert.Equal(12.50m, registeredPizza.Precio);
        Assert.Equal(30, registeredPizza.Tamanio);
    }

    [Fact]
    public void GetAllPizzas_ReturnsAllRegisteredPizzas()
    {
        var repository = CreateRepository();
        repository.CreatePizza("Margarita", "Tomate y mozzarella", 12.50m, 30);
        repository.CreatePizza("Pepperoni", "Pepperoni y queso", 14.00m, 40);

        var pizzas = repository.GetAllPizzas();

        Assert.Collection(
            pizzas,
            pizza => Assert.Equal("Margarita", pizza.Nombre),
            pizza => Assert.Equal("Pepperoni", pizza.Nombre));
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void CreatePizza_WithEmptyOrWhitespaceName_ThrowsAndDoesNotRegister(string nombre)
    {
        var repository = CreateRepository();

        var exception = Assert.Throws<ArgumentException>(
            () => repository.CreatePizza(nombre, "Descripción", 10m, 20));

        Assert.Equal("El nombre de la pizza no puede estar vacío.", exception.Message);
        Assert.Empty(repository.GetAllPizzas());
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-0.01)]
    public void CreatePizza_WithNonPositivePrice_ThrowsAndDoesNotRegister(decimal precio)
    {
        var repository = CreateRepository();

        var exception = Assert.Throws<ArgumentException>(
            () => repository.CreatePizza("Margarita", "Descripción", precio, 20));

        Assert.Equal("El precio debe ser mayor a cero.", exception.Message);
        Assert.Empty(repository.GetAllPizzas());
    }

    [Theory]
    [InlineData(0)]
    [InlineData(21)]
    [InlineData(50)]
    public void CreatePizza_WithUnsupportedSize_ThrowsAndDoesNotRegister(int tamanio)
    {
        var repository = CreateRepository();

        var exception = Assert.Throws<ArgumentException>(
            () => repository.CreatePizza("Margarita", "Descripción", 10m, tamanio));

        Assert.Equal("El tamaño debe ser 20, 30 o 40 centímetros.", exception.Message);
        Assert.Empty(repository.GetAllPizzas());
    }

    [Fact]
    public void CreatePizza_PersistsRegisteredPizzasAcrossRepositoryInstances()
    {
        var repository = CreateRepository();
        repository.CreatePizza("Margarita", "Tomate y mozzarella", 12.50m, 30);

        var reloadedRepository = CreateRepository();
        var persistedPizza = Assert.Single(reloadedRepository.GetAllPizzas());

        Assert.Equal(1, persistedPizza.Id);
        Assert.Equal("Margarita", persistedPizza.Nombre);
        Assert.Equal("Tomate y mozzarella", persistedPizza.Descripcion);
        Assert.Equal(12.50m, persistedPizza.Precio);
        Assert.Equal(30, persistedPizza.Tamanio);
    }

    public void Dispose()
    {
        if (File.Exists(_dataFilePath))
        {
            File.Delete(_dataFilePath);
        }
    }

    private PizzaRepository CreateRepository() => new(_dataFilePath);
}