using System.Text;
using ReflectionDemo;
void PrintCityInfo(City city)
{
    Console.WriteLine($"Name: {city.Name}");
    Console.WriteLine($"Area: {city.Area}");
    Console.WriteLine($"Population: {city.Population}");
}
var city = new City("Novosibirsk",320000,2100000);
PrintCityInfo(city);
Console.WriteLine();
var cityType = typeof(City);
Console.WriteLine($"namespace {cityType.Namespace};");
if (cityType.IsPublic)
{
    Console.Write("public ");
}
else if (cityType.IsNotPublic)
{
    Console.Write("private ");
}
if(cityType.IsAbstract)
    Console.Write("abstract ");
if(cityType.IsSealed)
    Console.Write("sealed ");
Console.WriteLine($"class {cityType.Name}");
Console.WriteLine("{");
foreach (var property in cityType.GetProperties())
{
    Console.Write($"public {property.GetGetMethod()?.ReturnType.Name} {property.Name} ");
    Console.Write("{");
    if(property.CanRead)
        Console.Write("get; ");
    if(property.CanWrite)
        Console.WriteLine("set; }");
}

foreach (var constructor in cityType.GetConstructors())
{
    if(constructor.IsPublic)
        Console.Write("public ");
    if(constructor.IsPrivate)
        Console.Write("private ");
    if(constructor.IsStatic)
        Console.Write("static ");
    Console.Write($"{cityType.Name}(");
    var builder = new StringBuilder();
    foreach (var parameter in constructor.GetParameters())
    {
        builder.Append($"{parameter.ParameterType.Name} {parameter.Name},");
    }

    builder.Remove(builder.Length - 1, 1);
    builder.Append(")");
    Console.WriteLine(builder.ToString());
}

foreach (var method in cityType.GetMethods())
{
        if(method.IsPublic)
            Console.Write("public ");
        if(method.IsPrivate)
            Console.Write("private ");
        if(method.IsStatic)
            Console.Write("static ");
        if(method.IsAbstract)
            Console.Write("abstract ");
        if(method.IsVirtual)
            Console.Write("virtual ");
        Console.Write($"{method.Name}(");
        var builder = new StringBuilder();
        foreach (var parameter in method.GetParameters())
        {
            builder.Append($"{parameter.ParameterType.Name} {parameter.Name},");
        }

        if (builder.Length > 0)
            builder.Remove(builder.Length - 1, 1);
        builder.Append(')');
        Console.WriteLine(builder.ToString());
    
}

foreach (var field in cityType.GetFields())
{
    if(field.IsPublic)
        Console.Write("public ");
    if(field.IsPrivate)
        Console.Write("private ");
    if(field.IsStatic)
        Console.Write("static ");
    Console.Write(field.FieldType.Name);
    Console.WriteLine($" {field.Name};");
}
Console.WriteLine("}");

