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
    /// Interaction logic for FrmRadnik.xaml
    /// </summary>
    public partial class FrmRadnik : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;

        public FrmRadnik(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            txtIme.Focus();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
            konekcija = kon.KreirajKonekciju();
        }

        public FrmRadnik()
        {
            InitializeComponent();
            txtIme.Focus();
            konekcija = kon.KreirajKonekciju();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija = kon.KreirajKonekciju();
                konekcija.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                    cmd.Parameters.Add("@Ime", SqlDbType.NVarChar).Value=txtIme.Text;
                    cmd.Parameters.Add("@Prezime", SqlDbType.NVarChar).Value=txtPrezime.Text;
                    cmd.Parameters.Add("@JMBG", SqlDbType.NVarChar).Value=txtJMBG.Text;
                    cmd.Parameters.Add("@Adresa", SqlDbType.NVarChar).Value=txtAdresa.Text;
                    cmd.Parameters.Add("@Telefon", SqlDbType.NVarChar).Value=txtTelefon.Text;
                if (azuriraj)
                {
                    DataRowView red = pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update Radnik set RadnikIme=@Ime, RadnikPrezime=@Prezime,
                                        RadnikJMBG=@JMBG, RadnikAdresa=@Adresa, RadnikTelefon=@Telefon where RadnikID=@id";
                    pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into Radnik(RadnikIme,RadnikPrezime,RadnikJMBG,RadnikAdresa,RadnikTelefon)
                                    values(@Ime,@Prezime,@JMBG,@Adresa,@Telefon)";
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


        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
