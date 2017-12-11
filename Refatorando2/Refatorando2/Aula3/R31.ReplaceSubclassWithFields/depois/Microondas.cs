using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R31.ReplaceSubclassWithFields.depois
{
    class Programa
    {
        void Main()
        {
            var fabrica = new Fabrica();
            fabrica.Fabricar();
        }
    }

    public class Microondas
    {
        private readonly int voltagem;

        private Microondas(int voltagem)
        {
            this.voltagem = voltagem;
        }

        public int GetVoltagem()
        {
            return voltagem;
        }

        public static Microondas CriarVersao110Volts()
        {
            return new Microondas(110);
        }

        public static Microondas CriarVersao220Volts()
        {
            return new Microondas(220);
        }
    }

    class Fabrica
    {
        public void Fabricar()
        {
            var aparelho1 = Microondas.CriarVersao110Volts();
            var aparelho2 = Microondas.CriarVersao220Volts();

            Fabricar(aparelho1);
            Fabricar(aparelho2);
        }

        public void Fabricar(Microondas microondas)
        {
            //código para fabricar equipamento...
        }
    }
}
