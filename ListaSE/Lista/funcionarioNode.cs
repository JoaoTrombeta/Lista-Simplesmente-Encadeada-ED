
using System;

namespace ListaSE.Lista
{
    public class FuncionarioNode
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Telefone { get; set; }
        public double Salario { get; set; }
        public FuncionarioNode Next { get; set; }

        public FuncionarioNode(string nome, int idade, string telefone, double salario)
        {
            Nome = nome;
            Idade = idade;
            Telefone = telefone;
            Salario = salario;
            Next = null;
        }
    }
}