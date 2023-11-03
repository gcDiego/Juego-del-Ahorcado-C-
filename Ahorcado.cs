using System;
namespace JuegoAhorcado
{
	public class Ahorcado
	{
        Random rd = new Random();
        public  char[] DefinirPalabra()
		{
			//Pedir por teclado la palabra a descifrar
			string entrada = "";
            char[] palabra = new char[entrada.Length];
            Console.WriteLine("¿Cuál es la palabra a descifrar?");
			entrada = Console.ReadLine();
			//Guardar la entrada en un arreglo caracter por caracter
			palabra = entrada.ToCharArray();
			Console.Clear();

			return palabra;
		}

		public char[] DefinirTablero(char[] Palabra)
		{
            //Realizar el cálculo de los caracteres que serán eliminados
            int Logitud = (Palabra.Length);
            char[] Tablero = new char[Logitud];
			int numAleatorio;
			
            Palabra.CopyTo(Tablero, 0);
            for (int i = 0; i < Palabra.Length; i++)
			{
                numAleatorio = rd.Next(0, Palabra.Length);
                //Reemplazar caracteres en la posicion generada aleatoriamente
                Tablero[numAleatorio] = '_';
            }
			
            return Tablero;
		}

		public void AdivinarPalabra(char[] Tablero, char[] Palabra)
		{
            int vidas = Palabra.Length;
			char letra;
            bool esExacta = false;
            string Texto = new string(Tablero);

            foreach (char item in Tablero)
            {
                Console.Write(item);
            }//Imprimr la palabra a descifrar
            
			while (vidas > 0)
			{
                Console.WriteLine("tus vidas son: "+vidas);
                //Leer por teclado el caracter ingresado por el usuario
                Console.WriteLine("¿Qué letra completará la palabra?");
                letra = char.Parse(Console.ReadLine());
                //Revisar si ese carcter aparece en la Palabra
                int a = letraExiste(letra, Tablero, Palabra);/*Retorna el numero de veces que
                                                              * dicho carcter NO fue encontrado 
                                                              * en el arreglo Palabra
                                                              */
                if (a == Palabra.Length)
                {
                    /*Por lo tanto, si el # de veces que no aparece es
                     igual a la longtud de la palabra, restar vidas*/
                    vidas--;
                }
                //Imprimir el tablero caracter por caracter
                foreach (char item in Tablero)
                {
                    Console.Write(item);
                }
                //Salto de linea
                Console.WriteLine();
                /*Llamada del método para comprobar si el Tablero esta completado*/
                esExacta = comprobarCadenas(Tablero, Palabra);
                if (esExacta == true)
                {
                    Console.WriteLine("Felicidades :)");
                    break;//Detener el programa en este punto si la condicion es verdadera
                }
            }
            Console.WriteLine("Juego Terminado");
		}

        public int letraExiste (char entrada, char[] Tablero, char[] Palabra)
        {
            /*Metodo que analiza si el caracter ingresado por teclado existe dentro de la Palabra*/
            bool existe;
            int a = 0;
            for (int i = 0; i < Palabra.Length; i++)
            {
                existe = entrada == Palabra[i];
                if (existe==true)
                {
                    /* si el caracter ingresado es igual a un carcter 
                     * en posicion 'i' del arreglo, guardar ese caracter en esa posicion 'i'*/
                    Tablero[i] = entrada;
                }
                else
                {
                    /* Si dicho caracter no existe en Palabra, registra el numero de veces que se analizo
                     * Para saber si ese caracter existe 'a' debe ser menor que la longitud de Palabra
                     */
                    a++;
                }
            }
            return a;
        }

        public bool comprobarCadenas(char[] Tablero, char[] Palabra)
        {
            //Metodo que analiza caracter por carcter de dos arreglos
            for (int i=0; i < Palabra.Length; i++)
            {
                if (Tablero[i] != Palabra[i])
                    return false;
            }
            return true;
        }
	}
}

