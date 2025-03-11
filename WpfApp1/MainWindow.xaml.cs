using data_accsec_layer;
using System.Configuration;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DbSportShop db;
        public MainWindow()
        {
            InitializeComponent();
            db = new DbSportShop(ConfigurationManager.ConnectionStrings["connShop"].ConnectionString);

        }

        private void LoadProducts(object sender, RoutedEventArgs e)
        {
            datagrid.ItemsSource = db.getAll();
        }

        private void id_product_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                this.getProduct(sender,e);
        }

        private void getProduct(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(id_product.Text);
            List<Product> list = new List<Product>();
            Product item = db.getOneProduct(id);
            if (item != null)
            {
                list.Add(item);
                datagrid.ItemsSource = list;
            }
            else
                MessageBox.Show("Item not fount!!!","error", MessageBoxButton.OK, MessageBoxImage.Error);
            id_product.Text = "";
        }
    }
}