using System;

var botao = new Botao();
var contador = new ContadorCliques(botao);

botao.SimularClique();
botao.SimularClique();
botao.SimularClique();
botao.SimularClique();

Console.ReadKey();

//Passo 1 - Criar o delegate 
public delegate void CliqueEventHandler();

//Clase publicadora do evento
public class Botao
{
    //Passo 2 - Criando o evento
    public event CliqueEventHandler? Clique;

    //Passo 3 - Disparar o evento
    public void SimularClique()
    {
        Clique?.Invoke();
    }
}

//Classe assinante do evento
public class ContadorCliques
{
    private int _quantidadeCliques;

    public ContadorCliques(Botao botao)
    {
        botao.Clique += ContarClique;
    }

    private void ContarClique()
    {
        _quantidadeCliques++;
        Console.WriteLine($"Quantidade de cliques: {_quantidadeCliques}");
    }
}