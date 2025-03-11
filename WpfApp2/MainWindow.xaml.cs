using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connection;
        SqlDataAdapter da;
        SqlCommandBuilder bild;
        DataSet set;
        public MainWindow()
        {
            InitializeComponent();
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connShop"].ConnectionString);
        }

        private void Fill(object sender, RoutedEventArgs e)
        {
            string sql = cmd.Text;
            da = new SqlDataAdapter(sql, connection);
            bild = new SqlCommandBuilder(da);
            set = new DataSet();

            da.Fill(set, "MyTable");
            datagrid.ItemsSource = set.Tables["MyTable"].DefaultView;

        }

        private void Update(object sender, RoutedEventArgs e)
        {
            da.Update(set, "MyTable");
        }

        private void Cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var obj = (ComboBox)sender;
            ComboBoxItem item = (ComboBoxItem)obj.Items[obj.SelectedIndex];
         
            string sql = "select * from " + item.Content.ToString();
         
            cmd.Text = sql;
         
        }
    }
}