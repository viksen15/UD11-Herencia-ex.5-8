using System;

namespace Ejercicio5
{
    class Serie : Entregable
    {
        // ATRIBUTOS
        protected string titulo;
        protected int numeroTemp = 3;
        protected bool entregado = false;
        protected string genero;
        protected string creador;

        public static int menor = -1;
        public static int igual = 0;
        public static int mayor = 1;


        // CONSTRUCTORES Y METODOS
        public Serie()
        { }
        public Serie(string tit, string crea)
        {
            titulo = tit;
            creador = crea;
        }
        public Serie(string titu, int numt, string gen, string cread)
        {
            titulo = titu;
            numeroTemp = numt;
            genero = gen;
            creador = cread;
        }

        // METODOS
        public string Titulo { set { this.titulo = value; } get { return titulo; } }
        public int Numerotemp { set { this.numeroTemp = value; } get { return numeroTemp; } }
        public string Genero { set { this.genero = value; } get { return genero; } }
        public string Creador { set { this.creador = value; } get { return creador; } }

        public override string ToString()
        {
            return "Informacion de la serie: \n"
                + "\t Titulo: " + titulo + "\n" +
                "\t Horas estimadas: " + numeroTemp + "\n" +
                "\t Genero: " + genero + "\n" +
                "\t Compañia: " + creador;
        }



        public bool entregar()
        {
            entregado = true;
            return entregado;
        }

        public bool devolver()
        {
            entregado = false;
            return entregado;
        }

        public bool isEntregado()
        {
            if (entregado) { return true; }
            return false;
        }
        public int compareTo(object a)
        {
            int estado = menor;

            Serie ser = (Serie)a;
            if (Numerotemp > ser.Numerotemp) { estado = mayor; }
            else if (Numerotemp == ser.Numerotemp) { estado = igual; }
            return estado;
        }
    }
        class Videojuego : Entregable
    {
        // ATRIBUTOS 
        protected string titulo;
        protected int horasEstimadas = 10;
        protected bool entregado = false;
        protected string genero;
        protected string compañia;

        public static int menor = -1;
        public static int igual = 0;
        public static int mayor = 1;


        // CONSTRUCTORES
        public Videojuego()
        { }
        public Videojuego(string tit, int hE)
        {
            titulo = tit;
            horasEstimadas = hE;
        }
        public Videojuego(string titu, int hE, string gen, string comp)
        {
            titulo = titu;
            horasEstimadas = hE;
            genero = gen;
            compañia = comp;
        }

        // METODOS
        public string Titulo { set { this.titulo = value; } get { return titulo; } }
        public int hE { set { this.horasEstimadas = value; } get { return horasEstimadas; } }
        public string Genero { set { this.genero = value; } get { return genero; } }
        public string Comp { set { this.compañia = value; } get { return compañia; } }

        public override string ToString()
        {
            return "Informacion de la serie: \n"
                + "\t Titulo: " + titulo + "\n" +
                "\t Horas estimadas: " + horasEstimadas + "\n" +
                "\t Genero: " + genero + "\n" +
                "\t Compañia: " + compañia;
        }

        public bool entregar()
        {
            entregado = true;
            return entregado;
        }

        public bool devolver()
        {
            entregado = false;
            return entregado;
        }
        public bool isEntregado()
        {
            if (entregado) { return true; }
            return false;
        }

         public int compareTo(object a)
        {
            int estado = menor;

            Videojuego vid = (Videojuego)a;
            if (hE > vid.hE) { estado = mayor; }
            else if (hE == vid.hE) { estado = igual; }
            return estado;
        }

    }


    public interface Entregable
    {
        public bool entregar();
        public bool devolver();
        public bool isEntregado();
        public int compareTo(object a);
    }


    class Program
    {
        static void Main(string[] args)
        {
            Serie[] series = new Serie[5];
            series[0] = new Serie();
            series[1] = new Serie("Suits", "Charly");
            series[2] = new Serie("Brooklyn", 5, "Comedia", "John");
            series[3] = new Serie("Las reglas del juego", "Jimmy");
            series[4] = new Serie("TBBT", 12, "Comedia", "Mat");

            Videojuego[] videojuegos = new Videojuego[5];
            videojuegos[0] = new Videojuego();
            videojuegos[1] = new Videojuego("Need for Speed", 35);
            videojuegos[2] = new Videojuego("Dirt", 60, "Coches", "Ubisoft");
            videojuegos[3] = new Videojuego("Mafia", 45);
            videojuegos[4] = new Videojuego("Fifa", 52, "Futbol", "EA");

            series[1].entregar();
            series[3].entregar();
            videojuegos[2].entregar();
            videojuegos[4].entregar();

            int entregados = 0;
            for (int i = 0; i < series.Length; i++)
            {
                if (series[i].isEntregado()) { entregados += 1; series[i].devolver(); }
                if (videojuegos[i].isEntregado()) { entregados += 1; videojuegos[i].devolver(); }
            }
            Console.WriteLine("Se han entregado " + entregados + " articulos");
            Console.WriteLine("");

            Serie serieLarga = series[0];
            Videojuego juegoLargo = videojuegos[0];
            for (int i = 1; i < series.Length; i++)
            {
                if (series[i].compareTo(serieLarga) == Serie.mayor)
                { serieLarga = series[i]; }
                if (videojuegos[i].compareTo(juegoLargo) == Videojuego.mayor) 
                { juegoLargo = videojuegos[i]; }
            }
            Console.WriteLine("La serie con mas temporadas es: " + serieLarga);
            Console.WriteLine("El videojuego mas largo es: " + juegoLargo );
        }
    }
}
