using System;

class Adaptee
{
    public void SpecificRequest()
    {
        Console.WriteLine("Request from Adapter");
    }
}

interface ITarget
{
    void Request();
}

class Adapter : ITarget
{
    private Adaptee adaptee;

    public Adapter(Adaptee adaptee)
    {
        this.adaptee = adaptee;
    }

    public void Request()
    {
        adaptee.SpecificRequest();
    }
}

class Client
{
    public void MakeRequest(ITarget target)
    {
        target.Request();
    }
}

class Program
{
    static void Main()
    {
        Adaptee adaptee = new Adaptee();

        ITarget adapter = new Adapter(adaptee);

        Client client = new Client();
        client.MakeRequest(adapter);

        Console.ReadLine();
    }
}
