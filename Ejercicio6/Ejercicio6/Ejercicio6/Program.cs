using System;

namespace Ejercicio6
{
    class Libro
    {
        // ATRIBUTOS
        private int isbn;
        public int ISBN { set { this.isbn = value; } get { return isbn; } }
        private string titulo;
        public string Titulo { set { this.titulo = value; } get { return titulo; } }
        private string autor;
        public string Autor { set { this.autor = value; } get { return autor; } }
        private int numPag;
        public int Numpag { set { this.numPag = value; } get { return numPag; } }

        public override string ToString()
        {
            return "El libro " + Titulo + " con ISBN " + ISBN + " creado por el autor " + Autor + " tiene " + Numpag + " paginas.";
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Libro libro1 = new Libro();
            libro1.ISBN = 979034154;
            libro1.Titulo = "La historia de una vida";
            libro1.Autor = "Viksen";
            libro1.Numpag = 263;
            Console.WriteLine(libro1.ToString());
            Console.WriteLine("");

            Libro libro2 = new Libro();
            libro2.ISBN = 126542863;
            libro2.Titulo = "Dos dias en Paris";
            libro2.Autor = "Juan";
            libro2.Numpag = 175;
            Console.WriteLine(libro2.ToString());
            Console.WriteLine("");


            if (libro1.Numpag > libro2.Numpag) { Console.WriteLine(libro1.Titulo + " tiene mas paginas"); }
            else { Console.WriteLine(libro2.Titulo + "tiene mas paginas."); }
        }
    }
}
