using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using ListaTarefas.Repository;
using ListaTarefas.Model;
using ListaTarefas.Utils;

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
                return "Já tem uma tarefa marcada para esta data e horário, altere por favor.";
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

        public static void AtualizarTarefa(Tarefa tarefa, DateTime date)
        {
            TarefaRepository.Update(tarefa, date);
        }

        public static void AtualizarTarefa(Tarefa tarefa, TimeSpan time)
        {
            TarefaRepository.Update(tarefa, time);
        }

        public static bool DeletarTarefa(Tarefa tarefa)
        {
            return TarefaRepository.Delete(tarefa);
        }

        public static List<Tarefa> RetornaTarefasPorData(DateTime data)
        {
            return TarefaRepository.ReadByDate(data);
        }

        public static List<Tarefa> RetornaTarefasEntreDatas(DateTime dataInicial, DateTime dataFinal)
        {
            return TarefaRepository.ReadByInterval(dataInicial, dataFinal);
        }

       public static string ImportarTarefas(string fileName, string delimiter)
        {
            bool result = true;
            string currentDirectory = Directory.GetCurrentDirectory();
            string path = Path.Combine(currentDirectory, "TarefasSalvas", fileName);
            string msgReturn = string.Empty;
            int lineCountSuccess = 0;
            int lineCountError = 0;
            int lineCountTotal = 0;
            
            try
            {
                if(!File.Exists(path))
                    return "ERRO: Arquivo de importação não encontrado.";
                
                using(StreamReader sr = new StreamReader(path))
                {
                    string line = string.Empty;
                    while((line = sr.ReadLine()) != null)
                    {
                        lineCountTotal++;

                        if(!TarefaRepository.ImportFromTxt(line, delimiter))
                        {
                            result = false;
                            lineCountError++;
                        }
                        else
                            lineCountSuccess++;
                    }
                }
            }
            catch(System.Exception ex)
            {
                return $"ERRO: {ex.Message}";
            }

            if(result)
                msgReturn = "Dados importados com sucesso.";
            else
                msgReturn = "Dados parcialmente importados";

            msgReturn += $"\nTotal de linhas: {lineCountTotal}";
            msgReturn += $"\nSucesso: {lineCountSuccess}";
            msgReturn += $"\nErro: {lineCountError}";

            return msgReturn;
        }

        public static bool ExportarTarefas()
        {
            List<Tarefa> list = TarefaRepository.Read();

            string fileName = $"Tarefas_{DateTimeOffset.Now.ToUnixTimeSeconds()}.txt";
            string fileContent = string.Empty;
            foreach(var c in list)
            {
                fileContent += $"{c.PrintToExportDelimited()}\n";
            }

            return ExportToFile.SaveToDelimitedTxt(fileName, fileContent);
        }
    }
}
