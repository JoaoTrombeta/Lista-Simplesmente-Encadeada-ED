// DisciplinaNode.cs
using System;

namespace ListaSE.Lista // Adapte este namespace
{
    public class DisciplinaNode
    {
        public string Nome { get; set; }
        public string Periodo { get; set; }
        public int CargaHoraria { get; set; }
        public string ProfessorResponsavel { get; set; }
        public DisciplinaNode Next { get; set; }

        public DisciplinaNode(string nome, string periodo, int cargaHoraria, string professorResponsavel)
        {
            Nome = nome;
            Periodo = periodo;
            CargaHoraria = cargaHoraria;
            ProfessorResponsavel = professorResponsavel;
            Next = null;
        }
    }
}