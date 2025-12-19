using System;
using System.Collections.Generic;
using System.Linq;

namespace PIM
{
    public static class Alunos
    {
        public const string CAMINHO = "alunos.txt";

        public static List<Aluno> alunos = Carregar();

        public static List<Aluno> Carregar()
        {
            var lista = new List<Aluno>();

            foreach (var linha in Arquivo.CarregarLista(CAMINHO))
                lista.Add(Aluno.FromString(linha));

            return lista;
        }

        public static void Salvar()
        {
            var linhas = alunos.Select(a => a.ToString()).ToList();
            Arquivo.SalvarLista(CAMINHO, linhas);
        }

        public static void Cadastrar()
        {
            Console.Clear();

            Console.Write("Matrícula: ");
            if(!int.TryParse(Console.ReadLine(), out int matricula))
            {
                Console.WriteLine("Digite apenas números.");
                Console.ReadKey();
                Alunos.Cadastrar();
            }
              
            if (alunos.Any(a => a.Matricula == matricula))
            {
                Console.WriteLine(" Matrícula já existe!");
                Console.ReadKey();
                Alunos.Cadastrar();
                return;
            }

            Console.Write("Nome do aluno: ");
            string nome = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("O campo não pode ser vazio.");
                Console.ReadKey();
                Cadastrar();
                return;
            }

            Console.Write("Turma: ");
            string turma = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(turma))
            {
                Console.WriteLine("O Campo não pode ser vazio");
                Console.ReadKey();
                Cadastrar();
                return;
            }

            alunos.Add(new Aluno
            {
                Matricula = matricula,
                Nome = nome,
                Turma = turma
            });

            Salvar();

            Log.Registrar($"Aluno cadastrado: Matrícula {matricula}, Nome {nome}, Turma {turma}");

            Console.WriteLine($"{nome} ,cadastrado com sucesso!");
            Console.ReadKey();
            Menu.Mostrar();
        }

        public static void Listagem()
        {
            Console.Clear();
            Console.WriteLine("LISTA DE ALUNOS");
            Console.WriteLine("----------------");

            if (alunos.Count == 0)
            {
                Console.WriteLine("Nenhum aluno cadastrado.");
            }
            else
            {
                foreach (var a in alunos)
                    Console.WriteLine($"Matrícula: {a.Matricula} | Nome: {a.Nome} | Turma: {a.Turma}");
            }

            Console.ReadKey();
            Menu.Mostrar();
        }
    }
}
