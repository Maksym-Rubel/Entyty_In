using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using static Program;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Avaible { get; set; }
        public DateTime Date { get; set; }
        public override string ToString()
        {
            return $"{Id,-7}{Name,-25}{Avaible,-16}{Date,-16}";
        }
    }
    public class Visitor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Is_deabtor { get; set; }
        public override string ToString()
        {
            return $"{Id,-7}{Name,-25}{Is_deabtor,-16}";
        }
    }
    public class Author 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"{Id,-7}{Name,-25}";
        }
    }
 
    public class DbSportShop
    {
        private SqlConnection connection;


        public DbSportShop(string connectionString)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("Connected to database");

        }
        ~DbSportShop()
        {
            connection.Close();
        }

        public void AddProduct(Product product)
        {
            string cmd = @"insert into Books values(@name,@avaible,@date)";
            SqlCommand command = new SqlCommand(cmd, connection);
            setCommandParams(ref command, product);
            command.ExecuteNonQuery();
        }

        private void setCommandParams(ref SqlCommand command, Product product)
        {
            command.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = product.Name;
            command.Parameters.Add("@avaible", System.Data.SqlDbType.Int).Value = product.Avaible;
            command.Parameters.Add("@date", System.Data.SqlDbType.Date).Value = product.Date;

        }
        private void setCommandParams1(ref SqlCommand command, Visitor visitor)
        {
            command.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = visitor.Name;
            command.Parameters.Add("@is_debtor", System.Data.SqlDbType.Bit).Value = visitor.Is_deabtor;

        }

        public List<Visitor> GetAll()
        {
            string cmd = @"select * from Visitors";
            SqlCommand command = new SqlCommand(cmd, connection);
            return getAllProducts(command);
        }
        public List<Author> GetAuthor(string name)
        {
            string cmd = "select * from Author a join Author2Books ab on ab.AuthorId = a.Id join Books b on b.Id = ab.BooksId where b.Name = @Name";
            SqlCommand command = new SqlCommand(cmd, connection);
            command.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar).Value = name;
            return getAllAuthor(command);
        }
        private List<Visitor> getAllProducts(SqlCommand command)
        {
            List<Visitor> visitors = new List<Visitor>();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                visitors.Add(new Visitor()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Is_deabtor = reader.GetBoolean(2),
                });
            }
            reader.Close();
            return visitors;
        }
        private List<Product> getAllBooks(SqlCommand command)
        {
            List<Product> visitors = new List<Product>();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                visitors.Add(new Product()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Avaible = reader.GetInt32(2),
                    Date = reader.GetDateTime(3),

                });
            }
            reader.Close();
            return visitors;
        }
        private List<Author> getAllAuthor(SqlCommand command)
        {
            List<Author> visitors = new List<Author>();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                visitors.Add(new Author()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                });
            }
            reader.Close();
            return visitors;
        }
        public List<Visitor> GetAllIs_d()
        {
            string cmd = @"select * from Visitors where Is_deabtor = 1";
            SqlCommand command = new SqlCommand(cmd, connection);
            return getAllProducts(command);
        }
        public List<Product> GetBooksOp()
        {
            string cmd = @"select * from Books b
                           join BorrowedBooks bb on bb.BooksId = b.Id
                           where bb.return_date is null";
            SqlCommand command = new SqlCommand(cmd, connection);
            return getAllBooks(command);
        }
        public List<Product> GetVIsBooks(string name)
        {
            string cmd = @"select * from Books b
                join BorrowedBooks bb on bb.BooksId = b.Id
                join Visitors v on bb.VisitorId = v.Id
                where v.Name = @Name";
            SqlCommand command = new SqlCommand(cmd, connection);
            command.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar).Value = name;
            return getAllBooks(command);
        }
        public void Update(Visitor product)
        {
            string cmd = @"update Visitors
                        set Name = @name,
                            Is_deabtor = @is_debtor
                            where Id = @Id";
            SqlCommand command = new SqlCommand(cmd, connection);
            setCommandParams1(ref command, product);
            command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = product.Id;
            command.ExecuteNonQuery();
        }
        public Visitor GetVisitor(int id)
        {
            string cmd = "select * from Visitors where Id = @Id";
            SqlCommand command = new SqlCommand(cmd, connection);
            command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
            return getAllProducts(command).FirstOrDefault()!;
        }
        public void UpdateVisitor(DbSportShop db)
        {
            List<Visitor> visitors1 = db.GetAllIs_d();
            foreach (Visitor visitor in visitors1)
            {
                visitor.Is_deabtor = false; 
                db.Update(visitor);
            }

        }
    }
        private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        DbSportShop db = new DbSportShop(ConfigurationManager.ConnectionStrings["connLib"].ConnectionString);

        //db.AddProduct(new Product()
        //{
        //    Name = "Ручка",
        //    Avaible = 12,
        //    Date = DateTime.Parse("2020/02/04")
        //});



        List<Visitor> visitors = db.GetAll();

        foreach (Visitor visitor in visitors)
        {
            Console.WriteLine(visitor);
        }
        Console.WriteLine();
        Console.WriteLine();
        List<Visitor> visitors1 = db.GetAllIs_d();
        foreach (Visitor visitor1 in visitors1)
        {
            Console.WriteLine(visitor1);
        }
        Console.WriteLine();
        Console.WriteLine();
        List<Author> authors = db.GetAuthor("Ручка");
        foreach (Author author in authors)
        {
            Console.WriteLine(author);
        }
        Console.WriteLine();
        Console.WriteLine();
        List<Product> books = db.GetBooksOp();
        foreach (Product book in books)
        {
            Console.WriteLine(book);
        }
        Console.WriteLine();
        Console.WriteLine();
        List<Product> booksv = db.GetVIsBooks("Іван Петренко");
        foreach (Product bookv in booksv)
        {
            Console.WriteLine(bookv);
        }
        db.UpdateVisitor(db);
    }
}