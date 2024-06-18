using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaTarefas.Repository;
using ListaTarefas.Model;

namespace ListaTarefas.Controller
{
    public class TarefaController
    {
        public static void CriarTarefa(Tarefa novaTarefa)
        {
            TarefaRepository.Create(novaTarefa);
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
    }
}