using System;
using System.Data.Common;
using System.Linq;
namespace PIM
{
    public static class Alteração
    {
        public static void Cadastro()
        {
            Console.Clear();

            Console.WriteLine("=====Alterar Cadastro=====");
            Console.WriteLine("----------------------------");
            Console.WriteLine("1 - Mudar Aluno de Turma");
            Console.WriteLine("2 - Alterar Nome do Aluno");
            Console.WriteLine("3 - Excluir Aluno");
            Console.WriteLine("0 - Voltar");
            Console.WriteLine("----------------------------");

            int opcoes;
            if(int.TryParse(Console.ReadLine(), out opcoes))
            {
                Console.WriteLine("Digite uma opção valída");
            
            }

            switch(opcoes)
            {
                case 1 : MudarAlunoTurma(); break;
                case 2 : RenomearAluno(); break;
                case 3 : ExcluirAluno();break;
                default : Menu.Mostrar(); break;
            }
        }

        public static void MudarAlunoTurma()
        {
                  
        {
            Console.Clear();

            Console.Write("Matrícula do aluno: ");
            int matricula = int.Parse(Console.ReadLine());

            var aluno = Alunos.alunos
                .FirstOrDefault(a => a.Matricula == matricula);

            if (aluno == null)
            {
                Console.WriteLine("Aluno não encontrado.");
                Console.ReadKey();
               
                return;
            }

            Console.WriteLine($"Aluno: {aluno.Nome}");
            Console.WriteLine($"Turmas atuais: {aluno.Turma}"); 
            Console.WriteLine("Nova Turma");
            aluno.Turma = Console.ReadLine();

            Alunos.Salvar();

            Console.WriteLine("Turma alterada com sucesso!");
            Console.ReadKey();
            Menu.Mostrar();           
        }

        }

        public static void RenomearAluno()
        {
        {
            Console.Clear();

            Console.Write("Matrícula do aluno: ");
            int matricula = int.Parse(Console.ReadLine());
          

            var aluno = Alunos.alunos
                .FirstOrDefault(a => a.Matricula == matricula);

            if (aluno == null)
            {
                Console.WriteLine("Aluno não encontrado.");
                Console.ReadKey();
                
                return;
            }

            Console.WriteLine($"Nome atual: {aluno.Nome}");
            Console.Write("Novo nome: ");
            aluno.Nome = Console.ReadLine();

            Alunos.Salvar();

            Console.WriteLine("Nome alterado com sucesso!");
            Console.ReadKey();
            Menu.Mostrar();
        }

        }

        public static void ExcluirAluno()
        {
        {
            Console.Clear();

            Console.Write("Matrícula do aluno: ");
            int matricula = int.Parse(Console.ReadLine());


            var aluno = Alunos.alunos
                .FirstOrDefault(a => a.Matricula == matricula);

            if (aluno == null)
            {
                Console.WriteLine("Aluno não encontrado.");
                Console.ReadKey();
               
                return;
            }

            Alunos.alunos.Remove(aluno);
            Alunos.Salvar();

            Console.WriteLine("Aluno excluído com sucesso!");
            Console.ReadKey();
           Menu.Mostrar();
        }
    }
}
            

}
   