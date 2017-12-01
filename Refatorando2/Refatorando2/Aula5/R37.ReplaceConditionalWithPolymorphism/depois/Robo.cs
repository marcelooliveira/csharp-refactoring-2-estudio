using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R37.ReplaceConditionalWithPolymorphism.depois
{
    class Pograma
    {
        void Main()
        {
            var r2d2 = new R2D2(10, 5, 20);
            var wally = new Wally(20, 25, 5, 10);
            var baymax = new Baymax(90, 170, 40, true);

            Console.WriteLine($"Velocidade do r2d2: {r2d2.GetVelocidade()}");
            Console.WriteLine($"Velocidade do wally: {wally.GetVelocidade()}");
            Console.WriteLine($"Velocidade do baymax: {baymax.GetVelocidade()}");
        }
    }

    public abstract class Robo
    {
        private readonly double velocidadePadrao = 12.43;
        private readonly double capacidadeDeCarga = 1.67;
        protected readonly double potencia;

        private const int R2D2 = 0;
        private const int WALLY = 1;
        private const int BAYMAX = 2;

        public Robo(double velocidadePadrao, double capacidadeDeCarga, double potencia)
        {
            this.velocidadePadrao = velocidadePadrao;
            this.capacidadeDeCarga = capacidadeDeCarga;
            this.potencia = potencia;
        }

        public double GetCapacidadeDeCarga()
        {
            return capacidadeDeCarga;
        }

        public double GetVelocidadePadrao()
        {
            return GetVelocidadePadrao(1);
        }

        public double GetVelocidadePadrao(double potencia)
        {
            return velocidadePadrao * potencia;
        }

        public abstract double GetVelocidade();
    }

    public class R2D2 : Robo
    {
        public override double GetVelocidade()
        {
            return GetVelocidadePadrao();
        }

        public R2D2(double velocidadePadrao, double capacidadeDeCarga, double potencia)
            : base(velocidadePadrao, capacidadeDeCarga, potencia)
        { }
    }

    public class Wally : Robo
    {
        private readonly int numeroDeBlocos;
        public override double GetVelocidade()
        {
            return GetVelocidadePadrao() - GetCapacidadeDeCarga() * numeroDeBlocos;
        }

        public Wally(double velocidadePadrao, double capacidadeDeCarga, double potencia, int numeroDeBlocos)
            : base(velocidadePadrao, capacidadeDeCarga, potencia)
        {
            this.numeroDeBlocos = numeroDeBlocos;
        }
    }

    public class Baymax : Robo
    {
        private readonly bool comArmadura;
        public override double GetVelocidade()
        {
            return comArmadura ? 0 : GetVelocidadePadrao(potencia);
        }

        public Baymax(double velocidadePadrao, double capacidadeDeCarga, double potencia
            , bool comArmadura)
            : base(velocidadePadrao, capacidadeDeCarga, potencia)
        {
            this.comArmadura = comArmadura;
        }
    }
}
