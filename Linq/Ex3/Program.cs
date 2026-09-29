/*
 3. Dada a classe Pessoa, obtenha com LINQ:
 Pessoas com idade maior que 18
 Os nomes das pessoas ordenados alfabeticamente
class Pessoa
{
}
    public string Nome { get; set; }
    public int Idade { get; set; }
List<Pessoa> pessoas = new List<Pessoa>
{
};
    new Pessoa { Nome = "João", Idade = 17 },
    new Pessoa { Nome = "Maria", Idade = 22 },
*/


List<Pessoa> pessoas = new List<Pessoa>
{
    new Pessoa { Nome = "Joao",   Idade = 17 },
    new Pessoa { Nome = "Maria",  Idade = 22 },
    new Pessoa { Nome = "Carlos", Idade = 30 }
};

// Pessoas com idade maior que 18
var maioresDeIdade = pessoas
    .Where(p => p.Idade > 18);

Console.WriteLine("Pessoas com idade > 18:");
foreach (var p in maioresDeIdade)
    Console.WriteLine($"  {p.Nome} - {p.Idade}");

// Nomes ordenados alfabeticamente
var nomesOrdenados = pessoas
    .OrderBy(p => p.Nome)
    .Select(p => p.Nome);

Console.WriteLine("\nNomes ordenados:");
foreach (var nome in nomesOrdenados)
    Console.WriteLine($"  {nome}");


Console.ReadKey();
public class Pessoa
{
    public string? Nome { get; set; }
    public int Idade { get; set; }
}