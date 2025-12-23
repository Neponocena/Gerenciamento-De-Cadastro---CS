using System;
using System.Collections.Generic;
using System.Linq;

namespace PIM
{
    public static class Alunos
    {
        public const string CAMINHO = "Dados/alunos.txt";

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
            Console.Write("Matrícula do aluno (Digite 0 para sair): ");
            String entrada = Console.ReadLine();

            if (!int.TryParse(entrada, out int matricula))
            {
                Console.WriteLine("Digite apenas números.");
                Console.ReadKey();
                Menu.Mostrar();
                return;
             }

            if (matricula == 0)
            {
                Menu.Mostrar();
                return;
            }

            // Validação de caracteres //
            if(entrada.Length != 4)
            {
                Console.WriteLine("A matrícula deve ter exatamente 4 números");
                Console.ReadKey();
                Cadastrar();
            }

            if (alunos.Any(a => a.Matricula == matricula))
            {
                Console.WriteLine(" Matrícula já existe!");
                Console.ReadKey();
                Alunos.Cadastrar();
                return;
            }
            // Validação de String //
            Console.Write("Nome do aluno: ");
            string nome = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("O campo não pode ser vazio.");
                Console.ReadKey();
                Cadastrar();
                return;
            }
            // Validação de String //
            Console.Write("Turma: ");
            if(Turmas.turmas.Count == 0)
            {
                Console.WriteLine("Não há turmas cadastradas. Cadastre uma turma antes de cadastrar alunos");
                Console.Read();
                Menu.Mostrar();
                return;
            }

            Console.WriteLine("Escolha a turma do aluno");
            for(int i = 0; i < Turmas.turmas.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {Turmas.turmas[i].Nome}");
            }

            int opcaoTurma;
            while(true)
            {
                Console.WriteLine("");
                Console.WriteLine("Opção:");
                Console.WriteLine("");
                string entradaTurma = Console.ReadLine();

                if (!int.TryParse(entradaTurma, out opcaoTurma) || opcaoTurma < 1 || opcaoTurma > Turmas.turmas.Count)
                {
                    Console.WriteLine("Opção inválida , Digite novamente: ");
                }
                else
                {
                    break;
                }
            }

            string TurmaSelecionada = Turmas.turmas[opcaoTurma - 1]. Nome;
            

            alunos.Add(new Aluno
            {
                Matricula = matricula,
                Nome = nome,
                Turma = TurmaSelecionada
            });

            Salvar();

            Log.Registrar($"Aluno cadastrado: Matrícula {matricula}, Nome {nome}, Turma {TurmaSelecionada}");

            Console.WriteLine($"{nome} ,cadastrado com sucesso!");
            Console.ReadKey();
            Menu.Mostrar();
        }

        public static void Listagem()
        {
            Console.Clear();
            Console.WriteLine("LISTA DE ALUNOS (Digite 0 para sair):");
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
