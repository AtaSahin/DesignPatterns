using System;

interface ISubject
{
    void Request();
}


class RealSubject : ISubject
{
    public void Request()
    {
        Console.WriteLine("RealSubject İstek yapılıyor...");
    }
}


class Proxy : ISubject
{
    private RealSubject realSubject;

    public void Request()
    {

        if (realSubject == null)
        {
            realSubject = new RealSubject();
        }


        realSubject.Request();
    }
}

class Client
{
    public void MakeRequest(ISubject subject)
    {
        subject.Request();
    }
}

class Program
{
    static void Main()
    {

        ISubject realSubject = new RealSubject();
        Client client1 = new Client();
        client1.MakeRequest(realSubject);

        Console.WriteLine();


        ISubject proxy = new Proxy();
        Client client2 = new Client();
        client2.MakeRequest(proxy);

        Console.ReadLine();
    }
}
