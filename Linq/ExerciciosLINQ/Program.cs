/* 1. Crie uma lista de inteiros, retorne a soma de todos os elementos da
lista que são ímpares, usando LINQ. */


List<int> numeros = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

int somaImpares = numeros
    .Where(n => n % 2 != 0)
    .Sum();

Console.WriteLine($"Soma dos ímpares: {somaImpares}");
