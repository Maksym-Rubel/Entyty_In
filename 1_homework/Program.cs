using System.Data.SqlClient;
using System.Text;

internal class Program
{
    static public void List_Exam(string conn)
    {

        SqlConnection connection = new SqlConnection(conn);
        connection.Open();
        string cmdText = "select * from Examinations";
        SqlCommand command = new SqlCommand(cmdText, connection);
        SqlDataReader reader = command.ExecuteReader();

        Console.OutputEncoding = Encoding.UTF8;

        for (int i = 0; i < reader.FieldCount; i++)
        {
            if (i == 0)
                Console.Write($"{reader.GetName(i),-7}");
            else
                Console.Write($"{reader.GetName(i),-20}");

        }
        Console.WriteLine();
        Console.WriteLine(new string('-', 60));

        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (i == 0)
                    Console.Write($"{reader[i],-7}");
                else
                    Console.Write($"{reader[i],-20}");

            }
            Console.WriteLine();
        }
        connection.Close();
    }
    static public void DropOld(string conn, string startDate)
    {
        DateTime startDate1 = DateTime.Parse(startDate);
        string formattedDate = startDate1.ToString("yyyy-MM-dd");
        SqlConnection connection = new SqlConnection(conn);
        connection.Open();




        string cmdText = $"delete from Examinations where ExamDate < '{formattedDate}'";
        SqlCommand command = new SqlCommand(cmdText, connection);

        int row = command.ExecuteNonQuery();
        Console.WriteLine($"{row} rows deleted");



        connection.Close();

    }
    static public void SelDocSallary(string conn, int Salary)
    {
        SqlConnection connection = new SqlConnection(conn);
        connection.Open();
        string cmdText = $"select * from Doctors where Salary > {Salary}";
        SqlCommand command = new SqlCommand(cmdText, connection);
        SqlDataReader reader = command.ExecuteReader();

        Console.OutputEncoding = Encoding.UTF8;

        for (int i = 0; i < reader.FieldCount; i++)
        {
            if (i == 0)
                Console.Write($"{reader.GetName(i),-7}");
            else
                Console.Write($"{reader.GetName(i),-20}");

        }
        Console.WriteLine();
        Console.WriteLine(new string('-', 60));

        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (i == 0)
                    Console.Write($"{reader[i],-7}");
                else
                    Console.Write($"{reader[i],-20}");

            }
            Console.WriteLine();
        }
        connection.Close();
    }
    static public void SelDonatiion(string conn)
    {
        SqlConnection connection = new SqlConnection(conn);
        connection.Open();
        string cmdText = $"select top 1 * from Donations order by Amount Desc";
        SqlCommand command = new SqlCommand(cmdText, connection);
        SqlDataReader reader = command.ExecuteReader();

        Console.OutputEncoding = Encoding.UTF8;

        for (int i = 0; i < reader.FieldCount; i++)
        {
            if (i == 0)
                Console.Write($"{reader.GetName(i),-7}");
            else
                Console.Write($"{reader.GetName(i),-20}");

        }
        Console.WriteLine();
        Console.WriteLine(new string('-', 80));

        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (i == 0)
                    Console.Write($"{reader[i],-7}");
                else
                    Console.Write($"{reader[i],-20}");

            }
            Console.WriteLine();
        }
        connection.Close();
    }
    static public void AddNewExam(string conn)
    {

        SqlConnection connection = new SqlConnection(conn);
        connection.Open();



      
        string a,b;
        Console.Write("Enter exam name --> ");
        a = Console.ReadLine()!;
        Console.Write("Enter exam date (yyyy/mm/dd) --> ");
        b = Console.ReadLine()!;
        
       
        string cmdText = $"insert into Examinations values('{a}','{b}')";
        SqlCommand command = new SqlCommand(cmdText, connection);

        int row = command.ExecuteNonQuery();
        Console.WriteLine($"{row} rows affected");



        connection.Close();
    }
    static public void ShowDep(string conn)
    {
        SqlConnection connection = new SqlConnection(conn);
        connection.Open();
        string cmdText = $"select d.Name as 'Name', w.Places as 'Place' from Departments1 as d join Wards as w on w.DepartmentId = d.Id";
        SqlCommand command = new SqlCommand(cmdText, connection);
        SqlDataReader reader = command.ExecuteReader();

        Console.OutputEncoding = Encoding.UTF8;

        for (int i = 0; i < reader.FieldCount; i++)
        {
            if (i == 0)
                Console.Write($"{reader.GetName(i),-20}");
            else
                Console.Write($"{reader.GetName(i),-20}");

        }
        Console.WriteLine();
        Console.WriteLine(new string('-', 80));

        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (i == 0)
                    Console.Write($"{reader[i],-20}");
                else
                    Console.Write($"{reader[i],-20}");

            }
            Console.WriteLine();
        }
        connection.Close();
    }
    static public void List_Sponsors(string conn)
    {

        SqlConnection connection = new SqlConnection(conn);
        connection.Open();
        string cmdText = "select * from Sponsors s where Id not in(select distinct SponsorId from Donations)";
        SqlCommand command = new SqlCommand(cmdText, connection);
        SqlDataReader reader = command.ExecuteReader();

        Console.OutputEncoding = Encoding.UTF8;

        for (int i = 0; i < reader.FieldCount; i++)
        {
            if (i == 0)
                Console.Write($"{reader.GetName(i),-7}");
            else
                Console.Write($"{reader.GetName(i),-20}");

        }
        Console.WriteLine();
        Console.WriteLine(new string('-', 60));

        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (i == 0)
                    Console.Write($"{reader[i],-7}");
                else
                    Console.Write($"{reader[i],-20}");

            }
            Console.WriteLine();
        }
        connection.Close();
    }
    private static void Main(string[] args)
    {
        string conn = @"Server=DESKTOP-JELVTGO\SQLEXPRESS;Database=Hospital1;Integrated Security=True;Connect Timeout=2;";
        Console.WriteLine("Task 1");
        ShowDep(conn);
        Console.WriteLine();

        Console.WriteLine("Task 2");
        List_Exam(conn);
        Console.WriteLine();

        Console.WriteLine("Task 3");
        string date = "2022/12/22";
        DropOld(conn, date);
        Console.WriteLine();
        Console.WriteLine("Task 4");

        SelDocSallary(conn, 1000);
        Console.WriteLine();
        Console.WriteLine("Task 5");

        SelDonatiion(conn);
        Console.WriteLine();
        Console.WriteLine("Task 6");

        //AddNewExam(conn);
        Console.WriteLine();
        Console.WriteLine("Task 7");

        List_Sponsors(conn);
    }
}