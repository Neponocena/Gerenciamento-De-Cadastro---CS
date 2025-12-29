using System;
using System.IO;

namespace PIM
{
    public static class Log
    {
        public const string CAMINHO = "Dados/log.txt";

        public static void Registrar(string mensagem)
        {
            string registro = $"{DateTime.Now:dd/MM/yyyy HH:mm:ss} - {mensagem}";
            File.AppendAllText(CAMINHO, registro + Environment.NewLine);
        }
    }
}
