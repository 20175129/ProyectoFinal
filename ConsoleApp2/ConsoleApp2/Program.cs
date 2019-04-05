using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Programa que lee una matrix 4x4 y determina cuántas veces se repite el número mayor");

            int[,] numeris = new int[4, 4];

            for (int fila = 0; fila < 4; fila++)
            {
                for (int columna = 0; columna < 4; columna++)
                {
                    Console.Write("Ingrese el número correspondiente a la fila {0}, columna {1}: ", (fila + 1), (columna + 1));
                    int.TryParse(Console.ReadLine(), out numeris[fila, columna]);
                }
            }

            int cont = 0;
            int mayor = 0;
            int mayor2 = 0;


            for (int efila = 0; efila < 4; efila++)
            {
                for (int ecolumna = 0; ecolumna < 4; ecolumna++)
                {
                    if (numeris[efila, ecolumna] > mayor)
                    {
                        mayor = numeris[efila, ecolumna];
                        if (mayor != mayor2)
                        {
                            cont = 0;
                        }
                    }
                    if (numeris[efila, ecolumna] == mayor)
                    {
                        cont++;
                    }
                }
                mayor2 = mayor;
            }

            Console.WriteLine("\r\n" + "El número mayor se repite {0} veces", cont);
            Console.WriteLine();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(" " + numeris[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
