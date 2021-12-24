namespace ReflectionDemo;

public class City
{
    public string Name { get; set; }
    public int Area { get; private set; }
    public int Population { get; private set; }
    private bool _isClosed;

    public void Grow()
    {
        Population *= 2;
        Console.WriteLine("City grows");
    }

    public City(string name, int area, int population)
    {
        Name = name;
        Area = area;
        Population = population;
        _isClosed = false;
    }
}