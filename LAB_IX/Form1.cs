using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Data;
using System.Data.SqlClient;

using System.Data.SqlClient;
    
namespace LAB_IX
{
    public partial class Form1 : Form
    {

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
        int Id = 0;
        public Form1()
        {
            string workingDirectory = Environment.CurrentDirectory;

            path = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            InitializeComponent();
        }
        
        private void button_load_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(path + "/base.mdf"))
            {
                string query = "SELECT * FROM Users";
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int userId = reader.GetInt32(0); // Assuming Id is the first column
                        string userName = reader.GetString(1); // Assuming Name is the second column
                        Console.WriteLine($"User Id: {userId}, Name: {userName}");
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

        }

        private void button_save_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(path + "\\base.mdf"))
            {
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
