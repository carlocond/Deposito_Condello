using System;
using Microsoft.VisualBasic;

public class Program(){
static void Main(string[] args){

    PrimoEsercizo();
    SecondoEsercizio();
    TerzoEsercizio();
    QuartoEsercizio();
    QuintoEsercizio();

    SestoEsercizio();
    SettimoEsercizio();
    OttavoEsercizio();

}

static void PrimoEsercizo(){
    int num1 = 10;
    int num2 = 20;
    Console.WriteLine($"La somma di {num1} e {num2} è uguale a {num1 + num2}");
}

static void SecondoEsercizio(){
    double prezzo = 170;
    double sconto = (prezzo * 20 )/ 100;
    double prezzoScontato = prezzo - sconto;
    Console.WriteLine($"Il prezzo scontato è uguale a {prezzoScontato}");
}

static void TerzoEsercizio(){
    float numero = 10;
    bool numPositivo = numero > 0;
    Console.WriteLine($"Il numero inserito è un numero positivo? {numPositivo}");
}

static void QuartoEsercizio(){ 
    int num;
    float numV;

    Console.WriteLine("Inserisci un numero intero");
    num = int.Parse(Console.ReadLine());

    Console.WriteLine("Inserisci un numero con la virgola");
    numV = float.Parse(Console.ReadLine());


    float somma = num + numV;

    Console.WriteLine($"La somma tra il numero intero e il numero con la virgola è {somma}");


}

static void QuintoEsercizio(){
    int eta;
    float altezza;

    Console.WriteLine("Quanti anni hai?");
    eta = int.Parse(Console.ReadLine());

    Console.WriteLine("Inserisci la tua altezza in metri");
    altezza = float.Parse(Console.ReadLine());


    float somma = eta + altezza;

    Console.WriteLine($"La somma tra la tua età e la tua altezza è uguale a {somma}");
}

static void SestoEsercizio(){
    int etaInserita;
    const int eta = 18;

    Console.WriteLine("Quanti anni hai?");
    etaInserita = int.Parse(Console.ReadLine());

    if (etaInserita >= eta){
        Console.WriteLine("Sei maggiorenne vai e bevi");
    } else{
        Console.WriteLine("Torna a casa a dormire");
    }
    
}

static void SettimoEsercizio(){
    double prezzoInserito;

        Console.WriteLine("Inserisci il prezzo del prodotto");
        prezzoInserito = double.Parse(Console.ReadLine());
        
    double sconto = (prezzoInserito * 10 )/ 100;
    double prezzoScontato = prezzoInserito - sconto;

    if(prezzoScontato > 100){
        Console.WriteLine($"Il prezzo scontato è uguale a {prezzoScontato}");
    }
}

static void OttavoEsercizio(){
    int voto1;
    int voto2;
    int voto3;

    Console.WriteLine("Inserisci il primo voto");
    voto1 = int.Parse(Console.ReadLine());

    Console.WriteLine("Inserisci il secondo voto");
    voto2 = int.Parse(Console.ReadLine());

    Console.WriteLine("Inserisci il terzo voto");
    voto3 = int.Parse(Console.ReadLine());

    double somma = voto1 + voto2 + voto3;
    double media = somma / 3;

    Console.WriteLine($"La media dei tuoi voti è {media}");

    if(media >= 60){
        Console.WriteLine("Hai superato la prova!");
    } else {
        Console.WriteLine("Prova fallita.");
    }
}


}

