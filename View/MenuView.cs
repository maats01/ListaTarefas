using System;
using System.Collections.Generic;
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
                Console.WriteLine("2. Listar todas as tarefas");
                Console.WriteLine("3. Atualizar tarefa");
                Console.WriteLine("4. Deletar tarefa");
                Console.WriteLine("5. Listar tarefas em determinada data");
                Console.WriteLine("6. Listar tarefas entre datas");
                Console.WriteLine("7. Importar tarefas ");
                Console.WriteLine("8. Exportar tarefas ");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    continue;
                }

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
                        ListarTarefasEmData();
                        break;
                    
                    case 6:
                        ListarTarefasEntreDatas();
                        break;

                    case 7:
                        ImportarTarefas();
                        break;
                    
                    case 8: 
                        if(TarefaController.ExportarTarefas())
                            Console.WriteLine("Tarefas Salvas");
                        else
                            Console.WriteLine("Algo deu errado");
                        break;

                    case 0:
                        Console.WriteLine("Saindo...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            } while (opcao != 0);
        }

        public static void CriarTarefaView()
        {
            Console.Write("Digite a descrição da tarefa: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite a data da tarefa (dia/mes/ano): ");
            DateTime data;
            while (!DateTime.TryParse(Console.ReadLine(), out data))
            {
                Console.Write("Data inválida. Digite novamente (dia/mes/ano): ");
            }

            Console.Write("Digite o intervalo da tarefa (horas:minutos:segundos): ");
            TimeSpan intervalo;
            while (!TimeSpan.TryParse(Console.ReadLine(), out intervalo))
            {
                Console.Write("Intervalo inválido. Digite novamente (horas:minutos:segundos): ");
            }

            Tarefa novaTarefa = new Tarefa
            {
                Descricao = descricao,
                Concluido = false,
                Data = data,
                Intervalo = intervalo
            };

            string resultado = TarefaController.CriarTarefa(novaTarefa);
            Console.WriteLine(resultado);
        }

        public static void DeletarTarefaView()
        {
            Console.Write("Digite o ID da tarefa que deseja deletar: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("ID inválido. Digite novamente: ");
            }

            var tarefa = TarefaController.RetornaTarefas().FirstOrDefault(t => t.Id == id);
            if (tarefa == null)
            {
                Console.WriteLine("Tarefa não encontrada.");
                return;
            }

            Console.WriteLine($"Deseja mesmo deletar a seguinte tarefa?");
            Console.WriteLine($"ID: {tarefa.Id}, Descrição: {tarefa.Descricao}, Concluída: {tarefa.Concluido}, Data: {tarefa.Data.ToString("dd/MM/yyyy")}, Intervalo: {tarefa.Intervalo}");
            Console.WriteLine("1 - Sim");
            Console.WriteLine("0 - Não");
            int resposta;
            while (!int.TryParse(Console.ReadLine(), out resposta) || (resposta != 0 && resposta != 1))
            {
                Console.WriteLine("Opção inválida. Digite 1 para Sim ou 0 para Não.");
            }

            if (resposta == 1)
            {
                bool result = TarefaController.DeletarTarefa(tarefa);
                if (result)
                    Console.WriteLine("Tarefa deletada com sucesso!");
                else
                    Console.WriteLine("Erro ao deletar tarefa.");
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

            Console.WriteLine("Lista de tarefas:");
            foreach (var tarefa in tarefas)
            {
                Console.WriteLine(tarefa.ToString());
            }
        }

        public static void MostrarTarefas(List<Tarefa> tarefas)
        {
            if (tarefas.Count == 0)
            {
                Console.WriteLine("Nenhuma tarefa encontrada no intervalo especificado.");
                return;
            }

            Console.WriteLine("Tarefas encontradas na data especificada:");
            foreach (var tarefa in tarefas)
            {
                Console.WriteLine(tarefa.ToString());
            }
        }

        public static void AtualizarTarefasView()
        {
            List<Tarefa> tarefas = TarefaController.RetornaTarefas();
            Console.Write("Digite o ID da tarefa que deseja atualizar: ");
            int id;
            while(!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("ID inválido. Digite novamente: ");
            }

            var tarefa = tarefas.FirstOrDefault(t => t.Id == id);
            if(tarefa == null)
            {
                Console.WriteLine("Tarefa não encontrada.");
                return;
            }

            Console.WriteLine($"Tarefa encontrada:");
            Console.WriteLine(tarefa.ToString());

            Console.WriteLine("Deseja alterar a descrição da tarefa? ");
            Console.WriteLine("1 - Sim");
            Console.WriteLine("0 - Não");
            int resposta;
            while (!int.TryParse(Console.ReadLine(), out resposta) || (resposta != 0 && resposta != 1))
            {
                Console.WriteLine("Opção inválida. Digite 1 para Sim ou 0 para Não.");
            }

            if(resposta == 1)
            {
                Console.Write("Digite a nova descrição da tarefa: ");
                string descricao = Console.ReadLine();
                TarefaController.AtualizarTarefa(tarefa, descricao);
            }

            Console.WriteLine("A tarefa foi concluída?");
            Console.WriteLine("1 - Sim");
            Console.WriteLine("0 - Não");
            while (!int.TryParse(Console.ReadLine(), out resposta) || (resposta != 0 && resposta != 1))
            {
                Console.WriteLine("Opção inválida. Digite 1 para Sim ou 0 para Não.");
            }

            bool status = resposta == 1 ? true : false;
            TarefaController.AtualizarTarefa(tarefa, status);

            Console.WriteLine("Deseja alterar a data da tarefa? ");
            Console.WriteLine("1 - Sim");
            Console.WriteLine("0 - Não");
        
            while(!int.TryParse(Console.ReadLine(), out resposta) || (resposta != 0 && resposta != 1))
            {
                Console.WriteLine("Opção inválida. Digite 1 para Sim ou 0 para Não.");
            }

            if(resposta == 1)
            {
                Console.WriteLine("Digite a nova data da tarefa (dia/mês/ano): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                TarefaController.AtualizarTarefa(tarefa, date);
            }

            Console.WriteLine("Deseja alterar o horário da tarefa? ");
            Console.WriteLine("1 - Sim");
            Console.WriteLine("0 - Não");
        
            while(!int.TryParse(Console.ReadLine(), out resposta) || (resposta != 0 && resposta != 1))
            {
                Console.WriteLine("Opção inválida. Digite 1 para Sim ou 0 para Não.");
            }

            if(resposta == 1)
            {
                Console.WriteLine("Digite o novo horário da tarefa (horas:minutos:segundos): ");
                TimeSpan time = TimeSpan.Parse(Console.ReadLine());
                TarefaController.AtualizarTarefa(tarefa, time);
            }

            Console.WriteLine("Tarefa atualizada com sucesso!");
        }

        public static void ListarTarefasEmData()
        {
            Console.Write("Digite a data para listar as tarefas (dia/mês/ano): ");
            DateTime data;
            while (!DateTime.TryParse(Console.ReadLine(), out data))
            {
                Console.Write("Data inválida. Digite novamente (dia/mês/ano): ");
            }

            List<Tarefa> tarefasNaData = TarefaController.RetornaTarefasPorData(data);
            MostrarTarefas(tarefasNaData);
        }

        public static void ListarTarefasEntreDatas()
        {
            Console.Write("Digite a data inicial da pesquisa (dia/mês/ano): ");
            DateTime dataInicial;
            while (!DateTime.TryParse(Console.ReadLine(), out dataInicial))
            {
                Console.Write("Data inválida. Digite novamente (dia/mês/ano): ");
            }

            Console.Write("Digite a data final da pesquisa (dia/mês/ano): ");
            DateTime dataFinal;
            while (!DateTime.TryParse(Console.ReadLine(), out dataFinal))
            {
                Console.Write("Data inválida. Digite novamente (dia/mês/ano): ");
            }

            Console.WriteLine("Tarefas encontradas no intervalo especificado: ");
            List<Tarefa> tarefas = TarefaController.RetornaTarefasEntreDatas(dataInicial, dataFinal);
            MostrarTarefas(tarefas);
        }
    
        public static void ImportarTarefas()
        {
            Console.WriteLine("Informe o nome do arquivo (dentro da pasta TarefasSalvas): ");
            string fileName = Console.ReadLine();
            Console.WriteLine("Informe o caractere delimitador: ");
            string delimiter = Console.ReadLine();

            string response = TarefaController.ImportarTarefas(fileName, delimiter);
            Console.WriteLine(response);
        }
    }
}
