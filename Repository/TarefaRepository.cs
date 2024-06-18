using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaTarefas.Model;
using ListaTarefas.Data;
using System.Runtime.InteropServices;

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
    }    
}