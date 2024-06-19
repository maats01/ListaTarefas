using System;
using System.Collections.Generic;
using System.Linq;
using ListaTarefas.Model;
using ListaTarefas.Data;

namespace ListaTarefas.Repository
{
    public class TarefaRepository
    {
        public static void Create(Tarefa novaTarefa)
        {
            novaTarefa.Id = DataSet.tarefas.Count + 1;
            DataSet.tarefas.Add(novaTarefa);
        }

        public static List<Tarefa> Read()
        {
            return DataSet.tarefas;
        }

        public static void Update(Tarefa tarefa, string desc)
        {
            tarefa.Descricao = desc;
        }

        public static void Update(Tarefa tarefa, bool status)
        {
            tarefa.Concluido = status;
        }

        public static bool Delete(Tarefa tarefa)
        {
            return DataSet.tarefas.Remove(tarefa);            
        }

        public static List<Tarefa> ReadByDate(DateTime data)
        {
            return DataSet.tarefas
                .Where(t => t.Data.Date == data.Date)
                .ToList();
        }

        public static List<Tarefa> ReadByInterval(DateTime dataInicial, DateTime dataFinal)
        {
            return DataSet.tarefas
                .Where(t => t.Data.Date >= dataInicial.Date && t.Data.Date <= dataFinal.Date)
                .ToList();
        }
    }
}
