using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace refatoracao.R27.EncapsulateCollection.depois
{
    class Programa
    {
        void Testar()
        {
            Aluno aluno = new Aluno();
            aluno.AddCurso(new Curso("JavaScript Básico"));
            aluno.AddCurso(new Curso("C# Intermediário"));
            aluno.AddCurso(new Curso("Java Avançado"));
        }
    }

    class Aluno
    {
        private readonly List<Curso> cursos;
        public IReadOnlyCollection<Curso> Cursos
        { get { return new ReadOnlyCollection<Curso>(cursos); } }

        public void AddCurso(Curso curso)
        {
            cursos.Add(curso);
        }

        public void RemoveCurso(Curso curso)
        {
            cursos.Remove(curso);
        }

        public Aluno()
        {
            cursos = new List<Curso>();
        }
    }

    class Curso
    {
        readonly string nome;
        public string Nome
        {
            get
            {
                return nome;
            }
        }

        public Curso(string nome)
        {
            this.nome = nome;
        }
    }
}
