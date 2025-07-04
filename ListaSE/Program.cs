// Program.cs
using System;
using ListaSE.Lista; // Importa o namespace onde suas classes de lista estão

public class Program
{
    public static void Main(string[] args)
    {
        int mainChoice;

        do
        {
            Console.WriteLine("\n--- Menu Principal de Exercícios ---");
            Console.WriteLine("1. Executar Exercício 1 (Lista Básica)");
            Console.WriteLine("2. Executar Exercício 2 (Lista de Funcionários)");
            Console.WriteLine("3. Executar Exercício 3 (Lista de Disciplinas)");
            Console.WriteLine("0. Sair do Programa Principal");
            Console.Write("Escolha qual exercício deseja executar: ");

            if (int.TryParse(Console.ReadLine(), out mainChoice))
            {
                switch (mainChoice)
                {
                    case 1:
                        Lista listaEx1 = new Lista(); // Instancia a Lista do Exercício 1
                        listaEx1.RunMenuExercicio1(); // Chama o método de menu específico
                        break;
                    case 2:
                        ListaFuncionarios listaEx2 = new ListaFuncionarios(); // Instancia a Lista do Exercício 2
                        listaEx2.RunMenuExercicio2(); // Chama o método de menu específico
                        break;
                    case 3:
                        ListaDisciplinas listaEx3 = new ListaDisciplinas(); // Instancia a Lista do Exercício 3
                        listaEx3.RunMenuExercicio3(); // Chama o método de menu específico
                        break;
                    case 0:
                        Console.WriteLine("Finalizando o programa. Adeus!");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Por favor, escolha novamente.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida. Por favor, digite um número.");
            }
        } while (mainChoice != 0);
    }
}