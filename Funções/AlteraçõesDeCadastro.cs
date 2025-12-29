using System;
using System.Data.Common;
using System.Linq;
namespace PIM
{
    public static class Alteracao
    {   
        // Metodo de confirmação //
        private static bool ConfirmarAcao()
        {
            Console.WriteLine("Tem certeza? (S/N):");
            string resposta = Console.ReadLine().ToUpper();

            return resposta == "S";
        }
       

        public static void Cadastro()
        {
            Console.Clear();

            Console.WriteLine(@"

█▀ █ █▀ ▀█▀ █▀▀ █▀▄▀█ ▄▀█   █▀▄ █▀▀   █▀▀ █▀▀ █▀█ █▀▀ █▄░█ █▀▀ █ ▄▀█ █▀▄▀█ █▀▀ █▄░█ ▀█▀ █▀█   █▀▀ █▀ █▀▀ █▀█ █░░ ▄▀█ █▀█
▄█ █ ▄█ ░█░ ██▄ █░▀░█ █▀█   █▄▀ ██▄   █▄█ ██▄ █▀▄ ██▄ █░▀█ █▄▄ █ █▀█ █░▀░█ ██▄ █░▀█ ░█░ █▄█   ██▄ ▄█ █▄▄ █▄█ █▄▄ █▀█ █▀▄");


            Console.WriteLine("");

            Console.WriteLine(@"
▄▀█ █░░ ▀█▀ █▀▀ █▀█ ▄▀█ █▀█   █▀▀ ▄▀█ █▀▄ ▄▀█ █▀ ▀█▀ █▀█ █▀█
█▀█ █▄▄ ░█░ ██▄ █▀▄ █▀█ █▀▄   █▄▄ █▀█ █▄▀ █▀█ ▄█ ░█░ █▀▄ █▄█");
            Console.WriteLine("----------------------------");
            Console.WriteLine("1 - MUDAR ALUNO DE TURMA");
            Console.WriteLine("2 - ALTERAR NOME DO ALUNO");
            Console.WriteLine("3 - BUSCAR POR NOME");
            Console.WriteLine("4 - EXCLUIR ALUNO");
            Console.WriteLine("5 - HISTORICO DE OPERAÇÕES");
            Console.WriteLine("0 - VOLTAR");
            Console.WriteLine("----------------------------");

            int opcoes = int.Parse(Console.ReadLine());
           

            switch(opcoes)
            {
                case 1 : MudarAlunoTurma(); break;
                case 2 : RenomearAluno(); break;
                case 3 : BuscarPorNome();break;
                case 4 : ExcluirAluno();break;
                case 5 : HistoricoOperacoes(); break;
                default : Menu.Mostrar(); break;
            }
        }
         
        public static void MudarAlunoTurma()
        {
                  
        {
            Console.Clear();
            // Validação de números //
            Console.WriteLine("Matrícula do aluno (Digite 0 para sair):");
            int matricula;
            if(!int.TryParse(Console.ReadLine(), out matricula))
                {
                    Console.WriteLine("Digite um número valído");
                    Console.ReadKey();
                    MudarAlunoTurma();
                }

            if(matricula == 0)
                {
                   Cadastro();
                    return;
                }
            
            var aluno = Alunos.alunos
                .FirstOrDefault(a => a.Matricula == matricula);

            if (aluno == null)
            {
                Console.WriteLine("Aluno não encontrado.");
                Console.ReadKey();
               Cadastro();
                return;
            }

            Console.WriteLine($"Aluno: {aluno.Nome}");
            Console.WriteLine($"Turmas atuais: {aluno.Turma}");
            string turmaAntiga = aluno.Turma;

            // verifica se há turmas cadastradas 
            Console.Write("Turma: ");
            if(Turmas.turmas.Count == 0)
            {
                Console.WriteLine("Não há turmas cadastradas. Cadastre uma turma antes de cadastrar alunos");
                Console.Read();
                Menu.Mostrar();
                return;
            }

            // Lista as turmas
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

            // atribui a turma selecionada 
            aluno.Turma = Turmas.turmas[opcaoTurma - 1].Nome;


            //Metodo de confirmação 
            if(!ConfimarAcao())
                {
                    Console.WriteLine("Operação cancelada");
                    Console.ReadKey();
                    Menu.Mostrar();
                    return;
                } 
                Alunos.Salvar();

           Log.Registrar($"Turma alterada: Matrícula {aluno.Matricula}, {turmaAntiga} -> {aluno.Turma}");

            Console.WriteLine("Turma alterada com sucesso!");
            Console.ReadKey();
            Menu.Mostrar();           
        }

        }

        public static void RenomearAluno()
        {
        {
            Console.Clear();
            // Validação de inteiros // 
            Console.Write("Matrícula do aluno (Digite 0 para sair): ");
            
            int matricula;
            if(!int.TryParse(Console.ReadLine(),out  matricula))
            {
                Console.WriteLine("Digite uma matrícula valída");
                Console.ReadKey();
                RenomearAluno();
            }

            if(matricula == 0)
                {
                    Cadastro();
                    return;
                }

            var aluno = Alunos.alunos
                .FirstOrDefault(a => a.Matricula == matricula);

            if (aluno == null)
            {
                Console.WriteLine("Aluno não encontrado.");
                Console.ReadKey();
                
                return;
            }

            Console.WriteLine($"Nome atual: {aluno.Nome}");
            string NomeAntigo = aluno.Nome;
            Console.Write("Novo nome: ");
            aluno.Nome = Console.ReadLine();

            // Validação de Strings //
            if(string.IsNullOrWhiteSpace(aluno.Nome))
                {
                    Console.WriteLine("O Campo não pode ser vazio");
                    Console.ReadKey();
                    Cadastro();
                }
            // Metodo de confirmação //
            if(!ConfimarAcao())
                {
                    Console.WriteLine("Operação cancelada!");
                    Console.ReadKey();
                    Menu.Mostrar();
                    return;
                }

            Alunos.Salvar();
            // Metodo LOG (Historico de operações) //
            Log.Registrar($"Nome alterado: Matrícula {aluno.Matricula}, {NomeAntigo} -> {aluno.Nome}");

            Console.WriteLine("Nome alterado com sucesso!");
            Console.ReadKey();
            Menu.Mostrar();
        }

        }

        public static void ExcluirAluno()
        {
        
            Console.Clear();

            Console.Write("Matrícula do aluno (Digite 0 para sair): ");
            // Validação de inteiros //


            if (!int.TryParse(Console.ReadLine(), out int matricula))
            {
                Console.WriteLine("Digite apenas números.");
                Console.ReadKey();
                return;
            }

            if (matricula == 0)
            {
                Menu.Mostrar();
                return;
            }

            var aluno = Alunos.alunos
                .FirstOrDefault(a => a.Matricula == matricula);

            if (aluno == null)
            {
                Console.WriteLine("Aluno não encontrado.");
                Console.ReadKey();
               
                return;
            }

            if(!ConfimarAcao())
            {
                Console.WriteLine("Operação cancelada");
                Console.ReadKey();
                Cadastro();
                return;
            }
            
            Log.Registrar($"Aluno excluído: Matrícula  {aluno.Matricula}, Nome {aluno.Nome}, Turma {aluno.Turma}");
            Alunos.alunos.Remove(aluno);
            Alunos.Salvar();

            Console.WriteLine("Aluno excluído com sucesso!");
            Console.ReadKey();
            Cadastro();
        
    }

        public static void HistoricoOperacoes()
        {
            Console.Clear();

            Console.WriteLine("== Historico de Operações === (DIGITE 0 PARA SAIR) ");
            Console.WriteLine("---------------------------------");
            foreach (var linha in File.ReadAllLines("Dados/log.txt"))
            Console.WriteLine(linha);
            Console.ReadKey();
            Cadastro();
        }

        public static void BuscarPorNome()
        {
            Console.Clear();
            
            Console.WriteLine("Digite o nome ou parte do nome do aluno");
            string busca = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(busca))
            {
                Console.WriteLine("O Campo não pode ser vazio.");
                Console.ReadKey();
                Cadastro();
                return;
            }

            var resultados = Alunos.alunos
                .Where(a => a.Nome.ToLower().Contains(busca.ToLower()))
                .ToList();

            Console.WriteLine();
            Console.WriteLine("Resultado da busca");
            Console.WriteLine("--------------------");

            if(resultados.Count == 0)
            {
                Console.WriteLine("Nenhum aluno encontrado.");
            }
            else
            {
                foreach (var a in resultados)
                {
                    Console.WriteLine($"{a.Matricula} | Nome: {a.Nome} | Turma: {a.Turma}");
                }
            }
            Console.ReadKey();
            Cadastro();
        }
}
            

}
   