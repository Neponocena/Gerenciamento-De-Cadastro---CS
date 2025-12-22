using System;
using System.Data.Common;
using System.Linq;
namespace PIM
{
    public static class Alteração
    {   
        // Metodo de confirmação //
        private static bool ConfimarAcao()
        {
            Console.WriteLine("Tem certeza? (S/N):");
            string resposta = Console.ReadLine().ToUpper();

            return resposta == "S";
        }
       

        public static void Cadastro()
        {
            Console.Clear();

            Console.WriteLine("===== Alterar Cadastro =====");
            Console.WriteLine("----------------------------");
            Console.WriteLine("1 - Mudar Aluno de Turma");
            Console.WriteLine("2 - Alterar Nome do Aluno");
            Console.WriteLine("3 - Excluir Aluno");
            Console.WriteLine("4 - Histórico de Operações");
            Console.WriteLine("0 - Voltar");
            Console.WriteLine("----------------------------");

            int opcoes = int.Parse(Console.ReadLine());
           

            switch(opcoes)
            {
                case 1 : MudarAlunoTurma(); break;
                case 2 : RenomearAluno(); break;
                case 3 : ExcluirAluno();break;
                case 4 : HistoricoOperações();break;
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
            Console.WriteLine("Nova Turma");
            // Validação de Strings //
            aluno.Turma = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(aluno.Turma))
                {
                    Console.WriteLine("Preencha o campo!");
                    Console.ReadKey();
                    return;
                }

            if(!Turmas.existe(aluno.Turma))
                {
                    Console.WriteLine("Turma não cadastrada");
                    Console.ReadKey();
                    MudarAlunoTurma();
                }


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
                Menu.Mostrar();
                return;
            }
            
            Log.Registrar($"Aluno excluído: Matrícula  {aluno.Matricula}, Nome {aluno.Nome}, Turma {aluno.Turma}");
            Alunos.alunos.Remove(aluno);
            Alunos.Salvar();

            Console.WriteLine("Aluno excluído com sucesso!");
            Console.ReadKey();
           Menu.Mostrar();
        
    }

        public static void HistoricoOperações()
        {
            Console.Clear();

            Console.WriteLine("== Historico de Operações === ");
            Console.WriteLine("---------------------------------");
            foreach (var linha in File.ReadAllLines("log.txt"))
            Console.WriteLine(linha);
            Console.ReadKey();
            Cadastro();
        }
}
            

}
   