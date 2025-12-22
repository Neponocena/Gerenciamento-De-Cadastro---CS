using System.Reflection.Metadata;
using System;
using System.Runtime.CompilerServices;
using System.ComponentModel.Design;
namespace PIM
{
    public class Turma
    {
        public string Nome {get; set;}

        public override string ToString()
        {
            return Nome;
        }

        public static Turma FromString(string linha)
        {
            return new Turma  { Nome = linha };
        }
    }

        public static class Turmas
    {
        public const string CAMINHO = "turmas.txt";

        public static List <Turma> turmas = Carregar();

        public static List<Turma> Carregar()
        {
            var lista = new List<Turma>();

            foreach (var linha in Arquivo.CarregarLista(CAMINHO))
            lista.Add(Turma.FromString(linha));
            return lista;
        }

        public static void Salvar ()
        {
            var linhas = turmas.Select(t => t.ToString()).ToList();
            Arquivo.SalvarLista(CAMINHO, linhas);
        }

        public static void Cadastrar()
        {
            Console.Clear();

            Console.WriteLine("Nome da turma (Digite 0 para sair):");
            string nome = Console.ReadLine();

            if(nome == "0")
            {
                Menu.Mostrar();
                
            }

            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("O Campo não pode ser vazio");
                Console.ReadKey();
                Cadastrar();
            }

            if(turmas.Any(t => t.Nome == nome))
            {
                Console.WriteLine("Turma já cadastrada");
                Console.ReadKey();
                Cadastrar();
            }

            turmas.Add(new Turma {Nome = nome});
            Salvar();

            Log.Registrar($"Turma cadastrada: {nome}");

            Console.WriteLine("Turma cadastrada com sucesso");
            Console.ReadKey();
            Menu.Mostrar();
        }

        public static void Listar()
        {
            Console.Clear();

            Console.WriteLine("=== LISTA DE TURMAS ===");
            Console.WriteLine("------------------------");

            if(turmas.Count == 0)
                Console.WriteLine("Nenhuma turma cadastrada");
            else
                foreach(var t in turmas)
                    Console.WriteLine(t.Nome);

            Console.ReadKey();
            Menu.Mostrar();
        }

        public static bool existe(string nome)
        {
            return  turmas.Any(t => t.Nome == nome);
        }

    }
}