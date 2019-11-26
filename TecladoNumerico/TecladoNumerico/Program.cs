using System;
using System.Threading;
using System.Globalization;
using System.Collections.Generic;

namespace TecladoNumerico
{
    public class Program
    {
        public static int secuencia;

        public static List<Letras> abecedario = new List<Letras>();

        public static string ultMovimiento = "";

        public static void Main(string[] args)
        {
            int validacion=0;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            llenarlista();
            Console.WriteLine("Seleccione el mensaje a convertir en numeros");

            string cadena =  Console.ReadLine();
            //Recorre letra por letra 
            for (int i = 0; i < cadena.Length; i++)
            {
                //Busca en el diccionario de datos la la letra que es igual a la que se encontro en el bucle
                foreach(var recorrido in abecedario)
                {
                    //Compara la letra que ingreso el usuario con cada letra del diccionario de datos
                    string letraInd= Convert.ToString(recorrido.letra);
                    if(cadena.Substring(i, 1) == letraInd)
                    {
                        string prueba = Convert.ToString(recorrido.numero);
                        if (prueba.Contains(ultMovimiento))
                        {
                            Console.Write(" ");
                        }
                        //En caso de que la letra del diccionario sea igual al que ingreso el usuario convierte la letra en numeros y guarda el numero que lo representa
                        mostrarGuardar(recorrido.numero);
                        validacion++;
                    }
                }
                //Si la cadena tiene un espacio reemplaza el espacio por un 0
                if(cadena.Substring(i, 1) == " ")
                {
                    mostrarGuardar(0);
                    validacion++;
                }
            }
            if(validacion != cadena.Length)
            {
                Console.Clear();
                Console.WriteLine("Error. Ingrese letras dentro del abecedario");
            }

            Console.ReadKey();
        }

        //Muestra en consola el numero que representa la letra y lo guarda en una variable
        public static void mostrarGuardar(int num)
        {
            Console.Write(num);
            ultMovimiento = Convert.ToString(num);
            ultMovimiento = ultMovimiento.Substring(0, 1);
        }

        //Recorre todo el abecedario guardando en un diccionario de datos las letras con sus respectivas secuencias de identidad
        public static void llenarlista()
        {
            char abc = 'a';
            int num = 2;
            for(num = 2; num <=9; num++)
            {
                if (num == 9 || num ==7)
                {
                    for (int j = 1; j <= 4; j++)
                    {
                        calcularlista(j);
                        int id = num * secuencia;
                        abecedario.Add(new Letras { numero = id, letra = abc });
                        abc++;
                    }
                }
                else
                {
                    for (int j = 1; j <= 3; j++)
                    {
                        calcularlista(j);
                        int id = num * secuencia;
                        abecedario.Add(new Letras { numero = id, letra = abc });
                        abc++;
                    }
                }
            }
        }

        //Devuelve el numero a multiplicar para sacar el numero de la letra
        public static int calcularlista(int numsec)
        {
            switch(numsec)
            {
                case 1:
                    secuencia = 1;
                    break;
                case 2:
                    secuencia = 11;
                    break;
                case 3:
                    secuencia = 111;
                    break;
                case 4:
                    secuencia = 1111;
                    break;
            }
            return secuencia;
        }

    }
}
