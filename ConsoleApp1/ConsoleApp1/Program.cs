using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp1
{
    class Program 
    {
        static void Main(string[] args)
        {
            Nasa nasa = new Nasa();
            Console.WriteLine("Bienvenido a la NASA, a continuacion se le haran algunas preguntas para poder ir a otro planeta.");
            Console.WriteLine("-------------------------");
            Console.WriteLine("¿Cuál es su nombre?");
            nasa.nombre = Console.ReadLine();
            Console.WriteLine("¿Cuál es su nacionalidad?");
            nasa.nacionalidad = Console.ReadLine();
            Console.WriteLine("¿Cuál es su edad?");
            nasa.edad = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("¿Cuál es su planeta de procedencia?");
            nasa.origen = Console.ReadLine();
            Console.WriteLine("¿A qué planeta usted quiere viajar?");
            nasa.destino = Console.ReadLine();
            Console.WriteLine("-------------------------");
            Console.WriteLine("-------------------------");
            nasa.lanzamiento();
            Thread.Sleep(2000);
            nasa.abordando();
            Thread.Sleep(2000);
            nasa.tiempoLlegada();
            Thread.Sleep(2000);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            nasa.alerta();
            Thread.Sleep(3500);
            Console.ResetColor();
            nasa.llegada();
            Thread.Sleep(3000);
            nasa.aterrizaje();
            Console.ReadLine();
        }
    }

    class Nasa{

        public String destino;
        public String origen;
        public String nombre;
        public int edad;
        public String nacionalidad;

        public Nasa() { }

        public void lanzamiento()
        {
            Console.WriteLine("Su nombre es " + nombre);
            Console.WriteLine("Su nacionalidad es " + nacionalidad);
            Console.WriteLine("Tiene " + edad + " anios");
            Console.WriteLine("Su origen es el planeta " + origen);
            Console.WriteLine("Su destino es el planeta " + destino);
        }

        public void abordando()
        {
            Console.WriteLine("Actualmente estas abordando la nave en tu planeta origen...");
        }

        public void tiempoLlegada()
        {
            Console.WriteLine("Su tiempo de llegada es de mil anios luz");
        }

        public void alerta()
        {
            Console.WriteLine("CUIDADO CON EL ASTEROIDE PROCEDENTE DE " + destino);
        }

        public void llegada()
        {
            Console.WriteLine("Ya casi estamos llegando!..");
        }

        public void aterrizaje()
        {
            Console.WriteLine("Ha llegado a su destino, Bienvenido a " + destino);
        }


    }
}
