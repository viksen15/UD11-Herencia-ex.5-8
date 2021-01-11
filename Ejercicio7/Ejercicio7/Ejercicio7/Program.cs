using System;

namespace Ejercicio7
{
    class Raices
    {
        // ATRIBUTOS 
        private double a;
        private double b;
        private double c;

        // CONSTRUCTOR
        public Raices(double a, double b, double c)
        { 
            this.a = a;
            this.b = b;
            this.c = c;
        }

        private void obtenerRaices()
        {
            double x1 = (-b + Math.Sqrt(getDiscriminate())) / (2 * a);
            double x2 = (-b - Math.Sqrt(getDiscriminate())) / (2 * a);
            Console.WriteLine("Solucion 1: " + x1);
            Console.WriteLine("Solucion 2: " + x2);
        }
        private void obtenerRaiz()
        {
            double x = (-b) / (2 * a);
            Console.WriteLine("Unica solucion: " + x);
        }
        private double getDiscriminate()
        {
            return Math.Pow(b, 2) - (4 * a * c);
        }
        private bool tieneRaices()
        {
            return getDiscriminate() > 0;
        }
        private bool tieneRaiz()
        {
            return getDiscriminate() == 0;
        }
        public void calcular()
        {
            if (tieneRaices())
            {
                obtenerRaices();
            }
            else if (tieneRaiz())
            {
                obtenerRaiz();
            }
            else { Console.WriteLine("No tiene soluciones"); }

        }
        class Program
        {
            static void Main(string[] args)
            {
                Raices ecuacion = new Raices(2, 5, 3);
                Console.WriteLine("Ecuacion con dos soluciones: ");
                Console.WriteLine("");
                ecuacion.calcular();
                Console.WriteLine("");

                Raices ecuacion2 = new Raices(1, 4, 4);
                Console.WriteLine("Ecuacion con una solucion: ");
                Console.WriteLine("");
                ecuacion2.calcular();
                Console.WriteLine("");

                Raices ecuacion3 = new Raices(1, 5, 7);
                Console.WriteLine("Ecuacion sin soluciones: ");
                Console.WriteLine("");
                ecuacion3.calcular();


                Console.ReadKey();
            }
        }
    }
}
