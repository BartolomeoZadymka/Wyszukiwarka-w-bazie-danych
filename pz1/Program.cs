using System;
using System.Data.SqlClient;

namespace WyszukiwarkaBazyDanych
{
    class Program
    {
        static void Main(string[] args)
        {
            // Tworzymy połączenie z bazą danych
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MojaBazaDanych;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            // Tworzymy zapytanie SQL do wyszukiwania elementów w bazie danych
            string searchTerm = "słowo kluczowe";
            string query = "SELECT * FROM MojaTabela WHERE Nazwa LIKE '%" + searchTerm + "%'";

            // Tworzymy obiekt komendy i podłączamy go do połączenia z bazą danych
            SqlCommand command = new SqlCommand(query, connection);

            // Wykonujemy zapytanie i pobieramy wynik
            SqlDataReader reader = command.ExecuteReader();

            // Iterujemy przez wiersze wyniku zapytania i wyświetlamy je na ekranie
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                Console.WriteLine("ID: {0}, Nazwa: {1}", id, name);
            }

            // Zamykamy połączenie z bazą danych
            connection.Close();
        }
    }
}