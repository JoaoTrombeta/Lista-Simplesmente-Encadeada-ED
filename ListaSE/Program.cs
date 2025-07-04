// Program.cs
using System;

public class Program
{
    public static void Main(string[] args)
    {
        Lista lista = new Lista();
        int choice;
        int valor;

        do
        {
            Console.WriteLine("\n--- Menu Lista Simplesmente Encadeada (Exercício 1) ---");
            Console.WriteLine("1. Inserir no Início");
            Console.WriteLine("2. Inserir no Fim");
            Console.WriteLine("3. Remover do Início");
            Console.WriteLine("4. Remover do Fim");
            Console.WriteLine("5. Remover um valor específico (usando o método 'remover')");
            Console.WriteLine("6. Consultar um valor");
            Console.WriteLine("7. Imprimir Lista");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Digite o valor para inserir no início: ");
                        if (int.TryParse(Console.ReadLine(), out valor))
                        {
                            lista.inserirInicio(valor);
                        }
                        else
                        {
                            Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro.");
                        }
                        break;
                    case 2:
                        Console.Write("Digite o valor para inserir no fim: ");
                        if (int.TryParse(Console.ReadLine(), out valor))
                        {
                            lista.inserirFIM(valor);
                        }
                        else
                        {
                            Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro.");
                        }
                        break;
                    case 3:
                        lista.removerInicio();
                        break;
                    case 4:
                        lista.removerFim();
                        break;
                    case 5:
                        Console.Write("Digite o valor a ser removido: ");
                        if (int.TryParse(Console.ReadLine(), out valor))
                        {
                            lista.remover(valor);
                        }
                        else
                        {
                            Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro.");
                        }
                        break;
                    case 6:
                        Console.Write("Digite o valor para consultar: ");
                        if (int.TryParse(Console.ReadLine(), out valor))
                        {
                            No noAtual = null;
                            No noAnterior = null;
                            if (lista.consulta(valor, ref noAtual, ref noAnterior))
                            {
                                Console.WriteLine($"O valor {valor} foi encontrado na lista.");
                            }
                            else
                            {
                                Console.WriteLine($"O valor {valor} NÃO foi encontrado na lista.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro.");
                        }
                        break;
                    case 7:
                        lista.imprimir();
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
}