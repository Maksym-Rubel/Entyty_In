using System.Data.SqlClient;
using System.Text;

internal class Program
{

    static public void AddNew(string conn)
    {
        
        SqlConnection connection = new SqlConnection(conn);
        connection.Open();

        

        int a,b,c;
        string d;
        Console.Write("Enter Custumer ID --> ");
        a = int.Parse(Console.ReadLine()!);
        Console.Write("Enter Seller ID --> ");
        b = int.Parse(Console.ReadLine()!);
        Console.Write("Enter SaleAmount --> ");
        c = int.Parse(Console.ReadLine()!);
        Console.Write("Enter Sale Date (yyyy/mm/dd) --> ");
        d = Console.ReadLine()!;
        string cmdText = $"insert into Sales values('{a}','{b}','{c}','{d}')";
        SqlCommand command = new SqlCommand(cmdText, connection);

        int row = command.ExecuteNonQuery();
        Console.WriteLine($"{row} rows affected");



        connection.Close();
    }

    static public void PrintDate(string conn, string startDate, string endDate)
    {
        DateTime startDate1 = DateTime.Parse(startDate);
        DateTime endDate1 = DateTime.Parse(endDate);
        SqlConnection connection = new SqlConnection(conn);
        connection.Open();
        string cmdText = "select * from Sales";
        SqlCommand command = new SqlCommand(cmdText, connection);
        SqlDataReader reader = command.ExecuteReader();

        Console.OutputEncoding = Encoding.UTF8;

        for (int i = 0; i < reader.FieldCount; i++)
        {
            if (i == 0)
                Console.Write($"{reader.GetName(i),-7}");
            else
                Console.Write($"{reader.GetName(i),-10}");

        }
        Console.WriteLine();
        Console.WriteLine(new string('-', 60));

        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (i == 4) 
                {
                    DateTime salesDate = (DateTime)reader[i]; 

                   
                    if (salesDate >= startDate1 && salesDate <= endDate1)
                    {
                        if (i == 0)
                            Console.Write($"{reader[i],-7}");
                        else
                            Console.Write($"{reader[i],-10}");
                    }
                }
                else
                {
                    
                    if (i == 0)
                        Console.Write($"{reader[i],-7}");
                    else
                        Console.Write($"{reader[i],-10}");
                }
            }
            Console.WriteLine();
        }

    }
    static public void DropOld(string conn)
    {

        SqlConnection connection = new SqlConnection(conn);
        connection.Open();



        string d;
        Console.Write("Enter Sellers or Customers --> ");
        d = Console.ReadLine()!;
        string Id;
        Console.Write("Enter Id --> ");
        Id = Console.ReadLine()!;
        string cmdText = $"delete from {d} where Id = {Id}";
        SqlCommand command = new SqlCommand(cmdText, connection);

        int row = command.ExecuteNonQuery();
        Console.WriteLine($"{row} rows affected");



        connection.Close();
    }
    private static void Main(string[] args)
    {
        string conn = @"Server=DESKTOP-JELVTGO\SQLEXPRESS;Database=Sales;Integrated Security=True;Connect Timeout=2;";
        
        while (true)
        {

            
            Console.WriteLine("===== Console Menu =====");
            Console.WriteLine("1. Add New Sale");
            Console.WriteLine("2. Print Sales Within Date Range");
            Console.WriteLine("3. Drop Seller or Customer");
            Console.WriteLine("4. Exit");
            Console.Write("Please choose an option (1-4): ");

            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                    AddNew(conn);
                    break;

                case "2":
                    Console.Write("Enter start date (yyyy-mm-dd): ");
                    string startDate = Console.ReadLine()!;
                    Console.Write("Enter end date (yyyy-mm-dd): ");
                    string endDate = Console.ReadLine()!;
                    PrintDate(conn, startDate, endDate);
                    break;

                case "3":
                    DropOld(conn);
                    break;

                case "4":
                    Console.WriteLine("Exiting...");
                    return; 

                default:
                    Console.WriteLine("Invalid option");
                    break;
            }

            
            
        }

    }
}