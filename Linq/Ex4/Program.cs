/*
 4. Crie a classe Pedidos, classe Cliente e a classe Produto contendo:
Produto: Nome, Preço; Cliente: Nome, cpf; Pedido: Quantidade, data
pedido, objetos produtos e Objeto Cliente. Instancie vários pedidos,
inclusive pedidos para o mesmo cliente. Faça:
a. Mostre todos os pedidos agrupados por cliente.
b. Trazer os nomes dos clientes que têm pedidos acima de R$ 500
c. Calcular o valor total de pedidos por cliente
*/



//Instanciando os dados 
var p1 = new Produto { Nome = "Notebook", Preco = 3000 };
var p2 = new Produto { Nome = "Mouse", Preco = 100 };
var p3 = new Produto { Nome = "Teclado", Preco = 250 };

var c1 = new Cliente { Nome = "Ana", Cpf = "111.111.111-11" };
var c2 = new Cliente { Nome = "Bruno", Cpf = "222.222.222-22" };

List<Pedido> pedidos = new List<Pedido>
{
    new Pedido { Quantidade = 1, DataPedido = DateTime.Now, Produto = p1, Cliente = c1 }, // 3000
    new Pedido { Quantidade = 2, DataPedido = DateTime.Now, Produto = p2, Cliente = c1 }, // 200
    new Pedido { Quantidade = 1, DataPedido = DateTime.Now, Produto = p3, Cliente = c2 }, // 250
    new Pedido { Quantidade = 3, DataPedido = DateTime.Now, Produto = p2, Cliente = c2 }, // 300
    new Pedido { Quantidade = 1, DataPedido = DateTime.Now, Produto = p2, Cliente = c2 }  // 100
};

// a) Mostre todos os pedidos agrupados por cliente
Console.WriteLine("=== a) Pedidos agrupados por cliente ===");

var agrupados = pedidos
    .GroupBy(p => p.Cliente!.Nome);

foreach (var grupo in agrupados)
{
    Console.WriteLine($"\nCliente: {grupo.Key}");
    foreach (var pedido in grupo)
    {
        Console.WriteLine($"   {pedido.Produto!.Nome} x{pedido.Quantidade} = R$ {pedido.ValorTotal}");
    }
}
// b) Nomes dos clientes com pedidos acima de R$ 500

Console.WriteLine("\n=== b) Clientes com pedidos > R$ 500 ===");

var clientesAcima500 = pedidos
    .Where(p => p.ValorTotal > 500)
    .Select(p => p.Cliente!.Nome)
    .Distinct();

foreach (var nome in clientesAcima500)
{
    Console.WriteLine($"   {nome}");
}

// c) Valor total de pedidos por cliente

Console.WriteLine("\n=== c) Valor total de pedidos por cliente ===");

var totalPorCliente = pedidos
    .GroupBy(p => p.Cliente!.Nome)
    .Select(g => new
    {
        Cliente = g.Key,
        Total = g.Sum(p => p.ValorTotal)
    });

foreach (var item in totalPorCliente)
{
    Console.WriteLine($"   {item.Cliente}: R$ {item.Total}");
}

Console.ReadKey();


// CLASSES
public class Produto
{
    public string? Nome { get; set; }
    public double Preco { get; set; }
}

public class Cliente
{
    public string? Nome { get; set; }
    public string? Cpf { get; set; }
}

public class Pedido
{
    public int Quantidade { get; set; }
    public DateTime DataPedido { get; set; }
    public Produto? Produto { get; set; }
    public Cliente? Cliente { get; set; }

    // Propriedade calculada para facilitar
    public double ValorTotal => Quantidade * (Produto?.Preco ?? 0);
}