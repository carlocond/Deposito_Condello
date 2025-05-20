using System;
using Microsoft.VisualBasic; 

public class Esercizio(){

    static void Main(string[] args){
        
        //PrimoEsercizio();
        //SecondoEsercizio();
        //TerzoEsercizio();

        //QuartoEsercizio();
        //QuintoEsercizio();
        //SestoEsercizio();

        //SettimoEsercizio();
        //OttavoEsercizio();

        //NonoEsercizio();
        //DecimoEsercizio();
        //UndicesimoEsercizio();

        //DodicesimoEsercizio();
        //TredicesimoEsercizio();
        //QuattordicesimoEsercizio();


    }

    static void PrimoEsercizio(){
        Console.WriteLine("Inserisci un numero intero");
        string numero = Console.ReadLine();

        int num1 = int.Parse(numero);

        if (num1 % 2 == 0){
            Console.WriteLine($"Il numero {num1} è pari");
        } else {
            Console.WriteLine($"Il numero {num1} è dispari");
        }
    }

    static void SecondoEsercizio(){
        const string password = "corsocsharp";
        
        Console.WriteLine("Inserisci la password");
        string passwordinserita = Console.ReadLine();

        if (passwordinserita == password){
            Console.WriteLine("Accesso Consentito");
        }else{
            Console.WriteLine("Accesso Negato");
        }
    }

    static void TerzoEsercizio(){

        Console.WriteLine("Inserisci un numero");
        double numero1 = double.Parse(Console.ReadLine());
        Console.WriteLine("Inserisci un altro numero");
        double numero2 = double.Parse(Console.ReadLine());

        Console.WriteLine("Che operazione vuoi fare? + oppure - ");
        string operatore = Console.ReadLine();

        if(operatore == "+"){
            Console.WriteLine($"Il risultato di {numero1} + {numero2} è {numero1 + numero2}");
        } else if(operatore == "-"){
            Console.WriteLine($"Il risultato di {numero1} - {numero2} è {numero1 - numero2}");
        } else {
            Console.WriteLine("Operatore non valido!");
        }
    }

    static void QuartoEsercizio(){

        Console.WriteLine("Inserisci un voto da 1 a 10");
        int voto = int.Parse(Console.ReadLine());

        if(voto >=1 && voto <= 4){
            Console.WriteLine("Insufficiente");
        }else if(voto >=5 && voto <=6){
            Console.WriteLine("Sufficiente");
        }else if(voto >=7 && voto <=8){
            Console.WriteLine("Buono");
        }else if(voto >=9 && voto <=10){
            Console.WriteLine("Ottimo");
        }else{
            Console.WriteLine("Errore");
        }

    }

    static void QuintoEsercizio(){

        Console.WriteLine("Inserisci la tua altezza in metri");
        float altezza = float.Parse(Console.ReadLine());

        Console.WriteLine("Inserisci il tuo peso");
        int peso = int.Parse(Console.ReadLine());

        float bmi = peso * (altezza * altezza);

        if(bmi < 18.5){
            Console.WriteLine("Sottopeso");
        }else if(bmi >=18.5 && bmi <=25){
            Console.WriteLine("Normopeso");
        }else if(bmi >=25 && bmi <=30){
            Console.WriteLine("Sovrappeso");
        }else if(bmi > 30){
            Console.WriteLine("Obesità");
        }

    }

    static void SestoEsercizio(){
        Console.WriteLine("Scegli l'unità di misura della temperatura tra Celsius, Fahrenheit, Kelvin e Rankine (celsius, fahrenheit, kelvin, renkin)");
        string unitaIniziale = (Console.ReadLine());

        Console.WriteLine("Inserisci la temperatura da convertire");
        int temperatura = int.Parse(Console.ReadLine());

        Console.WriteLine("Inserisci la scala di conversione della temperatura (celsius, fahrenheit, kelvin, renkin)");
        string scala = Console.ReadLine();

        double celsius = 0;

        if(unitaIniziale == "celsius"){
            celsius = temperatura;
        } else if(unitaIniziale == "fahrenheit"){
            celsius = (temperatura - 32) * 5 / 9;
        } else if(unitaIniziale == "kelvin"){
            celsius = (temperatura - 273.15);
        } else if(unitaIniziale == "rankine"){
            celsius = (temperatura - 491.67) * 5 / 9;
        } else {
            Console.WriteLine("Unità non valida");
        }

        double risultato;
        string simbolo;

        if (scala == "celsius")
        {
            risultato = celsius;
            simbolo = "°C";
        }
        else if (scala == "fahrenheit")
        {
            risultato = celsius * 9 / 5 + 32;
            simbolo = "°F";
        }
        else if (scala == "kelvin")
        {
            risultato = celsius + 273.15;
            simbolo = "K";
        }
        else if (scala == "rankine")
        {
            risultato = (celsius + 273.15) * 9 / 5;
            simbolo = "°R";
        }
        else
        {
            Console.WriteLine("Unità di scala non valida");
            return;
        }

        Console.WriteLine($"Risultato: {risultato} {simbolo}");

}

