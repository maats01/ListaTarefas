using System;
using System.Collections.Generic;
using ListaTarefas.Repository;
using ListaTarefas.Model;

namespace ListaTarefas.Controller
{
    public class TarefaController
    {
        public static string CriarTarefa(Tarefa novaTarefa)
        {
            var tarefas = TarefaRepository.Read();
            var tarefaExistente = tarefas.FirstOrDefault(t => t.Data == novaTarefa.Data && t.Intervalo == novaTarefa.Intervalo);

            if (tarefaExistente != null)
            {
                return "Tarefa marcada para esta data e horário, altere por favor.";
            }

            TarefaRepository.Create(novaTarefa);
            return "Tarefa criada com sucesso!";
        }

        public static List<Tarefa> RetornaTarefas()
        {
            return TarefaRepository.Read();
        }

        public static void AtualizarTarefa(Tarefa tarefa, bool status)
        {
            TarefaRepository.Update(tarefa, status);
        }

        public static void AtualizarTarefa(Tarefa tarefa, string desc)
        {
            TarefaRepository.Update(tarefa, desc);
        }

        public static bool DeletarTarefa(Tarefa tarefa)
        {
            return TarefaRepository.Delete(tarefa);
        }

        public static List<Tarefa> RetornaTarefasPorData(DateTime data)
        {
            return TarefaRepository.ReadByDate(data);
        }
    }
}
