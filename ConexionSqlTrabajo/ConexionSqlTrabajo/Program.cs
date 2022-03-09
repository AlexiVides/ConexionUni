﻿using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConexionSqlTrabajo
{
    class Estudiante
    {
        static void Main(string[] args)
        {
            //Nombre del servidor
            //string DataSource = "LAPTOP-G5GPCEC8";
            ////nombre de la base de datos
            //string InitialCatalog = "Universidad";
            ////Autentiticacion
            //string IntegratedSecurity = "SSPI";
            string connectionString = "Data Source=LAPTOP-2B7JL8HS\\SQLEXPRESS;Initial Catalog=Universidad;Integrated Security=SSPI";
                
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
                    Console.WriteLine("3-Ver registro");
                    Console.WriteLine("4- Salir");
                    Console.WriteLine("----------------------");
                    int opc = Convert.ToInt32(Console.ReadLine());

                    if (opc == 1)
                    {
                        Console.WriteLine("Ingresar el nombre del estudiante");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("Ingresar el apellido");
                        string apellido = Console.ReadLine();
                        Console.WriteLine("Ingresar la edad");
                        int edad = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingresar el codigo");
                        string codigo = Console.ReadLine();
                        Console.WriteLine("Ingresar el telefono");
                        string telefono = Console.ReadLine();

                        string insert = "insert into Estudiante(nombre,apellido,edad,codigo,telefono) values('" + nombre + "', '" + apellido + "', '" + edad + "', '" + codigo + "', '" + telefono + "')";
                       
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
                            
                            string cadena = "select * from Estudiante";
                            SqlCommand comando = new SqlCommand(cadena, connection1);
                            SqlDataReader lector = comando.ExecuteReader();

                            Console.WriteLine("Id   " + "   Nombre    " + "   Apellido    " + "  Edad    " + "  Codigo    " + "     Telefono");
                            while (lector.Read())
                            {

                                Console.WriteLine(lector.GetValue(0).ToString() + "       " + lector.GetValue(1).ToString() + "         " + lector.GetValue(2).ToString() + "         " + lector.GetValue(3).ToString() + "       " + lector.GetValue(4).ToString() + "       " + lector.GetValue(5).ToString());
                                
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ha ocurrido un error" + ex.Message);
                            Console.WriteLine("La base de datos ha sido cerrada");
                           
                        }
                        connection1.Close();
                    }
                    if (opc == 3)
                    {
                        Console.WriteLine("Ingrese el id que se desea eliminar");
                        int iden = Convert.ToInt32(Console.ReadLine());
                        string delete = "delete from Estudiante where id =  '" + iden + "' ";

                        try
                        {

                            SqlCommand comando = new SqlCommand(delete, connection1);
                            comando.ExecuteNonQuery();
                            Console.WriteLine("Se ha eliminado correctamente");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ha ocurrido un error" + ex.Message);

                        }
                        connection1.Close();
                    }
                    if (opc == 4)
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
