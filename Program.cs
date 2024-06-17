using System;
using System.Collections.Generic;
using System.Linq;
using ListaTarefas.Model;
using ListaTarefas.Controller;
using ListaTarefas.Data;

class Program
{
    static void Main(string[] args)
    {
        int opcao;

        do
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Criar tarefa");
            Console.WriteLine("2. Listar tarefas");
            Console.WriteLine("3. Atualizar tarefa");
            Console.WriteLine("4. Deletar tarefa");
            Console.WriteLine("5. Sair");
            Console.Write("Escolha uma opção: ");
            opcao = Convert.ToInt32(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    CriarTarefa();
                    break;
                case 2:
                    ListarTarefas();
                    break;
                case 3:
                    AtualizarTarefa();
                    break;
                case 4:
                    DeletarTarefa();
                    break;
                case 5:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        } while (opcao != 5);
    }
}