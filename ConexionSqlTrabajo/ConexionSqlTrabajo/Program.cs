using System.Data.SqlClient;

namespace ConexionSqlTrabajo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Nombre del servidor
            //string DataSource = "LAPTOP-A720PLQ0";
            ////nombre de la base de datos
            //string InitialCatalog = "Universidad";
            ////Autentiticacion
            //string IntegratedSecurity = "SSPI";
            string connectionString = "Data Source=LAPTOP-A720PLQ0;Initial Catalog=Universidad;Integrated Security=SSPI";
                
            try
            {
                int x = 1;
                int y = 2;
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine("La base de datos  se ha conectado correctamente");
                Console.WriteLine("Estado de la conexion" + connection.State.ToString());
                Console.WriteLine("--------------------------------------------------------------------------------");

                
                



                while (true)
                {
                    SqlConnection connection1 = new SqlConnection(connectionString);
                    connection1.Open();
                    Console.WriteLine("Menu");
                    Console.WriteLine("----------------------");
                    Console.WriteLine("1-Ingresar un Registro");
                    Console.WriteLine("2-Ver registro");
                    Console.WriteLine("3- Salir");
                    Console.WriteLine("----------------------");
                    int opc = Convert.ToInt32(Console.ReadLine());
                    
                    if (opc == 1)
                    {
                        Console.WriteLine("Ingresar departamento");
                        string depar = Console.ReadLine();
                        string insert = "insert into departamento(NombreDepart) values('" + depar + "')";
                        try
                        {
                           
                            SqlCommand comando = new SqlCommand(insert, connection1);
                            comando.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ha ocurrido un error" + ex.Message);
                            
                        }
                        connection1.Close();
                    }
                    if (opc == 2)
                    {
                        
                        try
                        {
                            
                            string cadena = "select * from departamento";
                            SqlCommand comando = new SqlCommand(cadena, connection1);
                            SqlDataReader lector = comando.ExecuteReader();

                            Console.WriteLine("Id     " + "  Nombre");
                            while (lector.Read())
                            {

                                Console.WriteLine(lector.GetValue(0).ToString() + "     " + lector.GetValue(1).ToString());
                                
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ha ocurrido un error" + ex.Message);
                            Console.WriteLine("La base de datos ha sido cerrada");
                           
                        }
                        connection1.Close();
                    }
                    if(opc == 3)
                    {
                        break;
                        connection.Close();
                    }
                }








                //string cadena = "select * from departamento";
                //Console.WriteLine("Ingresar departamento");
                //string depar = Console.ReadLine();
                //string insert = "insert into departamento(NombreDepart) values('" + depar + "')";
                //try
                //{
                //    SqlCommand comando = new SqlCommand(insert, connection);
                //    comando.ExecuteNonQuery();
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine("Ha ocurrido un error" + ex.Message);
                //    connection.Close();
                //}
                //try
                //{

                //    SqlCommand comando = new SqlCommand(cadena, connection);
                //    SqlDataReader lector = comando.ExecuteReader();

                //    Console.WriteLine("Id     " + "  Nombre");
                //    while (lector.Read())
                //    {

                //        Console.WriteLine(lector.GetValue(0).ToString() + "     " + lector.GetValue(1).ToString());
                //    }
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine("Ha ocurrido un error" + ex.Message);
                //    Console.WriteLine("La base de datos ha sido cerrada");
                //    connection.Close();
                //}



            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Este es un error de la conexion de la base de datos \n" + ex.Message);
                Console.ReadLine();
                
            }
            

        }
    }
}
