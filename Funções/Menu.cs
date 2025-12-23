using System;
using System.Linq.Expressions;
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

            Console.WriteLine(@"

█▀ █ █▀ ▀█▀ █▀▀ █▀▄▀█ ▄▀█   █▀▄ █▀▀   █▀▀ █▀▀ █▀█ █▀▀ █▄░█ █▀▀ █ ▄▀█ █▀▄▀█ █▀▀ █▄░█ ▀█▀ █▀█   █▀▀ █▀ █▀▀ █▀█ █░░ ▄▀█ █▀█
▄█ █ ▄█ ░█░ ██▄ █░▀░█ █▀█   █▄▀ ██▄   █▄█ ██▄ █▀▄ ██▄ █░▀█ █▄▄ █ █▀█ █░▀░█ ██▄ █░▀█ ░█░ █▄█   ██▄ ▄█ █▄▄ █▄█ █▄▄ █▀█ █▀▄");
            
            Console.WriteLine("");

            Console.WriteLine(@"
█▀▀ █▀█ █▄░█ ▀█▀ █▀█ █▀█ █░░ █▀▀   █▀▄ █▀▀   █▀▀ ▄▀█ █▀▄ ▄▀█ █▀ ▀█▀ █▀█ █▀█
█▄▄ █▄█ █░▀█ ░█░ █▀▄ █▄█ █▄▄ ██▄   █▄▀ ██▄   █▄▄ █▀█ █▄▀ █▀█ ▄█ ░█░ █▀▄ █▄█");

            Console.WriteLine("-------------------------------------");

            Console.WriteLine("1 - CADASTRAR TURMAS");
            Console.WriteLine("2 - lISTAR TURMAS");
            Console.WriteLine("3 - CADASTRAR ALUNOS");
            Console.WriteLine("4 - LISTAR ALUNOS");
            Console.WriteLine("5 - ALTERAR CADASTRO");

            Console.WriteLine();

            Console.WriteLine("--------------------------------------");

            int opcoes = int.Parse(Console.ReadLine());


            switch (opcoes)
            {
                case 1 : Turmas.Cadastrar();break;
                case 2 : Turmas.Listar();break;
                case 3 : Alunos.Cadastrar();break;
                case 4 : Alunos.Listagem();break;
                case 5 : Alteração.Cadastro();break;
                default: Menu.Mostrar();break;
            }

            }

            catch
            {
                Console.WriteLine("Digite uma opção valida");
                Mostrar();
            }
           }

           
        }
    }