    static void SettimoEsercizio(){
        Console.WriteLine("Inserisci un numero da 1 a 7");
        int giorno = int.Parse(Console.ReadLine());

        switch (giorno) {
            case 1:
            Console.WriteLine("Lunedì");
            break;
            case 2:
            Console.WriteLine("Martedì");
            break;
            case 3:
            Console.WriteLine("Mercoledì");
            break;
            case 4:
            Console.WriteLine("Giovedì");
            break;
            case 5:
            Console.WriteLine("Venerdì");
            break;
            case 6:
            Console.WriteLine("Sabato");
            break;
            case 7:
            Console.WriteLine("Domenica");
            break;

            default:
            Console.WriteLine("Non esiste questo giorno");
            break;
        }
    }

    static void OttavoEsercizio(){
        Console.WriteLine("Scegli quale forma geometrica calcolare: Quadrato, Triangolo e Cerchio (Q, T ,C)");

        string formaGeometrica = Console.ReadLine();

        switch(formaGeometrica){
            case "Q":
            Console.WriteLine("Inserisci il valore del lato");
            int lato = int.Parse(Console.ReadLine());
            int areaQ = lato * lato;
            Console.WriteLine($"L'area del quadrato è {areaQ}");
            break ;

            case "T":
            Console.WriteLine("Inserisci il valore della base");
            int baseT = int.Parse(Console.ReadLine());

            Console.WriteLine("Adesso inserisci il valore dell'altezza");
            int altezzaT = int.Parse(Console.ReadLine());

            int areaT = (baseT * altezzaT) / 2;
            Console.WriteLine($"L'area del triangolo è {areaT}");
            break;

            case"C":
            Console.WriteLine("Inserisci il valore del raggio");
            double raggioC = double.Parse(Console.ReadLine());

            double areaC = ((raggioC * raggioC) * 3.14);
            Console.WriteLine($"L'area del cerchio è {areaC}");
            break;

            default:
            Console.WriteLine("Non conosco altre forme geometriche");
            break;

        }
    }

    static void NonoEsercizio(){

        Console.Write("Inserisci un numero positivo per continuare oppure inseriscine uno negativo per fermare il programma \n");
        int somma = 0;
        int numero = 0;

        while(numero >= 0){

            numero = int.Parse(Console.ReadLine());

            if(numero >= 0){

                Console.WriteLine("Inserisci un altro numero");   

            }

            if(numero < 0){

                break;
            
            }

            somma += numero;
            
        }
        
        Console.WriteLine($"La somma dei numeri è {somma}");

    }

    static void DecimoEsercizio(){
        Console.WriteLine("Inserisci un numero fino a trovare la combinazione giusta");
        const int numero = 42;

        while(true){
            int numeroInserito = int.Parse(Console.ReadLine());

            if(numeroInserito == numero){

                Console.WriteLine("Hai indovinato la combinazione");
                break;

            } else if(numeroInserito > numero){

                Console.WriteLine("Riprova il numero inserito è più grande del numero segreto");

            } else if(numeroInserito < numero){

                Console.WriteLine("Riprova il numero inserito è più piccolo del numero segreto");
            }

        }
    }

