using System;


interface IHandler
{
    IHandler SetNext(IHandler handler);
    void HandleRequest(int request);
}


abstract class Handler : IHandler
{
    private IHandler nextHandler;

    public IHandler SetNext(IHandler handler)
    {
        nextHandler = handler;
        return handler;
    }

    public void HandleRequest(int request)
    {
        if (nextHandler != null)
        {
            nextHandler.HandleRequest(request);
        }
    }
}


class ConcreteHandler1 : Handler
{
    public override void HandleRequest(int request)
    {
        if (request >= 0 && request < 10)
        {
            Console.WriteLine("ConcreteHandler1 handles the request: " + request);
        }
        else if (nextHandler != null)
        {
            nextHandler.HandleRequest(request);
        }
    }
}


class ConcreteHandler2 : Handler
{
    public override void HandleRequest(int request)
    {
        if (request >= 10 && request < 20)
        {
            Console.WriteLine("ConcreteHandler2 handles the request: " + request);
        }
        else if (nextHandler != null)
        {
            nextHandler.HandleRequest(request);
        }
    }
}


class Client
{
    public void MakeRequest(IHandler handler, int request)
    {
        handler.HandleRequest(request);
    }
}

class Program
{
    static void Main()
    {
        // Creating handler instances
        IHandler handler1 = new ConcreteHandler1();
        IHandler handler2 = new ConcreteHandler2();


        handler1.SetNext(handler2);


        Client client = new Client();
        client.MakeRequest(handler1, 5);
        client.MakeRequest(handler1, 15);
        client.MakeRequest(handler1, 25);

        Console.ReadLine();
    }
}
