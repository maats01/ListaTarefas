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
    }
}