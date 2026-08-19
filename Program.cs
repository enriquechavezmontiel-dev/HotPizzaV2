using HotPizza.Services;

var repository = new PizzaRepository();

Console.WriteLine("=== Administrador de Catálogo de Pizzería ===\n");

while (true)
{
    Console.WriteLine("Opciones:");
    Console.WriteLine("1. Registrar nueva pizza");
    Console.WriteLine("2. Consultar pizzas registradas");
    Console.WriteLine("3. Salir");
    Console.Write("\nSeleccione una opción: ");

    var opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            RegistrarPizza(repository);
            break;
        case "2":
            ConsultarPizzas(repository);
            break;
        case "3":
            Console.WriteLine("\n¡Hasta luego!");
            return;
        default:
            Console.WriteLine("\nOpción no válida. Intente nuevamente.\n");
            break;
    }
}

static void RegistrarPizza(PizzaRepository repository)
{
    Console.WriteLine("\n--- Registrar Nueva Pizza ---");

    try
    {
        Console.Write("Nombre: ");
        var nombre = Console.ReadLine() ?? string.Empty;

        Console.Write("Descripción: ");
        var descripcion = Console.ReadLine() ?? string.Empty;

        Console.Write("Precio: ");
        if (!decimal.TryParse(Console.ReadLine(), out var precio))
        {
            Console.WriteLine("Error: El precio debe ser un número válido.\n");
            return;
        }

        Console.Write("Tamaño (20, 30 o 40 cm): ");
        if (!int.TryParse(Console.ReadLine(), out var tamanio))
        {
            Console.WriteLine("Error: El tamaño debe ser un número válido.\n");
            return;
        }

        var id = repository.CreatePizza(nombre, descripcion, precio, tamanio);
        Console.WriteLine($"\n✓ Pizza registrada exitosamente con ID: {id}\n");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"\nError: {ex.Message}\n");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\nError inesperado: {ex.Message}\n");
    }
}

static void ConsultarPizzas(PizzaRepository repository)
{
    Console.WriteLine("\n--- Pizzas Registradas ---");

    var pizzas = repository.GetAllPizzas();

    if (pizzas.Count == 0)
    {
        Console.WriteLine("No hay pizzas registradas en el catálogo.\n");
        return;
    }

    Console.WriteLine($"\n{"ID",-5} {"Nombre",-20} {"Descripción",-30} {"Precio",-10} {"Tamaño",-10}");
    Console.WriteLine(new string('-', 75));

    foreach (var pizza in pizzas)
    {
        Console.WriteLine($"{pizza.Id,-5} {pizza.Nombre,-20} {pizza.Descripcion,-30} ${pizza.Precio,-9} {pizza.Tamanio} cm");
    }

    Console.WriteLine();
}
