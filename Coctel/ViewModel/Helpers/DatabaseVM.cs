using CoctelClasses.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Coctel.ViewModel.Helpers
{
    
    class DatabaseVM
    {
        public static SqlConnection GetDBConnection(string dataSource, string initialCatalog, string user, string password)
        {
            // Connection string = Data Source=DESKTOP-HVNP78O;Initial Catalog=CoctelDB;Persist Security Info=True;User ID=sa;Password=developing

            string connectionString = $"Data Source={dataSource};Initial Catalog={initialCatalog};Persist Security Info=True;User ID={user};Password={password}";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }

        public static SqlConnection GetDBConnection()
        {
            string dataSource = "DESKTOP-HVNP78O";
            string initialCatalog = "CoctelDB";
            string user = "sa";
            string password = "developing";
            return GetDBConnection(dataSource, initialCatalog, user, password);
        }
        public static bool InsertCocktail(Cocktail item, Usuario user)
        {
            bool result = false;
            SqlConnection connection = GetDBConnection();
            connection.Open();
            try
            {
                // Definicion de comando Insert

                SqlCommand insertCommand = connection.CreateCommand();
                int usuario_id = user.ID;
                int coctel_id = item.ID;
                insertCommand.CommandText = "INSERT INTO Favorito (usuario_ID, coctel_ID) VALUES (@usuario_ID, @coctel_ID)";

                // Creacion de parametros

                SqlParameter userParam = insertCommand.Parameters.Add("@usuario_ID", SqlDbType.Int);
                userParam.Value = user.ID;

                SqlParameter coctelParam = insertCommand.Parameters.Add("@coctel_ID", SqlDbType.Int);
                coctelParam.Value = item.ID;

                // Ejecucion del comando
                if (insertCommand.ExecuteNonQuery() > 0) result = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
            return result;

        }
        public static bool InsertIngrediente(Ingrediente item, Usuario user)
        {
            bool result = false;
            SqlConnection connection = GetDBConnection();
            connection.Open();
            try
            {
                // Definicion de comando Insert

                SqlCommand insertCommand = connection.CreateCommand();
                int usuario_id = user.ID;
                int coctel_id = item.ID;
                insertCommand.CommandText = "INSERT INTO Inventario (usuario_ID, ingrediente_ID) VALUES (@usuario_ID, @ingrediente_ID)";

                // Creacion de parametros

                SqlParameter userParam = insertCommand.Parameters.Add("@usuario_ID", SqlDbType.Int);
                userParam.Value = user.ID;

                SqlParameter ingredienteParam = insertCommand.Parameters.Add("@ingrediente_ID", SqlDbType.Int);
                ingredienteParam.Value = item.ID;

                // Ejecucion del comando
                if (insertCommand.ExecuteNonQuery() > 0) result = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
            return result;
        }
        public static bool DeleteCocktail(Cocktail item, Usuario user)
        {
            {
                bool result = false;
                SqlConnection connection = GetDBConnection();
                connection.Open();
                try
                {
                    // Definicion de comando Delete

                    SqlCommand insertCommand = connection.CreateCommand();
                    int usuario_id = user.ID;
                    int coctel_id = item.ID;
                    insertCommand.CommandText = "DELETE FROM Favorito WHERE (usuario_ID = @usuario_ID and coctel_ID=@coctel_ID)";

                    // Creacion de parametros

                    SqlParameter userParam = insertCommand.Parameters.Add("@usuario_ID", SqlDbType.Int);
                    userParam.Value = user.ID;

                    SqlParameter coctelParam = insertCommand.Parameters.Add("@coctel_ID", SqlDbType.Int);
                    coctelParam.Value = item.ID;

                    // Ejecucion del comando
                    if (insertCommand.ExecuteNonQuery() > 0) result = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e);
                    Console.WriteLine(e.StackTrace);
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                    connection = null;
                }
                return result;
            }
            
        }
        public static bool DeleteIngrediente(Ingrediente item, Usuario user)
        {
            bool result = false;
            SqlConnection connection = GetDBConnection();
            connection.Open();
            try
            {
                // Definicion de comando Delete

                SqlCommand insertCommand = connection.CreateCommand();
                int usuario_id = user.ID;
                int coctel_id = item.ID;
                insertCommand.CommandText = "DELETE FROM Ingrediente WHERE (usuario_ID = @usuario_ID and ingrediente_ID =@ingrediente_ID)";

                // Creacion de parametros

                SqlParameter userParam = insertCommand.Parameters.Add("@usuario_ID", SqlDbType.Int);
                userParam.Value = user.ID;

                SqlParameter coctelParam = insertCommand.Parameters.Add("@coctel_ID", SqlDbType.Int);
                coctelParam.Value = item.ID;

                // Ejecucion del comando
                if (insertCommand.ExecuteNonQuery() > 0) result = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
            return result;
        }
    }

}



