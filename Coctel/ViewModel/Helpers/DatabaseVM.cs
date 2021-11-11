using CoctelClasses.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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
        public static bool Insert(int item, Usuario user, string table)
        {
            bool result = false;
            SqlConnection connection = GetDBConnection();
            connection.Open();
            try
            {
                // Definicion de comando Insert

                SqlCommand command = connection.CreateCommand();
                command.CommandText = $"INSERT INTO {table} VALUES (@usuario_ID, @item_ID)";

                // Creacion de parametros

                SqlParameter userParam = command.Parameters.Add("@usuario_ID", SqlDbType.Int);
                userParam.Value = user.ID;

                SqlParameter itemParam = command.Parameters.Add("@item_ID", SqlDbType.Int);
                itemParam.Value = item;


                // Ejecucion del comando
                if (command.ExecuteNonQuery() > 0) result = true;
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
        public static bool Delete(int item, Usuario user, string table)
        {
            {
                bool result = false;
                SqlConnection connection = GetDBConnection();
                connection.Open();
                string table_ID = "";
                if (table == "Inventario") table_ID = "ingrediente_ID";
                if (table == "Favorito") table_ID = "coctel_ID";
                try
                {
                    // Definicion de comando Delete

                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = $"DELETE FROM {table} WHERE (usuario_ID = @usuario_ID and {table_ID}=@item_ID)";

                    // Creacion de parametros

                    SqlParameter userParam = command.Parameters.Add("@usuario_ID", SqlDbType.Int);
                    userParam.Value = user.ID;

                    SqlParameter itemParam = command.Parameters.Add("@item_ID", SqlDbType.Int);
                    itemParam.Value = item;

                    // Ejecucion del comando
                    if (command.ExecuteNonQuery() > 0) result = true;
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

        public static List<Cocktail> Read()
        {
            List<Cocktail> result = new List<Cocktail>();
            List<Ingrediente> first = new List<Ingrediente>();           
            result.Clear();
            SqlConnection connection = GetDBConnection();
            connection.Open();
            try
            {
                // Definicion de comando Query

                SqlCommand command = new SqlCommand("SELECT C.*, T.nombre AS tipo FROM Coctel C INNER JOIN Tipo T ON C.tipo_ID = T.tipo_ID WHERE C.porcentaje_Recomendacion >= 70 ", connection);

                // Ejecucion del comando

                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id_column = reader.GetOrdinal("coctel_ID");
                            int newID = Convert.ToInt32(reader.GetValue(id_column));

                            int descripcion_column = reader.GetOrdinal("descripcion");
                            string newDescripcion = reader.GetString(descripcion_column);

                            int nombre_column = reader.GetOrdinal("nombre");
                            string newNombre = reader.GetString(nombre_column);

                            int dificultad_column = reader.GetOrdinal("dificultad");
                            int newDificultad = Convert.ToInt32(reader.GetValue(dificultad_column));

                            int tipo_column = reader.GetOrdinal("tipo");
                            string newTipo = reader.GetString(tipo_column);

                            int tiempo_column = reader.GetOrdinal("tiempo_Elaboracion");
                            int newTiempo = Convert.ToInt32(reader.GetValue(tiempo_column));

                            int porcentaje_column = reader.GetOrdinal("porcentaje_Recomendacion");
                            int newPorcentaje = Convert.ToInt32(reader.GetValue(porcentaje_column));

                            Cocktail cocktail = new Cocktail()
                            {
                                ID = newID,
                                Descripcion = newDescripcion,
                                Nombre = newNombre,
                                Dificultad = newDificultad,
                                Tipo = newTipo,
                                TiempoElaboracion = newTiempo,
                                PorcentajeRecomendacion = newPorcentaje,
                            };
                            result.Add(cocktail);                         
                        }
                    }
                }
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
        public static List<Cocktail> Read(string query) //Override para búsqueda de cócteles
        {
            List<Cocktail> result = new List<Cocktail>();
            SqlConnection connection = GetDBConnection();
            connection.Open();
            try
            {
                // Definicion de comando Query

                SqlCommand command = new SqlCommand($"SELECT C.*, T.nombre AS tipo FROM Coctel C INNER JOIN Tipo T ON C.tipo_ID = T.tipo_ID WHERE C.nombre LIKE '%{query}%'", connection);

                // Ejecucion del comando

                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id_column = reader.GetOrdinal("coctel_ID");
                            int newID = Convert.ToInt32(reader.GetValue(id_column));

                            int descripcion_column = reader.GetOrdinal("descripcion");
                            string newDescripcion = reader.GetString(descripcion_column);

                            int nombre_column = reader.GetOrdinal("nombre");
                            string newNombre = reader.GetString(nombre_column);

                            int dificultad_column = reader.GetOrdinal("dificultad");
                            int newDificultad = Convert.ToInt32(reader.GetValue(dificultad_column));

                            int tipo_column = reader.GetOrdinal("tipo");
                            string newTipo = reader.GetString(tipo_column);

                            int tiempo_column = reader.GetOrdinal("tiempo_Elaboracion");
                            int newTiempo = Convert.ToInt32(reader.GetValue(tiempo_column));

                            int porcentaje_column = reader.GetOrdinal("porcentaje_Recomendacion");
                            int newPorcentaje = Convert.ToInt32(reader.GetValue(porcentaje_column));

                            Cocktail cocktail = new Cocktail()
                            {
                                ID = newID,
                                Descripcion = newDescripcion,
                                Nombre = newNombre,
                                Dificultad = newDificultad,
                                Tipo = newTipo,
                                TiempoElaboracion = newTiempo,
                                PorcentajeRecomendacion = newPorcentaje
                            };
                            result.Add(cocktail);
                        }
                    }
                }
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
        public static List<Cocktail> Read(Usuario user) // Override del metodo anterior que devuelve lista de favoritos
        {
            List<Cocktail> result = new List<Cocktail>();
            result.Clear();
            SqlConnection connection = GetDBConnection();
            connection.Open();
            try
            {
                // Definicion de comando Query

                SqlCommand command = new SqlCommand("SELECT C.*, T.nombre AS tipo FROM Favorito F INNER JOIN Coctel C ON F.coctel_ID = C.coctel_ID INNER JOIN Tipo T ON C.tipo_ID = T.tipo_ID WHERE F.usuario_ID = @usuario_ID", connection);

                // Creacion de parametros

                SqlParameter userParam = command.Parameters.Add("@usuario_ID", SqlDbType.Int);
                userParam.Value = user.ID;

                // Ejecucion del comando


                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id_column = reader.GetOrdinal("coctel_ID");
                            int newID = Convert.ToInt32(reader.GetValue(id_column));

                            int descripcion_column = reader.GetOrdinal("descripcion");
                            string newDescripcion = reader.GetString(descripcion_column);

                            int nombre_column = reader.GetOrdinal("nombre");
                            string newNombre = reader.GetString(nombre_column);

                            int dificultad_column = reader.GetOrdinal("dificultad");
                            int newDificultad = Convert.ToInt32(reader.GetValue(dificultad_column));

                            int tipo_column = reader.GetOrdinal("tipo");
                            string newTipo = reader.GetString(tipo_column);

                            int tiempo_column = reader.GetOrdinal("tiempo_Elaboracion");
                            int newTiempo = Convert.ToInt32(reader.GetValue(tiempo_column));

                            int porcentaje_column = reader.GetOrdinal("porcentaje_Recomendacion");
                            int newPorcentaje = Convert.ToInt32(reader.GetValue(porcentaje_column));

                            Cocktail cocktail = new Cocktail()
                            {
                                ID = newID,
                                Descripcion = newDescripcion,
                                Nombre = newNombre,
                                Dificultad = newDificultad,
                                Tipo = newTipo,
                                TiempoElaboracion = newTiempo,
                                PorcentajeRecomendacion = newPorcentaje,
                            };
                            result.Add(cocktail);
                        }
                    }
                }
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
        public static List<Ingrediente> Read(Cocktail item) // Override que devuelve la lista de ingredientes de un cóctel
        {
            List<Ingrediente> result = new List<Ingrediente>();
            result.Clear();
            SqlConnection connection = GetDBConnection();
            connection.Open();
            try
            {
                // Definicion de comando Query

                SqlCommand command = new SqlCommand("SELECT I.*, C.cantidad FROM Contenido C INNER JOIN Ingrediente I ON C.ingrediente_ID = I.ingrediente_ID WHERE C.coctel_ID = @coctel_ID", connection);

                // Creacion de parametros

                SqlParameter cocktailParam = command.Parameters.Add("@coctel_ID", SqlDbType.Int);
                cocktailParam.Value = item.ID;

                // Ejecucion del comando


                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id_column = reader.GetOrdinal("ingrediente_ID");
                            int newID = Convert.ToInt32(reader.GetValue(id_column));

                            int calorias_column = reader.GetOrdinal("calorias");
                            int newCalorias = Convert.ToInt32(reader.GetValue(calorias_column));

                            int nombre_column = reader.GetOrdinal("nombre");
                            string newNombre = reader.GetString(nombre_column);

                            int porcentaje_column = reader.GetOrdinal("porcentaje_Alcohol");
                            int newPorcentaje = Convert.ToInt32(reader.GetValue(porcentaje_column));

                            int cantidad_column = reader.GetOrdinal("cantidad");
                            int newCantidad = Convert.ToInt32(reader.GetValue(cantidad_column));

                            Ingrediente ingrediente = new Ingrediente()
                            {
                                ID = newID,
                                Nombre = newNombre,
                                Calorias = newCalorias,
                                PorcentajeAlcohol = newPorcentaje,
                                Cantidad = newCantidad
                            };
                            result.Add(ingrediente);
                        }
                    }
                }
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
        public static List<Ingrediente> ReadInventario(Usuario user) // Override del metodo anterior que devuelve lista de favoritos
        {
            List<Ingrediente> result = new List<Ingrediente>();
            result.Clear();
            SqlConnection connection = GetDBConnection();
            connection.Open();
            try
            {
                // Definicion de comando Query

                SqlCommand command = new SqlCommand("SELECT Ing.* FROM Inventario Inv INNER JOIN Ingrediente Ing ON Inv.ingrediente_id = Ing.ingrediente_ID WHERE Inv.usuario_ID = @usuario_ID", connection);

                // Creacion de parametros

                SqlParameter userParam = command.Parameters.Add("@usuario_ID", SqlDbType.Int);
                userParam.Value = user.ID;

                // Ejecucion del comando


                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id_column = reader.GetOrdinal("coctel_ID");
                            int newID = Convert.ToInt32(reader.GetValue(id_column));

                            int nombre_column = reader.GetOrdinal("nombre");
                            string newNombre = reader.GetString(nombre_column);

                            Ingrediente ingrediente = new Ingrediente()
                            {
                                ID = newID,
                                
                                Nombre = newNombre,
                                
                            };
                            result.Add(ingrediente);
                        }
                    }
                }
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
        public static Usuario Login(Usuario usuario)
        {
            var favoritos = new List<Cocktail>();
            var inventario = new List<Ingrediente>();
           
            SqlConnection connection = GetDBConnection();
            connection.Open();
            try
            {
                // Definicion de comando Query

                SqlCommand command = new SqlCommand($"SELECT * FROM Usuario WHERE nombre = '{usuario.Nombre}' AND clave = '{usuario.Password}'", connection);


                // Ejecucion del comando


                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id_column = reader.GetOrdinal("usuario_ID");
                            int newID = Convert.ToInt32(reader.GetValue(id_column));

                            usuario.ID = newID;

                            favoritos = Read(usuario);
                            inventario = ReadInventario(usuario);
                            usuario.Favoritos = favoritos;
                            usuario.Inventario = inventario;
                        }
                    }
                    
                }
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
            return usuario;

        }

    }

}
