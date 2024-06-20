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

        public static void Update(Tarefa tarefa, DateTime date)
        {
            tarefa.Data = date.Date;
        }

        public static void Update(Tarefa tarefa, TimeSpan time)
        {
            tarefa.Intervalo = time;
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

        public static bool ImportFromTxt(string line, string delimiter)
        {
            if(string.IsNullOrWhiteSpace(line))
                return false;
    
            string[] data = line.Split(delimiter);
            
            if(data.Count() < 1)
                return false;

            Tarefa tarefa = new Tarefa{
                Id = Convert.ToInt32(data[0] == null ? 0 : data[0])
                , Descricao = data[1] == null ? string.Empty : data[1]
                , Concluido = data[2] == null ? false : Convert.ToBoolean(data[2])
                , Data = data[3] == null ? DateTime.Today.Date : DateTime.Parse(data[3])
                , Intervalo = data[4] == null ? Tarefa.DefaultTime : TimeSpan.Parse(data[4])
            };

            Create(tarefa);
            
            return true;
        }
    }
}
