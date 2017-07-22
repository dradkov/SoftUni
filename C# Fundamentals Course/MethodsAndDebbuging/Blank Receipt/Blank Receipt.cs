using System;



class Program
{
    static void Main()
    {       
        PrintReceipt();             
    }

    private static void PrintReceipt()
    {
        PrintReceiptHeader();
        PrintReceiptBody();
        PrintReceiptFooter();
    }

    private static void PrintReceiptFooter()
    {
        Console.WriteLine("------------------------------");
        Console.WriteLine("© SoftUni");
    }

    private static void PrintReceiptBody()
    {
        Console.WriteLine("Charged to____________________");
        Console.WriteLine("Received by___________________");
    }

    private static void PrintReceiptHeader()
    {
        Console.WriteLine("CASH RECEIPT");
        Console.WriteLine("------------------------------");
    }
    
}

