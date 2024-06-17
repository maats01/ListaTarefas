using System;

class Program
{
    static TarefaController controller = new TarefaController();

    static void Main(string[] args)
    {
        int opcao;

        do
        {
            MostrarMenu();
            opcao = Convert.ToInt32(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    CriarTarefa();
                    break;
                case 2:
                    ListarTarefas();
                    break;
                case 3:
                    AtualizarTarefa();
                    break;
                case 4:
                    DeletarTarefa();
                    break;
                case 5:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        } while (opcao != 5);
    }

    static void MostrarMenu()
    {
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Criar tarefa");
        Console.WriteLine("2. Listar tarefas");
        Console.WriteLine("3. Atualizar tarefa");
        Console.WriteLine("4. Deletar tarefa");
        Console.WriteLine("5. Sair");
        Console.Write("Escolha uma opção: ");
    }

    static void CriarTarefa()
    {
        Console.Write("Digite a descrição da tarefa: ");
        string descricao = Console.ReadLine();

        controller.CriarTarefa(descricao);
        Console.WriteLine("Tarefa criada com sucesso!");
    }

    static void ListarTarefas()
    {
        var tarefas = controller.ListarTarefas();

        if (tarefas.Count == 0)
        {
            Console.WriteLine("Nenhuma tarefa encontrada.");
            return;
        }

        foreach (var tarefa in tarefas)
        {
            Console.WriteLine($"ID: {tarefa.Id}, Descrição: {tarefa.Descricao}");
        }
    }

    static void AtualizarTarefa()
    {
        Console.Write("Digite o ID da tarefa que deseja atualizar: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Digite a nova descrição da tarefa: ");
        string novaDescricao = Console.ReadLine();

        if (controller.AtualizarTarefa(id, novaDescricao))
        {
            Console.WriteLine("Tarefa atualizada com sucesso!");
        }
        else
        {
            Console.WriteLine("Tarefa não encontrada.");
        }
    }

    static void DeletarTarefa()
    {
        Console.Write("Digite o ID da tarefa que deseja deletar: ");
        int id = int.Parse(Console.ReadLine());

        if (controller.DeletarTarefa(id))
        {
            Console.WriteLine("Tarefa deletada com sucesso!");
        }
        else
        {
            Console.WriteLine("Tarefa não encontrada.");
        }
    }
}
