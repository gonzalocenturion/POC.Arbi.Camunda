public class Response
{
    public Class1[] Property1 { get; set; }
}

public class Class1
{
    public Bar bar { get; set; }
}

public class Bar
{
    public string type { get; set; }
    public string value { get; set; }
    public Valueinfo valueInfo { get; set; }
}

public class Valueinfo
{
}


