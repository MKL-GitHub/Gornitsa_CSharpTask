using GornitsaTask;

class Program
{
    public static void Main(string[] args)
    {
        Glazing glazing = new("6 SG HD Silver Grey 32 ЗАК/16/6 м1/16/6 ЗАК");

        Print(glazing);
    }

    private static void Print(Glazing glazing)
    {
        Console.WriteLine(
            $"Камерность: {glazing.Chamberness}\n" +
            $"Толщина СП: {glazing.GlazingThickness}\n" +
            $"Толщина стекла: {glazing.GlassThickness}");
    }
}