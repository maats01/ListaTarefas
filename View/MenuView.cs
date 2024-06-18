using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaTarefas.Controller;
using ListaTarefas.Model;

namespace ListaTarefas.View
{
    public class MenuView
    {
        public static void Main()
        {
            int opcao;

            do
            {
                Console.WriteLine("====================");
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
                        CriarTarefaView();
                    break;

                    case 2:
                        MostrarTarefas();
                    break;

                    case 3:
                        AtualizarTarefasView();
                    break;

                    case 4:
                        DeletarTarefaView();
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

        public static void CriarTarefaView()
        {
            Console.Write("Digite a descrição da tarefa: ");
            string descricao = Console.ReadLine();
            Tarefa novaTarefa = new Tarefa {  
                Descricao = descricao,
                Concluido = false 
            };
            TarefaController.CriarTarefa(novaTarefa);
            Console.WriteLine("Tarefa criada com sucesso!");
        }

        public static void DeletarTarefaView()
        {
            Console.Write("Digite o ID da tarefa que deseja deletar: ");
            int id = int.Parse(Console.ReadLine());
            int resposta;
            var tarefa = TarefaController.RetornaTarefas().FirstOrDefault(t => t.Id == id);
            if (tarefa == null)
            {
                Console.WriteLine("Tarefa não encontrada.");
                return;
            }
            Console.WriteLine("Deseja mesmo deletar esta tarefa? ");
            Console.WriteLine("1 - Sim");
            Console.WriteLine("0 - Não");
            resposta = Convert.ToInt16(Console.ReadLine());
            switch(resposta)
            {
                case 1:
                    bool result = TarefaController.DeletarTarefa(tarefa);
                    if(result)
                    Console.WriteLine("Tarefa deletada com sucesso!");
                break;

                case 0:
                    return;
                
                default:
                    Console.WriteLine("Resposta inválida, tente novamente");
                break;
            }
        }

        public static void MostrarTarefas()
        {
            List<Tarefa> tarefas = TarefaController.RetornaTarefas();
            if (tarefas.Count == 0)
            {
                Console.WriteLine("Nenhuma tarefa encontrada.");
                return;
            }

            foreach (var tarefa in tarefas)
            {
                string status = tarefa.Concluido ? "Sim" : "Não";
                Console.WriteLine($"ID: {tarefa.Id}, Descrição: {tarefa.Descricao}, Concluída: {status}");
            }
        }

        public static void AtualizarTarefasView()
        {
            List<Tarefa> tarefas = TarefaController.RetornaTarefas();
            Console.Write("Digite o ID da tarefa que deseja atualizar: ");
            int id = int.Parse(Console.ReadLine());
            int resposta;
            bool status;
            var tarefa = tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa == null)
            {
                Console.WriteLine("Tarefa não encontrada.");
                return;
            }

            Console.WriteLine("Deseja alterar a descrição da tarefa? ");
            Console.WriteLine("1 - Sim");
            Console.WriteLine("0 - Não");
            resposta = Convert.ToInt16(Console.ReadLine());
            switch(resposta)
            {
                case 1:
                    Console.Write("Digite a nova descrição da tarefa: ");
                    string Descricao = Console.ReadLine();
                    TarefaController.AtualizarTarefa(tarefa, Descricao);
                break;

                case 0:
                break;

                default:
                    Console.WriteLine("Resposta inválida, tente novamente: ");
                break;
            }
            Console.WriteLine("A tarefa foi concluída?");
            Console.WriteLine("1 - Sim");
            Console.WriteLine("0 - Não");
            resposta = Convert.ToInt16(Console.ReadLine());
            switch(resposta)
            {
                case 1:
                    status = true;
                    TarefaController.AtualizarTarefa(tarefa, status);
                break;

                case 0:
                    status = false;
                    TarefaController.AtualizarTarefa(tarefa, status);
                break;    

                default:
                    Console.WriteLine("Resposta inválida, tente novamente: ");
                break;
            }
            Console.WriteLine("Tarefa atualizada com sucesso!");
        }
    }
}