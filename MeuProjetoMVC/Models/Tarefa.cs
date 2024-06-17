using System;
using System.Collections.Generic;
using System.Linq;

public class TarefaController
{
    private List<Tarefa> tarefas = new List<Tarefa>();

    public void CriarTarefa(string descricao)
    {
        Tarefa novaTarefa = new Tarefa { Id = tarefas.Count + 1, Descricao = descricao };
        tarefas.Add(novaTarefa);
    }

    public List<Tarefa> ListarTarefas()
    {
        return tarefas;
    }

    public bool AtualizarTarefa(int id, string novaDescricao)
    {
        var tarefa = tarefas.FirstOrDefault(t => t.Id == id);
        if (tarefa != null)
        {
            tarefa.Descricao = novaDescricao;
            return true;
        }
        return false;
    }

    public bool DeletarTarefa(int id)
    {
        var tarefa = tarefas.FirstOrDefault(t => t.Id == id);
        if (tarefa != null)
        {
            tarefas.Remove(tarefa);
            return true;
        }
        return false;
    }
}
