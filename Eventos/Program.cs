using System;

var ar = new ArCondicionado
{
    LimiteInferior = 18,
    LimiteSuperior = 30
};

var monitor = new Monitor(ar);

ar.AjustarTemperatura(25);
ar.AjustarTemperatura(35);
ar.AjustarTemperatura(15);

Console.ReadKey();

// Passo 1 - Criar o delegate
public delegate void AlarmeTemperaturaEventHandler(string mensagem);


//Clase publicadora do evento
public class ArCondicionado
{
    public double Temperatura { get; private set; }
    public double LimiteSuperior { get; set; }
    public double LimiteInferior { get; set; }

    // Passo 2 - Criando o evento
    public event AlarmeTemperaturaEventHandler? AlarmeTemperatura;

    public void AjustarTemperatura(double novaTemperatura)
    {
        Temperatura = novaTemperatura;

        //Passo 3 - Disparar o evento
        if (Temperatura > LimiteSuperior)
        {
            AlarmeTemperatura?.Invoke(
                $"Alerta! Temperatura {Temperatura}°C ultrapassou o limite superior de {LimiteSuperior}°C."
            );
        }
        else if (Temperatura < LimiteInferior)
        {
            AlarmeTemperatura?.Invoke(
                $"Alerta! Temperatura {Temperatura}°C ultrapassou o limite inferior de {LimiteInferior}°C."
            );
        }
    }
}

//Classe assinante do evento
public class Monitor
{
    //Passo 4 - Inscrever o Assinante
    public Monitor(ArCondicionado ar)
    {
        ar.AlarmeTemperatura += ReceberAlerta;
    }

    public void ReceberAlerta(string mensagem)
    {
        Console.WriteLine(mensagem);
    }
}