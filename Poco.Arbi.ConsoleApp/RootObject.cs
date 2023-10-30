namespace Demo.Camunda;

public class Rootobject
{
    public Variables variables { get; set; }
}

public class Variables
{
    public Foonumber fooNumber { get; set; }
}

public class Foonumber
{
    public string value { get; set; }
    public string type { get; set; }
}
