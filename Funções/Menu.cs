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


░██████╗██╗░██████╗████████╗███████╗███╗░░░███╗░█████╗░  ██████╗░███████╗
██╔════╝██║██╔════╝╚══██╔══╝██╔════╝████╗░████║██╔══██╗  ██╔══██╗██╔════╝
╚█████╗░██║╚█████╗░░░░██║░░░█████╗░░██╔████╔██║███████║  ██║░░██║█████╗░░
░╚═══██╗██║░╚═══██╗░░░██║░░░██╔══╝░░██║╚██╔╝██║██╔══██║  ██║░░██║██╔══╝░░
██████╔╝██║██████╔╝░░░██║░░░███████╗██║░╚═╝░██║██║░░██║  ██████╔╝███████╗
╚═════╝░╚═╝╚═════╝░░░░╚═╝░░░╚══════╝╚═╝░░░░░╚═╝╚═╝░░╚═╝  ╚═════╝░╚══════╝

░██████╗░███████╗██████╗░███████╗███╗░░██╗░█████╗░██╗░█████╗░███╗░░░███╗███████╗███╗░░██╗████████╗░█████╗░
██╔════╝░██╔════╝██╔══██╗██╔════╝████╗░██║██╔══██╗██║██╔══██╗████╗░████║██╔════╝████╗░██║╚══██╔══╝██╔══██╗
██║░░██╗░█████╗░░██████╔╝█████╗░░██╔██╗██║██║░░╚═╝██║███████║██╔████╔██║█████╗░░██╔██╗██║░░░██║░░░██║░░██║
██║░░╚██╗██╔══╝░░██╔══██╗██╔══╝░░██║╚████║██║░░██╗██║██╔══██║██║╚██╔╝██║██╔══╝░░██║╚████║░░░██║░░░██║░░██║
╚██████╔╝███████╗██║░░██║███████╗██║░╚███║╚█████╔╝██║██║░░██║██║░╚═╝░██║███████╗██║░╚███║░░░██║░░░╚█████╔╝
░╚═════╝░╚══════╝╚═╝░░╚═╝╚══════╝╚═╝░░╚══╝░╚════╝░╚═╝╚═╝░░╚═╝╚═╝░░░░░╚═╝╚══════╝╚═╝░░╚══╝░░░╚═╝░░░░╚════╝░

███████╗░██████╗░█████╗░░█████╗░██╗░░░░░░█████╗░██████╗░
██╔════╝██╔════╝██╔══██╗██╔══██╗██║░░░░░██╔══██╗██╔══██╗
█████╗░░╚█████╗░██║░░╚═╝██║░░██║██║░░░░░███████║██████╔╝
██╔══╝░░░╚═══██╗██║░░██╗██║░░██║██║░░░░░██╔══██║██╔══██╗
███████╗██████╔╝╚█████╔╝╚█████╔╝███████╗██║░░██║██║░░██║
╚══════╝╚═════╝░░╚════╝░░╚════╝░╚══════╝╚═╝░░╚═╝╚═╝░░╚═╝");
            
            Console.WriteLine("");

            Console.WriteLine(@"
█▀▀ █▀█ █▄░█ ▀█▀ █▀█ █▀█ █░░ █▀▀   █▀▄ █▀▀   █▀▀ ▄▀█ █▀▄ ▄▀█ █▀ ▀█▀ █▀█ █▀█
█▄▄ █▄█ █░▀█ ░█░ █▀▄ █▄█ █▄▄ ██▄   █▄▀ ██▄   █▄▄ █▀█ █▄▀ █▀█ ▄█ ░█░ █▀▄ █▄█");

            Console.WriteLine();

            Console.WriteLine("-------------------------------------");


            Console.WriteLine("1 - CADASTRAR TURMAS");
            Console.WriteLine("");
            Console.WriteLine("2 - lISTAR TURMAS");
            Console.WriteLine("");
            Console.WriteLine("3 - CADASTRAR ALUNOS");
            Console.WriteLine("");
            Console.WriteLine("4 - LISTAR ALUNOS");
            Console.WriteLine("");
            Console.WriteLine("5 - ALTERAR CADASTRO");
            Console.WriteLine();
            Console.WriteLine("0 - FECHAR APLICAÇÃO");

            Console.WriteLine("--------------------------------------");

            int opcoes;
            if(!int.TryParse(Console.ReadLine(),out opcoes))
                {
                    Console.WriteLine("Digite uma opção valída");
                    Console.ReadKey();
                    Menu.Mostrar();
                    return;
                }


            switch (opcoes)
            {
                case 1 : Turmas.Cadastrar();break;
                case 2 : Turmas.Listar();break;
                case 3 : Alunos.Cadastrar();break;
                case 4 : Alunos.Listagem();break;
                case 5 : Alteracao.Cadastro();break;
                default: System.Environment.Exit(0);break;
            }

            }

            catch
            {
                Console.WriteLine("Digite uma opção valida");
                Menu.Mostrar();
            }
           }

           
        }
    }
