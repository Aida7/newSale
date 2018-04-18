using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace Sale
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }
        public void FillDataGrid(string change)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"];

            DbProviderFactory factory = DbProviderFactories.GetFactory(connectionString.ProviderName);
            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = connectionString.ConnectionString;

            DbCommand command = connection.CreateCommand();
            command.CommandText = "select * from  "+ change.ToString();
            DbDataAdapter adapter = factory.CreateDataAdapter();
            adapter.SelectCommand = command;

            DataTable table = new DataTable();
            adapter.Fill(table);

            grdTable.ItemsSource = table.DefaultView;

            //if (chang== "Sales")
            //{
            //   selectComand.CommandText =
            //   "select *from Sales;";
            //    adapter.SelectCommand = selectComand;
            //    DataTable dataTable = new DataTable("Sales");
            //    adapter.Fill(dataTable);
            //    grdEmployee.ItemsSource = dataTable.DefaultView;

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string change = (comboBox.SelectedItem as ComboBoxItem).Content.ToString();
            FillDataGrid(change);
        }
    }
}
