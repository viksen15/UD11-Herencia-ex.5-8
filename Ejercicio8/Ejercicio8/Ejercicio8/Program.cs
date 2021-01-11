using System;

namespace Ejercicio8
{
    abstract class Persona:Dispo
    {
        // ATRIBUTOS
        protected string nombre;
        protected char sexo;
        protected int edad;
        protected bool asistencia;

        private static string[] nombreschicos = { "Viksen", "Arnau", "Jose", "Armando", "John", "Tomas", "Iago", "Iker", "Luis", "Cristian" };
        private static string[] nombreschicas = { "Laia", "Maria", "Marta", "Daniela", "Soraya", "Ivana", "Joana", "Alba", "Iria", "Helena" };
        private static int chico = 0;
        private static int chica = 1;

        // CONSTRUCTORES
        public Persona()
        {
            int determinarsexo = Metodos.generaNumaleatorio(0, 1);
            if (determinarsexo == chico)
            {
                nombre = nombreschicos[Metodos.generaNumaleatorio(0, 5)];
                sexo = 'H';
            }
            else
            {
                nombre = nombreschicas[Metodos.generaNumaleatorio(0, 5)];
                sexo = 'M';
            }
            disponibilidad() ;

        }
        // METODOS
        public string Nombre { set { this.nombre = value; } get { return nombre; } }
        public char Sexo { set { this.sexo = value; } get { return sexo; } }
        public int Edad { set { this.edad = value; } get { return edad; } }
        public bool Asistencia { set { this.asistencia = value; } get { return asistencia; } }
        public abstract void disponibilidad();

    }
    class Alumno:Persona
    {
        // ATRIBUTO A DEMAS DE LOS HEREDADOS
        private int nota;
         // CONSTRUCTORES
        public Alumno()
        {
            nota = Metodos.generaNumaleatorio(0, 10);
            base.Edad = Metodos.generaNumaleatorio(11, 17);
        }
        // METODOS
        public int Nota { set { this.nota = value; } get { return nota; } }

        public override void disponibilidad()
        {
            int dispo = Metodos.generaNumaleatorio(0, 100);
            if (dispo <50) { base.asistencia = false; }
            else { base.Asistencia = true; }
        }
        public string toString()
        {
            return "Nombre: " + base.nombre + ". \t Sexo: " + base.sexo + ". \t Nota: " + nota;
        }

    }
    class Profesor:Persona
    {
        // ATRIBUTOS
        protected string materia;
        // CONSTRUCTORES
        public Profesor()
        {
            base.edad = Metodos.generaNumaleatorio(28, 60);
            materia = Materias.materias[Metodos.generaNumaleatorio(0, 2)];
        }
        // METODOS
        public string Materia { set { this.materia = value; } get { return materia; } }
        public override void disponibilidad() 
        {
            int dispo = Metodos.generaNumaleatorio(0, 100);
            if (dispo < 20)
            {
                base.asistencia = false;
            } else { base.asistencia = true; }
        }
        
    }
    class Aula
    {
        // ATRIBUTOS
        private int id;
        private Profesor profesor;
        private Alumno[] alumnos;
        private string materia;
        private static int MaxAlum = 20;
        // CONSTRUCTORES
        public Aula()
        {
            id = 1;
            profesor = new Profesor();
            alumnos = new Alumno[MaxAlum];
            creaAlumnos();
            materia = Materias.materias[Metodos.generaNumaleatorio(0, 2)];
        }
        //METODODS
        private void creaAlumnos()
        {
            for (int i=0; i < alumnos.Length;i++)
            { alumnos[i] = new Alumno(); }
        }
        private bool asistenciaAlumnos()
        {
            int asistencias = 0;
            for (int i= 0; i<alumnos.Length; i++)
            { if (alumnos[i].Asistencia) { asistencias++; } }
            Console.WriteLine("Hay " + asistencias + " alumnos.");
            return asistencias >= alumnos.Length / 2;
        }
        public bool darClase()
        {
            if (!profesor.Asistencia) { Console.WriteLine("El profe no esta, no hay clase.");
                return false;
            } else if (!profesor.Materia.Equals(materia)) { Console.WriteLine("La materia del profe y del aula no es la misma. No se puede dar clase.");
                return false;
            } else if (!asistenciaAlumnos()) { Console.WriteLine("La asistencia no es suficiente, no hay clase.");
                return false;
            }

            Console.WriteLine("Hay clase.");
            return true;
        }
        public void notas()
        {
            int chicosAprobados = 0;
            int chicasAprobadas = 0;
            for (int i=0;i<alumnos.Length;i++)
            {
                if (alumnos[i].Sexo == 'H') { chicosAprobados++; }
                else { chicasAprobadas++; }
                Console.WriteLine(alumnos[i].toString());
            }
            Console.WriteLine("Hay " + chicosAprobados + " chicos aprobados.");
            Console.WriteLine("Hay " + chicasAprobadas + " chicas aprobadas.");
        }
    }
    class Materias
    {
        public static string[] materias = { "Matematicas", "Filosofia", "Fisica" };
    }
    public abstract class Dispo
    {
    }

    class Metodos
    {
        public static int generaNumaleatorio(int min, int max)
        {
            Random numrandom = new Random();
            int num = (int)Math.Floor(numrandom.NextDouble() * (min - (max + 1)) + (max + 1));
            return num;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // LE CUESTA QUE HAYA CLASE, PERO AL FINAL LO CONSIGUE.
            // AL SER ALEATORIO CASI NUNCA HAY.

            Aula aula = new Aula();
            if (aula.darClase()) { aula.notas(); }

            Console.ReadKey();
        }
    }
}
