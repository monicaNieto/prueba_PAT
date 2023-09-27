using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Puerta
    {
        bool abierta;
        string nombre;
        public void abrir()
        {
            abierta = true;
            Console.WriteLine(nombre + ":Abriendo");
        }
        public virtual void cerrar()
        {
            abierta = false;
            Console.WriteLine(nombre + ":Cerrando");
        }
        public override string ToString()
        {
            var msg = nombre + ":Estado";
            if (abierta)
                msg += "abierta";
            else msg += "cerrada";
            return msg;
        }
        public Puerta(string nom)
        {
            abierta = false;
            nombre = nom;
            Console.WriteLine("Constructor Puerta");
        }
        protected string getNombre()
        {
            return nombre;
        }
        ~Puerta()
        {
            cerrar();
            Console.WriteLine("Destructor puerta");
        }
    }
    class PuertaHeladera : Puerta
    {
        List<string> cosas;
        public PuertaHeladera(string n) : base(n)
        {
            cosas = new List<string>();
            Console.WriteLine(getNombre() + ":Constructor PuertaHeladera");
        }
        ~PuertaHeladera()
        {
            Console.WriteLine(getNombre() + ":Destructor PuertaHeladera");
        }
        public override string ToString()
        {
            string msg = base.ToString() + "\n";
            msg += getNombre() + ":PuertaHeladera: ";
            foreach (String n in cosas)
            {
                msg += n + ",";
            }
            return msg;
        }
        public override void cerrar()
        {
            Console.WriteLine(getNombre() + ":Apagando luz de la Heladera");
        }
        public new void abrir()
        {
            base.abrir();
            Console.WriteLine(getNombre() + ":Prendiendo luz de la Heladera");
        }
    }
    class PuertaSeguridad : Puerta
    {
        bool estado; // true si esta trabada, false si no lo esta.
        public PuertaSeguridad(string n) : base(n)
        {
            estado = true;
            Console.WriteLine(getNombre() + ":Constructor PuertaSeguridad");
        }
        ~PuertaSeguridad()
        {
            Console.WriteLine(getNombre() + ":Destructor PuertaSeguridad");
        }
        public new void abrir()
        {
            if (false == estado)
            {
                base.abrir();
            }
            else
                Console.WriteLine(getNombre() + ": No se puede abrir, esta trabada");
        }
        public void trabar()
        {
            estado = true;
        }
        public void destrabar()
        {
            estado = false;
        }
    }
    class PuertaAuto : PuertaSeguridad
    {
        bool bloqueoChicos;
        public PuertaAuto(string m) : base(m)
        {
            Console.WriteLine(getNombre() + ":Constructor PuertaAuto");
            bloquearChicos();
        }
        public void bloquearChicos()
        {
            bloqueoChicos = true;
            Console.WriteLine(getNombre() + ":Bloqueando puerta para los chicos");
        }
        public void desBloquearChicos()
        {
            bloqueoChicos = false;
            Console.WriteLine(getNombre() + ":desbloqueando puerta para los chicos");
        }
    }

    class Program
    {
        static void pruebaDePuertas()
        {
            var p = new Puerta("Comedor");
            p.abrir();
            p.cerrar();
            Console.WriteLine(p);
            var hela = new PuertaHeladera("HeladeraCocina");
            hela.abrir();
            hela.cerrar();
            Console.WriteLine(hela);
            var pSeg = new PuertaSeguridad("Tranquera");
            pSeg.abrir();
            pSeg.cerrar();
            pSeg.trabar();
            pSeg.destrabar();
            Console.WriteLine(pSeg);
            var pAuto = new PuertaAuto("Ferrari");
            pAuto.abrir();
            pAuto.cerrar();
            pAuto.trabar();
            pSeg.destrabar();
            pAuto.desBloquearChicos();
            pAuto.bloquearChicos();
            Console.WriteLine(pAuto);
        }
        static void Main(string[] args)
        {
            pruebaDePuertas();
        GC.Collect();
        Console.WriteLine("Terminando");
        Console.ReadKey();
    }
}

