using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R31.ReplaceSubclassWithFields.depois
{
    class Programa
    {
        void Main()
        {
            var hospital = new Hospital();
            var paciente1 = Paciente.CriarPacienteHomem();
            var paciente2 = Paciente.CriarPacienteMulher();

            hospital.Atender(paciente1);
            hospital.Atender(paciente2);
        }
    }

    class Paciente
    {
        public char Sexo { get; private set; }

        private Paciente(char sexo)
        {
            Sexo = sexo;
        }

        public static Paciente CriarPacienteHomem()
        {
            return new Paciente('M');
        }

        public static Paciente CriarPacienteMulher()
        {
            return new Paciente('F');
        }
    }

    class Hospital
    {
        void Teste()
        {
            var maria = Paciente.CriarPacienteMulher();
            var jose = Paciente.CriarPacienteHomem();

            Atender(maria);
            Atender(jose);
        }

        public void Atender(Paciente paciente)
        {
            //codigo para atendimento hospitalar...
        }
    }
}
