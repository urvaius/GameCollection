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
using Oracle.DataAccess.Client;

namespace GameCollection
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string test = "notthere";

            

            string oradbnew = "Data Source=(DESCRIPTION="
             + "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.1.5.250)(PORT=1521)))"
             + "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=gamecollecti)));"
             + "User Id=game;Password=Buffy11$;";

            string SelectGames = "select * from games";

            OracleConnection conn = new OracleConnection(oradbnew);
            conn.Open();
            Console.WriteLine("connected to oracle" + conn.ServerVersion);
            test = conn.InstanceName.ToString();


            OracleCommand cmd = new OracleCommand(SelectGames, conn);
            cmd.CommandType = System.Data.CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();
            dr.Read();
            test = dr["NAME"].ToString();
            
            conn.Close();
            conn.Dispose();
            Console.WriteLine("disconnected");

        }
    }
}
