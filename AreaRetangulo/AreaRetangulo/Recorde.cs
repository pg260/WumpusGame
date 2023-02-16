namespace AreaRetangulo;

public class Recorde
{
    public Recorde(string dificuldade, int record)
    {
        Dificuldade = dificuldade;
        Record = record;
    }

    public string Dificuldade { get; set; }
    public int Record { get; set; }
}