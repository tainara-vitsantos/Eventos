using System;

var estoque = new Estoque("Teclado", 10, 5);
var alerta = new AlertaEstoque(estoque);

estoque.Remover(3); // 7 unidades
estoque.Remover(3); // 4 unidades -> dispara alerta
estoque.Remover(1); // 3 unidades -> dispara alerta

Console.ReadKey();

// Classe da declaração dos parametros do evento
public class EstoqueBaixoEventArgs : EventArgs
{
    public string NomeProduto { get; }
    public int QuantidadeAtual { get; }
    public int LimiteMinimo { get; }

    public EstoqueBaixoEventArgs(string nomeProduto, int quantidadeAtual, int limiteMinimo)
    {
        NomeProduto = nomeProduto;
        QuantidadeAtual = quantidadeAtual;
        LimiteMinimo = limiteMinimo;
    }
}

//Classe publicadora do evento
public class Estoque
{
    public string Nome { get; set; }
    public int Quantidade { get; private set; }
    public int LimiteMinimo { get; set; }

    // Paso 2- Criando o evento usando EventHandler
    public event EventHandler<EstoqueBaixoEventArgs>? EstoqueBaixo;

    public Estoque(string nome, int quantidadeInicial, int limiteMinimo)
    {
        Nome = nome;
        Quantidade = quantidadeInicial;
        LimiteMinimo = limiteMinimo;
    }

    public void Remover(int quantidade)
    {
        if (quantidade <= 0)
            return;

        Quantidade -= quantidade;

    //Passo 3 - Disparar o evento
        if (Quantidade < LimiteMinimo)
        {
            EstoqueBaixo?.Invoke(
                this,
                new EstoqueBaixoEventArgs(Nome, Quantidade, LimiteMinimo)
            );
        }
    }
}

//Classe assinante
public class AlertaEstoque
{
    public AlertaEstoque(Estoque estoque)
    {
        estoque.EstoqueBaixo += ExibirAlerta;
    }

    private void ExibirAlerta(object? sender, EstoqueBaixoEventArgs e)
    {
        Console.WriteLine(
            $"Alerta de estoque baixo: Produto {e.NomeProduto} possui apenas {e.QuantidadeAtual} unidades. Mínimo: {e.LimiteMinimo}."
        );
    }
}