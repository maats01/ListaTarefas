using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaTarefas.Model
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Concluido { get; set; }
        public DateTime Data { get; set; } 
        public TimeSpan Intervalo { get; set; }

        public static TimeSpan DefaultTime { get; set;} = new TimeSpan(12, 0, 0);

        public override string ToString()
        {
            string status = Concluido ? "Sim" : "Não";
            return $"ID: {Id} - Descrição: {Descricao} - Concluído: {status} - Data: {Data.ToString("dd/MM/yyyy")} - Horário: {Intervalo}";
        }

        public string PrintToExportDelimited()
        {
            return $"{Id}|{Descricao}|{Concluido}|{Data.ToString("dd/MM/yyyy")}|{Intervalo}";
        }
    }
}