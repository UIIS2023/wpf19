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
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace WpfApp1.NewFolder
{
    /// <summary>
    /// Interaction logic for FrmPorudzbina.xaml
    /// </summary>
    public partial class FrmPorudzbina : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;

        public FrmPorudzbina(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            cbPice.Focus();
            datePicker.SelectedDate = DateTime.Today;
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
            PopuniPadajuceListe();

        }

        public FrmPorudzbina()
        {
            InitializeComponent();
            cbPice.Focus();
            datePicker.SelectedDate = DateTime.Today;
            PopuniPadajuceListe();
        }
        private void PopuniPadajuceListe()
        {
            try
            {
                konekcija = kon.KreirajKonekciju();
                konekcija.Open();
                string vratiPice = @"select PiceID, NazivPica from Pice";
                DataTable dtPice = new DataTable();
                SqlDataAdapter daPice = new SqlDataAdapter(vratiPice, konekcija);
                daPice.Fill(dtPice);
                cbPice.ItemsSource = dtPice.DefaultView;
                dtPice.Dispose();
                daPice.Dispose();

                string vratiKupac = @"select KupacID, ImeKupca from Kupac";
                DataTable dtKupac = new DataTable();
                SqlDataAdapter daKupac = new SqlDataAdapter(vratiKupac, konekcija);
                daKupac.Fill(dtKupac);
                cbKupac.ItemsSource = dtKupac.DefaultView;
                dtKupac.Dispose();
                daKupac.Dispose();

                string vratiKolicina = @"select KolicinaID, BrojBoca from Kolicina";
                DataTable dtKolicina = new DataTable();
                SqlDataAdapter daKolicina = new SqlDataAdapter(vratiKolicina, konekcija);
                daKolicina.Fill(dtKolicina);
                cbKolicina.ItemsSource = dtKolicina.DefaultView;
                dtKolicina.Dispose();
                daKolicina.Dispose();

                string vratiRadnik = @"select RadnikID , RadnikIme from Radnik";
                DataTable dtRadnik = new DataTable();
                SqlDataAdapter daRadnik = new SqlDataAdapter(vratiRadnik, konekcija);
                daRadnik.Fill(dtRadnik);
                cbRadnik.ItemsSource = dtRadnik.DefaultView;
                dtRadnik.Dispose();
                daRadnik.Dispose();

                string vratiMagacin = @"select MagacinID , NazivMagacina from Magacin";
                DataTable dtMagacin = new DataTable();
                SqlDataAdapter daMagacin = new SqlDataAdapter(vratiMagacin, konekcija);
                daMagacin.Fill(dtMagacin);
                cbMagacin.ItemsSource = dtMagacin.DefaultView;
                dtMagacin.Dispose();
                daMagacin.Dispose();


                string vratiTransport = @"select TransportID , OdgovorniZaTransport from Transport";
                DataTable dtTransport = new DataTable();
                SqlDataAdapter daTransport = new SqlDataAdapter(vratiTransport, konekcija);
                daTransport.Fill(dtTransport);
                cbTransport.ItemsSource = dtTransport.DefaultView;
                dtTransport.Dispose();
                daTransport.Dispose();

            }
            catch (SqlException)
            {
                MessageBox.Show("Padajuće liste nisu popunjene!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            //unete vrednosti iz  TexBox-ova prikaz textualnih podataka a ne kljuceva ID
            string strPice = cbPice.Text;
            string strKupac = cbKupac.Text;
            string strKolicina  = cbKolicina.Text;
            string strRadnik = cbRadnik.Text;
            string strDatum = datePicker.Text;
            string strTransport = cbTransport.Text;
            string strMagacin = cbMagacin.Text;

            //dodeljivanje vrednosti ID promenjivima koje kasnije upisujemo u tebelu
            var strPicestr = cbPice.SelectedValue.ToString();
            int intPice = Int32.Parse(strPicestr);

            var strKolicinastr = cbKolicina.SelectedValue.ToString();
            int intKolicina = Int32.Parse(strKolicinastr);

            var strRadnikstr = cbRadnik.SelectedValue.ToString();
            int intRadnik = Int32.Parse(strRadnikstr);

            var strKupacstr = cbKupac.SelectedValue.ToString();
            int intKupac = Int32.Parse(strKupacstr);

            var strTransportstr = cbTransport.SelectedValue.ToString();
            int intTransport = Int32.Parse(strTransportstr);

            var strMagacinstr = cbMagacin.SelectedValue.ToString();
            int intMagacin = Int32.Parse(strMagacinstr);

            


            string kupac_Sacuvaj = @"INSERT INTO Porudzbina(PiceID,KupacID,KolicinaID,Datum,RadnikID,TransportID, MagacinID) VALUES(@PiceID,@KupacID,@KolicinaID,@Datum,@RadnikID,@TransportID,@MagacinID)";

            //snimanje u tabelu novog Kupca
            Konekcija kon = new Konekcija();
            System.Data.SqlClient.SqlConnection konekcija = new SqlConnection();
            konekcija = kon.KreirajKonekciju();
            konekcija.Open();
            SqlCommand cmd = new SqlCommand
            {
                Connection = konekcija
            }; ;

            cmd.CommandText = kupac_Sacuvaj;
            cmd.Parameters.AddWithValue("@PiceID", intPice);
            cmd.Parameters.AddWithValue("@KupacID", intKupac);
            cmd.Parameters.AddWithValue("@KolicinaID", intKolicina);
            cmd.Parameters.AddWithValue("@Datum", strDatum);
            cmd.Parameters.AddWithValue("@RadnikID", intRadnik);
            cmd.Parameters.AddWithValue("@TransportID", intTransport);
            cmd.Parameters.AddWithValue("@MagacinID", intMagacin);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            this.Close();

        }
    }
}
