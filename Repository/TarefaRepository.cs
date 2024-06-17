using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaTarefas.Model;
using ListaTarefas.Data;

namespace ListaTarefas.Repository
{
    public class TarefaRepository
    {
        static void CriarTarefa()
        {
        Console.Write("Digite a descrição da tarefa: ");
        string descricao = Console.ReadLine();

        Tarefa novaTarefa = new Tarefa { Id = DataSet.tarefas.Count + 1, Descricao = descricao };
        DataSet.tarefas.Add(novaTarefa);

        Console.WriteLine("Tarefa criada com sucesso!");
        }

        static void ListarTarefas()
        {
            if (DataSet.tarefas.Count == 0)
            {
                Console.WriteLine("Nenhuma tarefa encontrada.");
                return;
            }

            foreach (var tarefa in DataSet.tarefas)
            {
                Console.WriteLine($"ID: {tarefa.Id}, Descrição: {tarefa.Descricao}");
            }
        }

        static void AtualizarTarefa()
        {
            Console.Write("Digite o ID da tarefa que deseja atualizar: ");
            int id = int.Parse(Console.ReadLine());

            var tarefa = DataSet.tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa == null)
            {
                Console.WriteLine("Tarefa não encontrada.");
                return;
            }

            Console.Write("Digite a nova descrição da tarefa: ");
            tarefa.Descricao = Console.ReadLine();

            Console.WriteLine("Tarefa atualizada com sucesso!");
        }

        static void DeletarTarefa()
        {
            Console.Write("Digite o ID da tarefa que deseja deletar: ");
            int id = int.Parse(Console.ReadLine());

            var tarefa = DataSet.tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa == null)
            {
                Console.WriteLine("Tarefa não encontrada.");
                return;
            }

            DataSet.tarefas.Remove(tarefa);

            Console.WriteLine("Tarefa deletada com sucesso!");
        }
    }    
}