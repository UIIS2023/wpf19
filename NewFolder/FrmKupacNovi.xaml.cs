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
    /// Interaction logic for FrmKupacNovi.xaml
    /// </summary>
    public partial class FrmKupacNovi : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;


        public FrmKupacNovi(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            txtIme.Focus();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
            
        }

        public FrmKupacNovi()
        {
            InitializeComponent();
            txtIme.Focus();
            
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
                cmd.Parameters.Add("@Ime", SqlDbType.NVarChar).Value = txtIme.Text;
                cmd.Parameters.Add("@Prezime", SqlDbType.NVarChar).Value = txtPrezime.Text;
                cmd.Parameters.Add("@ImeLokala", SqlDbType.NVarChar).Value = txtImeLokala.Text;
                cmd.Parameters.Add("@Adresa", SqlDbType.NVarChar).Value = txtAdresa.Text;
                cmd.Parameters.Add("@Telefon", SqlDbType.NVarChar).Value = txtTelefon.Text;
                if (azuriraj)
                {
                    DataRowView red = pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update Kupac set ImeKupca=@Ime, PrezimeKupca=@Prezime, ImeLokala=@ImeLokala,
                                        AdresaLokala=@Adresa, TelefonLokala= @Telefon 
                                        where KupacID=@id";
                    pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into Kupac(ImeKupca,PrezimeKupca,ImeLokala,AdresaLokala,TelefonLokala)
                                    values(@Ime,@Prezime,@ImeLokala,@Adresa,@Telefon)";
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