    static void UndicesimoEsercizio(){
        int saldo = 0;
        int numero = 0;

        Console.WriteLine("Benvenuto!"); 

        while(numero != 4){
            
            Console.WriteLine("Seleziona una delle opzioni inserendo un numero: ");
            Console.WriteLine("[1] - Visualizza il tuo saldo");
            Console.WriteLine("[2] - Deposita nel saldo");
            Console.WriteLine("[3] - Preleva dal saldo");
            Console.WriteLine("[4] - Esci dal programma");

                numero = int.Parse(Console.ReadLine());

            switch(numero){
                case 1:
                Console.WriteLine($"Il tuo saldo attuale è {saldo}");
                break;

                case 2:
                Console.WriteLine($"Quanto vuoi depositare?");
                int deposito = int.Parse(Console.ReadLine());
                
                saldo += deposito;
                Console.WriteLine($"Ok! Il tuo nuovo saldo è {saldo}");

                break;

                case 3:
                Console.WriteLine($"Quanto vuoi prelevare?");
                int prelievo = int.Parse(Console.ReadLine());

                if (prelievo < saldo){

                    saldo -= prelievo;
                    Console.WriteLine($"Ok! Hai appena prelevato {prelievo} euro, il tuo nuovo saldo è {saldo}");
                } else if (prelievo > saldo) {

                    Console.WriteLine("Non puoi prelevare più soldi del saldo");
                }
                break;
                case 4:
                Console.WriteLine("Arrivederci");
                break;

                default:
                Console.WriteLine("Nessuna delle opzioni è valida ritenta");
                break;
            }

        }


    }

    static void DodicesimoEsercizio(){

        Console.WriteLine("Inserisci una password numerica fino a trovare quella giusta");
        const int password = 0000;
        int numTentativi = 3;
        int tentativiRimasti = numTentativi;

        do{
            int passInserita = int.Parse(Console.ReadLine());

            if(passInserita == password){
                Console.WriteLine("Accesso eseguito");
                break;

            }else if(passInserita != password) {
                tentativiRimasti--;
                Console.WriteLine($"Accesso negato, riprova! Hai a disposizione {tentativiRimasti} tentativi!");

            }
            else{
                Console.WriteLine("Errore");
                break;
            }

        }while(tentativiRimasti > 0);
        if(tentativiRimasti == 0){
                Console.WriteLine("Tentativi esauriti. Accesso negato.");
        }
        
    }

    static void TredicesimoEsercizio(){
        Console.Write("Inserisci dei numeri interi per continuare il programma fino a quando non inserisci 0 \n");

        int somma = 0;
        int totNumeri = 0;
        int numero;

        do{
            numero = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci un altro numero");

            if (numero > 0) {
                somma += numero;
                totNumeri++;
            }
        }while(numero > 0);
        Console.WriteLine($"La somma di tutti i numeri inseriti è {somma}");
        Console.WriteLine($"I numeri inseriti erano {totNumeri}");
    }

    static void QuattordicesimoEsercizio()
    {

        int numero = 0;
        int somma = 0;
        int differenza = 0;
        int moltiplicazione = 0;
        int divisione = 0;

        int num1 = 0;
        int num2 = 0;

        bool exit = false;

        do
        {
            Console.WriteLine("Scegli quale delle 4 operazioni utilizzare");
            Console.WriteLine("[1] - Somma");
            Console.WriteLine("[2] - Differenza");
            Console.WriteLine("[3] - Moltiplicazione");
            Console.WriteLine("[4] - Divisione");
            Console.WriteLine("[5] - Esci");

            numero = int.Parse(Console.ReadLine());

            if (numero == 5)
            {
                break;
            }

            Console.WriteLine("Inserisci il primo numero");
            num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Inserisci il secondo numero");
            num2 = int.Parse(Console.ReadLine());

            switch (numero)
            {

                case 1:
                    somma = num1 + num2;
                    Console.WriteLine($"La somma dei numeri è {somma}");
                    break;

                case 2:
                    differenza = num1 - num2;
                    Console.WriteLine($"La differenza dei numeri è {differenza}");
                    break;

                case 3:
                    moltiplicazione = num1 * num2;
                    Console.WriteLine($"Il prodotto dei numeri è {moltiplicazione}");
                    break;

                case 4:
                    divisione = num1 / num2;
                    Console.WriteLine($"Il quoziente dei numeri è {divisione}");
                    break;

                default:
                    Console.WriteLine("Hai inserito un valore errato... Riprova");
                    break;

            }

            Console.WriteLine("Vuoi continuare? inserisci Si o No");
            string scelta = Console.ReadLine();
            if (scelta == "si")
            {

            }
            else if (scelta == "no")
            {
                break;
            }


        } while (exit = true);

    }



}