using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R31.ReplaceSubclassWithFields.antes
{
    class Programa
    {
        void Main()
        {
            var hospital = new Hospital();
            var paciente1 = new Mulher();
            var paciente2 = new Homem();

            hospital.Atender(paciente1);
            hospital.Atender(paciente2);
        }
    }

    abstract class Paciente
    {
        public abstract char GetSexo();
    }

    class Homem : Paciente
    {
        public override char GetSexo()
        {
            return 'M';
        }
    }

    class Mulher : Paciente
    {
        public override char GetSexo()
        {
            return 'F';
        }
    }

    class Hospital
    {
        void Teste()
        {
            var maria = new Mulher();
            var jose = new Homem();

            Atender(maria);
            Atender(jose);
        }

        public void Atender(Paciente paciente)
        {
            //codigo para atendimento hospitalar...
        }
    }
}
