using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaTarefas.Model;

namespace ListaTarefas.Data
{
    public class DataSet
    {
        public static List<Tarefa> tarefas { get; set; } = new List<Tarefa>();
    }
}