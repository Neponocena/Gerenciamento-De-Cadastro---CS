namespace PIM
{
public static class Arquivo
{
    public static void SalvarLista(string caminho, List<string> lista)
    {
        string pasta = Path.GetDirectoryName(caminho);
        if (!string.IsNullOrEmpty(pasta))
            Directory.CreateDirectory(pasta);

        File.WriteAllLines(caminho, lista);
    }

    public static List<string> CarregarLista(string caminho)
    {
        if (!File.Exists(caminho))
            return new List<string>();

        return new List<string>(File.ReadAllLines(caminho));
    }
}
}