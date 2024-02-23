using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace WpfApp1.NewFolder
{
    /// <summary>
    /// Interaction logic for FrmKolicina.xaml
    /// </summary>
    public partial class FrmKolicina : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;



        public FrmKolicina(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            tbKolicina.Focus();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
            konekcija = kon.KreirajKonekciju();
        }

        public FrmKolicina()
        {
            InitializeComponent();
            tbKolicina.Focus();
            konekcija = kon.KreirajKonekciju();
        }



        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@Kolicina", SqlDbType.NVarChar).Value = tbKolicina.Text;
                if (azuriraj)
                {
                    DataRowView red = pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update Kolicina set BrojBoca=@Kolicina where KolicinaID=@id";
                    pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into Kolicina(BrojBoca)
                                    values(@Kolicina)";
                }

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos podataka nije validan!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                konekcija?.Close();
            }
        }


        private void btnOtkazi_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
