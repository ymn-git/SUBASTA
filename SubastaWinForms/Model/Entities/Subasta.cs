using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SubastaWinForms.Model.Entities
{
    public class Subasta
    {
        int numeroSubasta;
        decimal pujaInicial; // precio base
        decimal montoActual; // monto actualizado luego de cada puja
        decimal pujaDeAumento; 
        DateTime fechaInicio; // fecha y hora de inicio
        TimeSpan duracion;
        Subastador subastador;
        Articulo articulo;
        Postor ganador; // acá se agrega el que va ganando cada vez que él puja (boton pujar click)
        List<Postor> postores; //acá se agregan todos los que han participado
        private System.Windows.Forms.Timer timer;

        //evento
        public event EventHandler EventoSubastaFinalizada;

        //constructor
        public Subasta(decimal pujaInicial, decimal pujaDeAumento, TimeSpan duracion, Subastador subastador, Articulo articuloPorSubastar)
        {
            this.PujaInicial = pujaInicial;
            this.MontoActual = pujaInicial;
            this.PujaDeAumento = pujaDeAumento;
            this.FechaInicio = DateTime.Now;
            //this.duracion = TimeSpan.FromHours(24);
            this.Duracion = duracion;
            this.Subastador = subastador;
            this.Articulo = articuloPorSubastar;
            this.ganador = null;
            this.postores = new List<Postor>();
            InicializarTimer();
        }

        public string NombreSubastador => Subastador?.Nombre ?? "";
        public string NombreArticulo => Articulo?.Name ?? "";

        //propiedades
        public int NumeroDeSubasta
        {
            get { return numeroSubasta; }
            internal set { numeroSubasta = value; } // ← solo el repositorio puede asignarlo
        }
        public decimal PujaInicial
        {
            get { return pujaInicial; }
            set
            {
                if (value < 1)
                    throw new ArgumentException("Ingrese un monto válido para la subasta (monto mínimo $1.00).");
                pujaInicial = value;
            }
        }

        public decimal PujaDeAumento
        {
            get { return pujaDeAumento; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("La puja de aumento debe ser mayor a cero.");
                pujaDeAumento = value;
            }
        }
        public DateTime FechaInicio 
        { 
            set { fechaInicio = value; } 
            get { return fechaInicio; } 
        }
        public TimeSpan Duracion 
        { 
            set 
            { 
                //es una redundancia validar aca porque ya se hizo en SubastadorView.cs pero igual sirve
                if (value.TotalMinutes < 1)
                    throw new ArgumentException("Ingrese una duración válida para su subasta, al menos un minuto.");
                duracion = value; 
            } 
            get { return duracion; } 
        } 
        public Subastador Subastador
        {
            set { subastador = value; }
            get { return subastador; }
        }
        public Articulo Articulo
        {
            get { return articulo; }
            set { articulo = value; }
        }
        public Postor Ganador
        {
            get { return ganador; }
            set { ganador = value; }
        }
        public decimal MontoActual
        {
            set {  montoActual = value; }
            get { return montoActual; }
        }
        public string TiempoRestante
        {
            get
            {
                if (EstaFinalizada)
                    return "Finalizada";

                TimeSpan restante = (fechaInicio + duracion) - DateTime.Now;
                return $"{restante.Hours:D2}:{restante.Minutes:D2}:{restante.Seconds:D2}";
            }
        }
        public bool EstaFinalizada
        {
            get { return DateTime.Now > fechaInicio + duracion; }
        }

        //metodos
        private void InicializarTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += (s, e) =>
            {
                if (EstaFinalizada)
                {
                    timer.Stop();
                    EventoSubastaFinalizada?.Invoke(this, EventArgs.Empty);
                }
            };
            timer.Start();
        }


        public void RegistrarGanador(Postor postor)
        {
            if (EstaFinalizada)
                throw new InvalidOperationException("La subasta ya finalizó.");

            MontoActual += PujaDeAumento;
            Ganador = postor;
        }

        // esto es solo para agregar a la lista (atributo de Subasta) los que participan
        //if (!postores.Contains(postor))
        //    postores.Add(postor);

    }



}

