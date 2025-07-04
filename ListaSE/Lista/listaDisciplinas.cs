// ListaDisciplinas.cs
using System;

namespace ListaSE.Lista // Adapte este namespace
{
    public class ListaDisciplinas
    {
        private DisciplinaNode head;

        public ListaDisciplinas()
        {
            head = null;
        }

        public void RunMenuExercicio3()
        {
            int choice;
            do
            {
                Console.WriteLine("\n--- Menu Lista de Disciplinas (Exercício 3) ---");
                Console.WriteLine("1. Inserir Disciplina Ordenadamente por Nome");
                Console.WriteLine("2. Consultar Disciplina por Nome");
                Console.WriteLine("3. Remover Disciplina por Nome");
                Console.WriteLine("4. Imprimir Todas as Disciplinas");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            InserirOrdenadoPorNome();
                            break;
                        case 2:
                            Console.Write("Digite o nome da disciplina para buscar: ");
                            string nomeBusca = Console.ReadLine();
                            ConsultarPorNome(nomeBusca);
                            break;
                        case 3:
                            Console.Write("Digite o nome da disciplina para remover: ");
                            string nomeRemover = Console.ReadLine();
                            RemoverPorNome(nomeRemover);
                            break;
                        case 4:
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

        private DisciplinaNode GetDisciplinaData()
        {
            Console.Write("Nome da disciplina: ");
            string nome = Console.ReadLine();
            Console.Write("Período: ");
            string periodo = Console.ReadLine();
            Console.Write("Carga Horária: ");
            int cargaHoraria = int.Parse(Console.ReadLine());
            Console.Write("Professor Responsável: ");
            string professor = Console.ReadLine();
            return new DisciplinaNode(nome, periodo, cargaHoraria, professor);
        }

        public void InserirOrdenadoPorNome()
        {
            try
            {
                DisciplinaNode novaDisciplina = GetDisciplinaData();
                if (head == null || string.Compare(novaDisciplina.Nome, head.Nome, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    novaDisciplina.Next = head;
                    head = novaDisciplina;
                    Console.WriteLine($"Disciplina '{novaDisciplina.Nome}' inserida no início (ordenadamente).");
                    return;
                }
                DisciplinaNode current = head;
                while (current.Next != null && string.Compare(novaDisciplina.Nome, current.Next.Nome, StringComparison.OrdinalIgnoreCase) > 0)
                {
                    current = current.Next;
                }
                novaDisciplina.Next = current.Next;
                current.Next = novaDisciplina;
                Console.WriteLine($"Disciplina '{novaDisciplina.Nome}' inserida ordenadamente.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro de formato na entrada. Certifique-se de digitar um número para carga horária.");
            }
        }

        public bool ConsultarPorNome(string nomeBusca)
        {
            if (string.IsNullOrWhiteSpace(nomeBusca))
            {
                Console.WriteLine("Nome para busca não pode ser vazio.");
                return false;
            }
            DisciplinaNode atual = head;
            while (atual != null)
            {
                if (atual.Nome.Equals(nomeBusca, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"\nDisciplina '{nomeBusca}' encontrada:");
                    Console.WriteLine($"  Nome: {atual.Nome}");
                    Console.WriteLine($"  Período: {atual.Periodo}");
                    Console.WriteLine($"  Carga Horária: {atual.CargaHoraria}h");
                    Console.WriteLine($"  Professor Responsável: {atual.ProfessorResponsavel}");
                    return true;
                }
                atual = atual.Next;
            }
            Console.WriteLine($"Disciplina '{nomeBusca}' NÃO foi encontrada na lista.");
            return false;
        }

        public void RemoverPorNome(string nomeRemover)
        {
            if (head == null)
            {
                Console.WriteLine("A lista de disciplinas está vazia. Nada para remover.");
                return;
            }
            if (head.Nome.Equals(nomeRemover, StringComparison.OrdinalIgnoreCase))
            {
                head = head.Next;
                Console.WriteLine($"Disciplina '{nomeRemover}' removida do início da lista.");
                return;
            }
            DisciplinaNode current = head;
            DisciplinaNode previous = null;
            while (current != null && !current.Nome.Equals(nomeRemover, StringComparison.OrdinalIgnoreCase))
            {
                previous = current;
                current = current.Next;
            }
            if (current == null)
            {
                Console.WriteLine($"Disciplina '{nomeRemover}' NÃO encontrada na lista para remoção.");
                return;
            }
            if (previous != null)
            {
                previous.Next = current.Next;
                Console.WriteLine($"Disciplina '{nomeRemover}' removida da lista.");
            }
        }

        public void ImprimirLista()
        {
            if (head == null)
            {
                Console.WriteLine("A lista de disciplinas está vazia.");
                return;
            }
            Console.WriteLine("\n--- Disciplinas na Lista ---");
            DisciplinaNode atual = head;
            while (atual != null)
            {
                Console.WriteLine($"Nome: {atual.Nome}");
                Console.WriteLine($"  Período: {atual.Periodo}");
                Console.WriteLine($"  Carga Horária: {atual.CargaHoraria}h");
                Console.WriteLine($"  Professor Responsável: {atual.ProfessorResponsavel}");
                Console.WriteLine("----------------------------");
                atual = atual.Next;
            }
            Console.WriteLine("----------------------------\n");
        }
    }
}