// test interface

using MyConsoleApp.Indexer_concept_;
using static MyConsoleApp.Delegate.Delegating;

public class Program
{
    public static void Main(string[] args)
    {
        // Test the BaseClass and Derived
        BaseClass obj = new BaseClass();
        obj.PrintMessage(); // Output: Message from BaseClass

        DerivedClass derivedClassObj = new DerivedClass();
        derivedClassObj.PrintMessage(); // Output: derived class

        BaseClass basObj = new DerivedClass();
        basObj.PrintMessage();// output: derived class(because of polymorphism(overridden))

        PrintDashes();

        // Test which constructor is called first
        var orderService = new OrderService();

        PrintDashes();

        // bcs print is overriden and derived class not yet initialized
        // so msg will be empty (not working in local but its dangerous)
        var derivedObj = new Derived();  // (4)
        PrintDashes();
        // Delegate Example
        try
        {
            Notify notify = MethodA; // MethodA type should match with delegate signature, (delegate is pointer to a Method)
            notify += MethodB;
            // Multicast delegate
            notify();
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Exception caught: {ex.Message}");
        }

        PrintDashes();

        // Even handler
        var service = new MyConsoleApp.Events.OrderService();
        service.orderPlaced += (s, e) => Console.WriteLine("EMail Sent");
        service.orderPlaced += (s, e) => Console.WriteLine("Inventory updated");

        service.PlaceOrder(); // Output: Order placed successfully. EMail Sent Inventory updated
        PrintDashes();

        // Indexer
        PhoneBook ph = new();
        ph.Test();

    }

    private static void PrintDashes()
    {
        Console.WriteLine("-------------------------------------------");
    }
}



public class MethodHidingBase
{
    public void Print()
    {
        Console.WriteLine("Method hiding: Base Print");
    }
}

public class MethodHidingDerived : MethodHidingBase
{
    public new void Print()
    {
        Console.WriteLine("Method hiding: Derived Print");
    }
}
public class BaseClass
{
    public virtual void PrintMessage()
    {
       Console.WriteLine("Message from BaseClass");
    }
}

public class  DerivedClass : BaseClass
{
    public override void PrintMessage()
    {
        Console.WriteLine("derived class");
    }
}

class Logger
{
    public Logger()
    {
        Console.WriteLine("Logger initialized.");
    }

    public void Log(string message)
    {
        Console.WriteLine("Log: " + message);
    }
}

class ServiceBase
{
    protected Logger logger;

    public ServiceBase()
    {
        logger = new Logger(); // base sets up logger
        logger.Log("ServiceBase initialized.");
    }
}

class OrderService : ServiceBase
{
    public OrderService()
    {
        logger.Log($"{nameof(OrderService)} is ready.");
    }
}

public class Base
{
    public Base()
    {
        Test(); Print();  // Calls the derived class Print() if overridden
    }

    public virtual void Print()
    {
        Console.WriteLine("Base Print");  // (2)
    }
    public virtual void Test()
    {
        Console.WriteLine("Base Test");  // (2)
    }
}

public class Derived : Base
{
    private string msg = "Derived Print";

    public override void Print()
    {
        Console.WriteLine(msg);  // (3) // Might print empty or null
    }
}



