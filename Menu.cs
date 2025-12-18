using System;
using System.Security.Cryptography;
namespace PIM
{
    public static  class Menu
    {
        public static void Mostrar()
        {
            try
            {

            Console.Clear();

            Console.WriteLine("=== GERENCIAMENTO DE CADASTRO ====");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("1 - Cadastrar Alunos");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Alterar Cadastro");
            Console.WriteLine("--------------------------------------");

            int opcoes = int.Parse(Console.ReadLine());

            switch (opcoes)
            {
                case 1 : Alunos.Cadastrar();break;
                case 2 : Alunos.Listagem();break;
                case 3 : Alteração.Cadastro();break;
                default: Menu.Mostrar();break;
            }

            }
            catch
            {
                Console.WriteLine("Algo deu errado, digite uma opção valida");
            }
        }
    }
}