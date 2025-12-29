namespace PIM
{
    public class Aluno
    {
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Turma { get; set; }

       
        public override string ToString()
        {
            return $"{Matricula};{Nome};{Turma}";
        }

      
        public static Aluno FromString(string linha)
        {
            var partes = linha.Split(';');

            return new Aluno
            {
                Matricula = int.Parse(partes[0]),
                Nome = partes[1],
                Turma = partes[2]
            };
        }
    }
}
