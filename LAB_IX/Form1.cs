using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
    
namespace LAB_IX
{
    public partial class Form1 : Form
    {
        private string connectionString;
        string path;
        string poznan_dnia_gora = "";
        string numer_albumu = "";
        string nazwisko_ime = "";
        string semestr_rok = "";
        string kierunek_stopien = "";
        string z_przedmiotu = "";
        string punkty = "";
        string prowadzony_przez = "";
        string uzasadnienie = "";
        string data_i_podpis = "";
        string s_1 = "";
        string s_2 = "";
        string s_3 = "";
        string poznan_dnia_dol = "";
        string pieczotka_i_podpis = "";
        int Id = 1;
        public Form1()
        {
            string workingDirectory = Environment.CurrentDirectory;

            path = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            connectionString = @"Data Source=" + path + "/base.db";
            InitializeComponent();
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                string query = "SELECT * FROM Wnioski";
                SqliteCommand command = new SqliteCommand(query, connection);
                try
                {
                    connection.Open();
                    SqliteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Id = reader.GetInt32(0); // Assuming Id is the first column
                        poznan_dnia_gora = reader.GetString(1);
                        numer_albumu = reader.GetString(2);
                        nazwisko_ime = reader.GetString(3);
                        semestr_rok = reader.GetString(4);
                        kierunek_stopien = reader.GetString(5);
                        z_przedmiotu = reader.GetString(6);
                        punkty = reader.GetString(7);
                        prowadzony_przez = reader.GetString(8);
                        uzasadnienie = reader.GetString(9);
                        data_i_podpis = reader.GetString(10);
                        s_1 = reader.GetString(11);
                        s_2 = reader.GetString(12);
                        s_3 = reader.GetString(13);
                        poznan_dnia_dol = reader.GetString(14);
                        pieczotka_i_podpis = reader.GetString(15);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            aktualizuj();

        }
        private void aktualizuj()
        {
            textBox_data_i_podpis_studenta.Text = data_i_podpis;
            textBox_kierunek_i_stopien.Text = kierunek_stopien;
            textBox_nazwisko_i_imie.Text = nazwisko_ime;
            textBox_numer_albumu.Text = numer_albumu;
            textBox_pieczotka_podmip.Text = pieczotka_i_podpis;
            textBox_poznan_dnia.Text = poznan_dnia_gora;
            textBox_poznan_dni_dol.Text = poznan_dnia_dol;
            textBox_prowadzony_przez.Text = prowadzony_przez;
            textBox_punkty.Text = punkty;
            textBox_semestr_rok.Text = semestr_rok;
            textBox_s_1.Text = s_1;
            textBox_s_2.Text = s_2;
            textBox_s_3.Text = s_3;
            textBox_uzasadnienie.Text = uzasadnienie;
            textBox_z_przedmiotu.Text = z_przedmiotu;
        }
        private void button_save_Click(object sender, EventArgs e)
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                string query = "INSERT INTO Wnioski (Id, poznan_dnia_gora, numer_albumu, nazwisko_ime, semestr_rok, kierunek_stopien, z_przedmiotu, punkty, prowadzony_przez, uzasadnienie, data_i_podpis, s_1, s_2, s_3, poznan_dnia_dol, pieczotka_i_podpis) VALUES (@Id, @poznan_dnia_gora, @numer_albumu, @nazwisko_ime, @semestr_rok, @kierunek_stopien, @z_przedmiotu, @punkty, @prowadzony_przez, @uzasadnienie, @data_i_podpis, @s_1, @s_2, @s_3, @poznan_dnia_dol, @pieczotka_i_podpis)";
                SqliteCommand command = new SqliteCommand(query, connection);
                command.Parameters.AddWithValue("@Id", Id);
                command.Parameters.AddWithValue("@poznan_dnia_gora", poznan_dnia_gora);
                command.Parameters.AddWithValue("@ numer_albumu", numer_albumu);
                command.Parameters.AddWithValue("@nazwisko_ime", nazwisko_ime);
                command.Parameters.AddWithValue("@semestr_rok", semestr_rok);
                command.Parameters.AddWithValue("@kierunek_stopien", kierunek_stopien);
                command.Parameters.AddWithValue("@z_przedmiotu", z_przedmiotu);
                command.Parameters.AddWithValue("@punkty", punkty);
                command.Parameters.AddWithValue("@prowadzony_przez", prowadzony_przez);
                command.Parameters.AddWithValue("@uzasadnienie", uzasadnienie);
                command.Parameters.AddWithValue("@data_i_podpis", data_i_podpis);
                command.Parameters.AddWithValue("@s_1", s_1);
                command.Parameters.AddWithValue("@s_2", s_2);
                command.Parameters.AddWithValue("@s_3", s_3);
                command.Parameters.AddWithValue("@poznan_dnia_dol", poznan_dnia_dol);
                command.Parameters.AddWithValue("@pieczotka_i_podpis", pieczotka_i_podpis);
                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} row(s) inserted.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }


        }
    }
}
/*
string query = "INSERT INTO Users (Id, poznan_dnia_gora, numer_albumu, nazwisko_ime, semestr_rok, kierunek_stopien, z_przedmiotu, punkty, prowadzony_przez, uzasadnienie, data_i_podpis, s_1, s_2, s_3, poznan_dnia_dol, pieczotka_i_podpis) VALUES (@Id, @poznan_dnia_gora, @numer_albumu, @nazwisko_ime, @semestr_rok, @kierunek_stopien, @z_przedmiotu, @punkty, @prowadzony_przez, @uzasadnienie, @data_i_podpis, @s_1, @s_2, @s_3, @poznan_dnia_dol, @pieczotka_i_podpis)";
SqlCommand command = new SqlCommand(query, connection);
command.Parameters.AddWithValue("@Id", Id);
command.Parameters.AddWithValue("@poznan_dnia_gora", poznan_dnia_gora);
command.Parameters.AddWithValue("@ numer_albumu", numer_albumu);
command.Parameters.AddWithValue("@nazwisko_ime", nazwisko_ime);
command.Parameters.AddWithValue("@semestr_rok", semestr_rok);
command.Parameters.AddWithValue("@kierunek_stopien", kierunek_stopien);
command.Parameters.AddWithValue("@z_przedmiotu", z_przedmiotu);
command.Parameters.AddWithValue("@punkty", punkty);
command.Parameters.AddWithValue("@prowadzony_przez", prowadzony_przez);
command.Parameters.AddWithValue("@uzasadnienie", uzasadnienie);
command.Parameters.AddWithValue("@data_i_podpis", data_i_podpis);
command.Parameters.AddWithValue("@s_1", s_1);
command.Parameters.AddWithValue("@s_2", s_2);
command.Parameters.AddWithValue("@s_3", s_3);
command.Parameters.AddWithValue("@poznan_dnia_dol", poznan_dnia_dol);
command.Parameters.AddWithValue("@pieczotka_i_podpis", pieczotka_i_podpis);
*/