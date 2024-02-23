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
using System.Data;
using System.Data.SqlClient;
using System.IO.Packaging;
using WpfApp1.NewFolder;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string ucitanaTabela;
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        

        #region Select upiti
        static string porudzbinaSelect = @"Select PorudzbinaID as ID, ImeLokala + ' ' + Imekupca + ' '+PrezimeKupca as Kupac, NazivPica as Pice,  BrojBoca as Kolicina, RadnikIme + ' ' +  RadnikPrezime as Radnik, TransportID as Transport, MagacinID as Magacin
                                            from Porudzbina 
											join Pice on Porudzbina.PiceID=Pice.PiceID 
                                            join Kupac on Porudzbina.KupacID=Kupac.KupacID 
                                            join Kolicina on Porudzbina.KolicinaID=Kolicina.KolicinaID 
                                            join Radnik on Porudzbina.RadnikID=Radnik.RadnikID";
        static string piceSelect = @"Select PiceID as ID, NazivPica as 'Naziv Pica' from Pice";
        static string kupacSelect = @"Select KupacID as ID, ImeKupca as 'ImeKupca', PrezimeKupca as 'PrezimeKupca', ImeLokala as 'ImeLokala', AdresaLokala as 'AdresaLokala', TelefonLokala as 'TelefonLokala' from Kupac";
        static string kolicinaSelect = @"Select KolicinaID as ID, BrojBoca as 'BrojBoca' from Kolicina";
        static string radnikSelect = @"Select RadnikID as ID, RadnikIme as 'RadnikIme', RadnikPrezime as 'RadnikPrezime', RadnikJMBG as 'RadnikJMBG', RadnikAdresa as 'RadnikAdresa', RadnikTelefon as 'RadnikTelefon' from Radnik";
        static string magacinSelect = @"select MagacinID as ID, NazivMagacina as 'Magacin' from Magacin";
        
        #endregion


        #region Select upiti
        string porudzbinaUslovSelect = @"select*from Porudzbina where PorudzbinaID=";
        string piceUslovSelect = @"select * from Pice where PiceID=";
        string kolicinaUslovSelect = @"select * from Kolicina where KolicinaID=";
        string kupacUslovSelect = @"select *from Kupac where KupacID=";
        string radnikUslovSelect = @"select * from Radnik where RadnikID=";
        string magacinUslovSelect = @"select * from Magacin where MagacinID=";
        #endregion

        #region Select delete
        string porudzbinaDelete = @"delete from Porudzbina where PorudzbinaID=";
        string piceDelete = @"delete from Pice where PiceID=";
        string kolicinaDelete = @"delete from Kolicina where KolicinaID=";
        string kupacDelete = @"delete from Kupac where KupacID=";
        string radnikDelete = @"delete from Radnik where RadnikID=";
        string magacinDelete = @"delete from Magacin where MagacinID=";
        #endregion

        public MainWindow()
        {

            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            UcitajPodatke(dataGridCentralni, porudzbinaSelect);
            btnIzmeni.Visibility = Visibility.Hidden;


    }
        private void UcitajPodatke(DataGrid grid, string selectUpit)
        {
            {
                konekcija?.Close();
            } 

            try
            {
                konekcija.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectUpit, konekcija);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                if (grid != null)
                {
                    grid.ItemsSource = dt.DefaultView;
                }
                ucitanaTabela = selectUpit;
                dt.Dispose();
                dataAdapter.Dispose();
            }
            catch (SqlException)
            {
                MessageBox.Show("Neuspešno učitani podaci.", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                konekcija?.Close();
            }

        }

        /// -----------------------------------------------------------------------------------------------------
        //DUGMAD

        private void btnPorudzbina_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, porudzbinaSelect);
            btnIzmeni.Visibility = Visibility.Hidden;
        }

        private void btnPice_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, piceSelect);
            btnIzmeni.Visibility = Visibility.Visible;

        }

        private void btnKupac_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, kupacSelect);
            btnIzmeni.Visibility = Visibility.Visible;
        }

        private void btnKolicina_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, kolicinaSelect);
            btnIzmeni.Visibility = Visibility.Visible;
        }

        private void btnRadnik_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, radnikSelect);
            btnIzmeni.Visibility = Visibility.Visible;
        }

        private void btnMagacin_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, magacinSelect);
            btnIzmeni.Visibility = Visibility.Visible;
        }



        /// -----------------------------------------------------------------------------------------------------

        //DODAJ
        

        private void btnDodaj_Click_1(object sender, RoutedEventArgs e)
        {
            Window prozor;

            if (ucitanaTabela.Equals(porudzbinaSelect))
            {
                prozor = new FrmPorudzbina();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, porudzbinaSelect);
            }
            else if (ucitanaTabela.Equals(piceSelect))
            {
                prozor = new FrmPice();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, piceSelect);
            }
            else if (ucitanaTabela.Equals(kupacSelect))
            {
                prozor = new FrmKupacNovi();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, kupacSelect);

            }
            else if (ucitanaTabela.Equals(kolicinaSelect))
            {
                prozor = new FrmKolicina();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, kolicinaSelect);

            }
            else if (ucitanaTabela.Equals(radnikSelect))
            {
                prozor = new FrmRadnik();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, radnikSelect);
            }
            else if (ucitanaTabela.Equals(magacinSelect))
            {
                prozor = new FrmMagacin();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, magacinSelect);
            }
        }




        /// -----------------------------------------------------------------------------------------------------

        //OBRISI
        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(porudzbinaSelect))
            {
                ObrisiZapis(porudzbinaDelete);
                UcitajPodatke(dataGridCentralni, porudzbinaSelect);
            }
            else if (ucitanaTabela.Equals(piceSelect))
            {
                ObrisiZapis(piceDelete);
                UcitajPodatke(dataGridCentralni, piceSelect);
            }
            else if (ucitanaTabela.Equals(kolicinaSelect))
            {
                ObrisiZapis(kolicinaDelete);
                UcitajPodatke(dataGridCentralni, kolicinaSelect);
            }
            else if (ucitanaTabela.Equals(kupacSelect))
            {
                ObrisiZapis(kupacDelete);
                UcitajPodatke(dataGridCentralni, kupacSelect);
            }
            else if (ucitanaTabela.Equals(radnikSelect))
            {
                ObrisiZapis(radnikDelete);
                UcitajPodatke(dataGridCentralni, radnikSelect);
            }
            else if (ucitanaTabela.Equals(magacinSelect))
            {
                ObrisiZapis(magacinDelete);
                UcitajPodatke(dataGridCentralni, magacinSelect);
            }
        }
        void ObrisiZapis(string deleteUpit)
        {
            try
            {
                konekcija.Open();
                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];
                string s = red[0].ToString();
               

                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Obaveštenje", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = konekcija
                    };
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = deleteUpit + "@id";
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (SqlException)
            {
                MessageBox.Show("Ne postoje povezani podaci u drugim tabelama", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        /// -----------------------------------------------------------------------------------------------------

        //IZMENI

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela == porudzbinaSelect)
            {
                PopuniFormu(dataGridCentralni, porudzbinaUslovSelect);
                UcitajPodatke(dataGridCentralni, porudzbinaSelect);
                btnIzmeni.Visibility = Visibility.Hidden;
            }
            else if (ucitanaTabela == piceSelect)
            {
                PopuniFormu(dataGridCentralni, piceUslovSelect);
                UcitajPodatke(dataGridCentralni, piceSelect);
            }
            else if (ucitanaTabela == kolicinaSelect)
            {
                PopuniFormu(dataGridCentralni, kolicinaUslovSelect);
                UcitajPodatke(dataGridCentralni, kolicinaSelect);
            }
            else if (ucitanaTabela == radnikSelect)
            {
                PopuniFormu(dataGridCentralni, radnikUslovSelect);
                UcitajPodatke(dataGridCentralni, radnikSelect);
            }
            else if (ucitanaTabela == kupacSelect)
            {
                PopuniFormu(dataGridCentralni, kupacUslovSelect);
                UcitajPodatke(dataGridCentralni, kupacSelect);
            }
            else if (ucitanaTabela == magacinSelect)
            {
                PopuniFormu(dataGridCentralni, magacinUslovSelect);
                UcitajPodatke(dataGridCentralni, magacinSelect);
            }
        }



        void PopuniFormu(DataGrid grid, string selectUslov)
        {
            
            try
            {
                konekcija.Open();
                azuriraj = true;
                DataRowView red = (DataRowView)grid.SelectedItems[0];
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = red[0];
                cmd.CommandText = selectUslov + "@id";
                SqlDataReader citac = cmd.ExecuteReader();
                cmd.Dispose();
                if (citac.Read())
                {
                    if (ucitanaTabela == porudzbinaSelect)
                    {
                        FrmPorudzbina prozorPorudzbina = new FrmPorudzbina(azuriraj, red);

                        prozorPorudzbina.cbPice.Text = citac["PiceID"].ToString();
                        prozorPorudzbina.cbKupac.Text = citac["KupacID"].ToString();
                        prozorPorudzbina.cbKolicina.Text = citac["KOlicinaID"].ToString();
                        prozorPorudzbina.cbRadnik.Text = citac["RadnikID"].ToString();
                        prozorPorudzbina.datePicker.Text = citac["Datum"].ToString();
                        prozorPorudzbina.ShowDialog();
                    }
                    else if (ucitanaTabela == piceSelect)
                    {
                        FrmPice prozorPice = new FrmPice(azuriraj, red);
                        prozorPice.txtPice.Text = citac["NazivPica"].ToString();
                        prozorPice.ShowDialog();
                    }
                    else if (ucitanaTabela == kolicinaSelect)
                    {
                        FrmKolicina prozorKolicina = new FrmKolicina(azuriraj, red);
                        prozorKolicina.tbKolicina.Text = citac["BrojBoca"].ToString();
                        prozorKolicina.ShowDialog();
                    }
                    else if (ucitanaTabela == radnikSelect)
                    {
                        FrmRadnik prozorRadnik = new FrmRadnik(azuriraj, red);
                        prozorRadnik.txtIme.Text = citac["RadnikIme"].ToString();
                        prozorRadnik.txtPrezime.Text = citac["RadnikPrezime"].ToString();
                        prozorRadnik.txtJMBG.Text = citac["RadnikJMBG"].ToString();
                        prozorRadnik.txtAdresa.Text = citac["RadnikAdresa"].ToString();
                        prozorRadnik.txtTelefon.Text = citac["RadnikTelefon"].ToString();
                        prozorRadnik.ShowDialog();
                    }
                    else if (ucitanaTabela == magacinSelect)
                    {
                        FrmMagacin prozorMagacin = new FrmMagacin(azuriraj, red);
                        prozorMagacin.tbMagacin.Text = citac["NazivMagacina"].ToString();
                        prozorMagacin.ShowDialog();
                    }
                    else if (ucitanaTabela == kupacSelect)
                    {
                        FrmKupacNovi prozorKupac = new FrmKupacNovi(azuriraj, red);
                        prozorKupac.txtIme.Text = citac["ImeKupca"].ToString();
                        prozorKupac.txtPrezime.Text = citac["PrezimeKupca"].ToString();
                        prozorKupac.txtImeLokala.Text = citac["ImeLokala"].ToString();
                        prozorKupac.txtAdresa.Text = citac["AdresaLokala"].ToString();
                        prozorKupac.txtTelefon.Text = citac["TelefonLokala"].ToString();
                        prozorKupac.ShowDialog();
                    }
                }
            }

            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                konekcija?.Close();
                azuriraj = false;
            }
        }
                     
     }
}
