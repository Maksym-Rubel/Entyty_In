using System.Configuration;
using System.Data.SqlClient;
using System.Text;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public int Quantity { get; set; }
    public int CostPrice { get; set; }
    public string Producer { get; set; }
    public int Price { get; set; }

    public override string ToString()
    {
        return $"{Id,16}{Name,16}{Type,16}{Quantity,16}{CostPrice,16}{Producer,16}{Price,16}";
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
        string cmd = @"insert into Products values(@name,@type,@quantity,@cost_price,@producer,@price";
        SqlCommand command = new SqlCommand(cmd, connection);
        setCommandParams(ref command, product);
        command.ExecuteNonQuery();
    }

    private void setCommandParams(ref SqlCommand command, Product product)
    {
        command.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = product.Name;
        command.Parameters.Add("@type", System.Data.SqlDbType.NVarChar).Value = product.Type;
        command.Parameters.Add("@quantity", System.Data.SqlDbType.Int).Value = product.Quantity;
        command.Parameters.Add("@cost_price", System.Data.SqlDbType.Int).Value = product.CostPrice;
        command.Parameters.Add("@producer", System.Data.SqlDbType.NVarChar).Value = product.Producer;
        command.Parameters.Add("@price", System.Data.SqlDbType.Int).Value = product.Price;
    }


    public List<Product> GetAll()
    {
        string cmd = @"select * from Products";
        SqlCommand command = new SqlCommand(cmd,connection);
        return getAllProducts(command);
    }

    private List<Product> getAllProducts(SqlCommand command)
    {
        List<Product> products = new List<Product>();
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            products.Add(new Product()
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Type = reader.GetString(2),
                Quantity = reader.GetInt32(3),
                CostPrice = reader.GetInt32(4),
                Producer = reader.GetString(5),
                Price = reader.GetInt32(6)
            });
        }
        reader.Close();
        return products;
    }

    public Product GetProduct(int id)
    {
        string cmd = "select * from Products where Id = @Id";
        SqlCommand command = new SqlCommand(cmd,connection);
        command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
        return getAllProducts(command).FirstOrDefault()!;
    }


    public void Update(Product product)
    {
        string cmd = @"update Products 
                        set Name = @name
                            TypeProduct = @type,
                            Quantity = @quantity,
                            CostPrice = @cost_price,
                            Producer = @producer,
                            Price = @price
                            where Id = @Id";
        SqlCommand command = new SqlCommand(cmd, connection);
        setCommandParams(ref command, product);
        command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = product.Id;
        command.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
        string cmd = @"delete from Products where Id = @id";
        SqlCommand command = new SqlCommand(cmd, connection);
        command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
        command.ExecuteNonQuery();


    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        DbSportShop db = new DbSportShop(ConfigurationManager.ConnectionStrings["connShop"].ConnectionString);
        //db.AddProduct(new Product()
        //{
        //    Name = "Ручка",
        //    Type = "Аксесуари",
        //    Quantity = 15,
        //    CostPrice = 50,
        //    Price = 150,
        //    Producer = "Україна"
        //});

        List<Product> products = db.GetAll();

        foreach (Product product in products)
        {
            Console.WriteLine(product);
        }

        //Console.WriteLine(db.GetProduct(1));


        //db.Delete(5);
    }
}