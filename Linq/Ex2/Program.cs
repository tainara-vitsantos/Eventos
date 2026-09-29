/* 
2. Dada a lista de inteiros abaixo, use LINQ para:
a. Obter o maior número
b. Somar todos os valores maiores que 10
List<int> numeros = new List<int> { 5, 12, 8, 20, 3, 15, 7 };
*/

List<int> numeros = new List<int> { 5, 12, 8, 20, 3, 15, 7 };

// a. Maior número
int maior = numeros.Max();
Console.WriteLine($"Maior número: {maior}");

// b. Soma dos valores maiores que 10
int somaMaiores = numeros
    .Where(n => n > 10)
    .Sum();
Console.WriteLine($"Soma dos > 10: {somaMaiores}"); 