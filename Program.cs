using System;

namespace JuegoAhorcado
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] palabra;
            char[] tablero;
            Ahorcado cd = new Ahorcado(); //Lamada de la clase Ahorcado
            palabra = cd.DefinirPalabra(); //Invocar al metodo 'DefinirPalabra' y guardar su retorno en  'palabra'
            tablero = cd.DefinirTablero(palabra);//Invocar al metodo 'DefinirTablero' y guardar su retorno en  'tablero'
            cd.AdivinarPalabra(tablero, palabra);//Invocar al metodo 'AdivinarPalabra' y aplicarlo a 'tablero' y 'palabra'
        }
    }
}

