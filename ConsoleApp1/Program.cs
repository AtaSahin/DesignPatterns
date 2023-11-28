using System;


interface IProduct
{
    void Display();
}


class ConcreteProduct1 : IProduct
{
    public void Display()
    {
        Console.WriteLine("ConcreteProduct1 gösteriliyor....");
    }
}


class ConcreteProduct2 : IProduct
{
    public void Display()
    {
        Console.WriteLine("ConcreteProduct2 is displaying....");
    }
}

interface IFactory
{
    IProduct CreateProduct();
}


class ConcreteFactory1 : IFactory
{
    public IProduct CreateProduct()
    {
        return new ConcreteProduct1();
    }
}


class ConcreteFactory2 : IFactory
{
    public IProduct CreateProduct()
    {
        return new ConcreteProduct2();
    }
}

class Client
{
    private IFactory factory;

    public Client(IFactory factory)
    {
        this.factory = factory;
    }

    public void Run()
    {
        IProduct product = factory.CreateProduct();
        product.Display();
    }
}

class Program
{
    static void Main()
    {

        IFactory factory1 = new ConcreteFactory1();
        Client client1 = new Client(factory1);
        client1.Run();


        IFactory factory2 = new ConcreteFactory2();
        Client client2 = new Client(factory2);
        client2.Run();

        Console.ReadLine();
    }
}
