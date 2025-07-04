// ListaFuncionarios.cs
using System;

namespace ListaSE.Lista // Adapte este namespace
{
    public class ListaFuncionarios
    {
        private FuncionarioNode head;

        public ListaFuncionarios()
        {
            head = null;
        }

        public void RunMenuExercicio2()
        {
            int choice;
            do
            {
                Console.WriteLine("\n--- Menu Lista de Funcionários (Exercício 2) ---");
                Console.WriteLine("1. Inserir Funcionário no Início");
                Console.WriteLine("2. Inserir Funcionário no Fim");
                Console.WriteLine("3. Consultar Funcionário por Nome");
                Console.WriteLine("4. Remover Funcionário do Início");
                Console.WriteLine("5. Remover Funcionário do Fim");
                Console.WriteLine("6. Imprimir Todos os Funcionários");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            InserirInicioFuncionario();
                            break;
                        case 2:
                            InserirFimFuncionario();
                            break;
                        case 3:
                            Console.Write("Digite o nome do funcionário para buscar: ");
                            string nomeBusca = Console.ReadLine();
                            ConsultarPorNome(nomeBusca);
                            break;
                        case 4:
                            RemoverInicio();
                            break;
                        case 5:
                            RemoverFim();
                            break;
                        case 6:
                            ImprimirLista();
                            break;
                        case 0:
                            Console.WriteLine("Saindo do programa.");
                            break;
                        default:
                            Console.WriteLine("Opção inválida. Tente novamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, digite um número.");
                }
            } while (choice != 0);
        }

        private FuncionarioNode GetFuncionarioData()
        {
            Console.Write("Nome do funcionário: ");
            string nome = Console.ReadLine();
            Console.Write("Idade: ");
            int idade = int.Parse(Console.ReadLine());
            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();
            Console.Write("Salário: ");
            double salario = double.Parse(Console.ReadLine());
            return new FuncionarioNode(nome, idade, telefone, salario);
        }

        public void InserirInicioFuncionario()
        {
            try
            {
                FuncionarioNode novoFuncionario = GetFuncionarioData();
                novoFuncionario.Next = head;
                head = novoFuncionario;
                Console.WriteLine($"Funcionário '{novoFuncionario.Nome}' inserido no início da lista.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro de formato na entrada. Certifique-se de digitar números para idade e salário.");
            }
        }

        public void InserirFimFuncionario()
        {
            try
            {
                FuncionarioNode novoFuncionario = GetFuncionarioData();
                if (head == null)
                {
                    head = novoFuncionario;
                    Console.WriteLine($"Funcionário '{novoFuncionario.Nome}' inserido no fim da lista (lista vazia).");
                    return;
                }

                FuncionarioNode current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = novoFuncionario;
                Console.WriteLine($"Funcionário '{novoFuncionario.Nome}' inserido no fim da lista.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro de formato na entrada. Certifique-se de digitar números para idade e salário.");
            }
        }

        public bool ConsultarPorNome(string nomeBusca)
        {
            if (string.IsNullOrWhiteSpace(nomeBusca))
            {
                Console.WriteLine("Nome para busca não pode ser vazio.");
                return false;
            }
            FuncionarioNode atual = head;
            while (atual != null)
            {
                if (atual.Nome.Equals(nomeBusca, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"\nFuncionário '{nomeBusca}' encontrado:");
                    Console.WriteLine($"  Nome: {atual.Nome}");
                    Console.WriteLine($"  Idade: {atual.Idade}");
                    Console.WriteLine($"  Telefone: {atual.Telefone}");
                    Console.WriteLine($"  Salário: R${atual.Salario:F2}");
                    return true;
                }
                atual = atual.Next;
            }
            Console.WriteLine($"Funcionário '{nomeBusca}' NÃO foi encontrado na lista.");
            return false;
        }

        public void RemoverInicio()
        {
            if (head == null)
            {
                Console.WriteLine("A lista de funcionários está vazia. Nada para remover do início.");
                return;
            }
            string nomeRemovido = head.Nome;
            head = head.Next;
            Console.WriteLine($"Funcionário '{nomeRemovido}' removido do início da lista.");
        }

        public void RemoverFim()
        {
            if (head == null)
            {
                Console.WriteLine("A lista de funcionários está vazia. Nada para remover do fim.");
                return;
            }
            if (head.Next == null)
            {
                string nomeRemovido = head.Nome;
                head = null;
                Console.WriteLine($"Funcionário '{nomeRemovido}' removido do fim da lista (era o único).");
                return;
            }
            FuncionarioNode current = head;
            FuncionarioNode previous = null;
            while (current.Next != null)
            {
                previous = current;
                current = current.Next;
            }
            if (previous != null)
            {
                previous.Next = null;
                Console.WriteLine($"Funcionário '{current.Nome}' removido do fim da lista.");
            }
        }

        public void ImprimirLista()
        {
            if (head == null)
            {
                Console.WriteLine("A lista de funcionários está vazia.");
                return;
            }
            Console.WriteLine("\n--- Funcionários na Lista ---");
            FuncionarioNode atual = head;
            while (atual != null)
            {
                Console.WriteLine($"Nome: {atual.Nome}");
                Console.WriteLine($"  Idade: {atual.Idade}");
                Console.WriteLine($"  Telefone: {atual.Telefone}");
                Console.WriteLine($"  Salário: R${atual.Salario:F2}");
                Console.WriteLine("-----------------------------");
                atual = atual.Next;
            }
            Console.WriteLine("-----------------------------\n");
        }
    }
}