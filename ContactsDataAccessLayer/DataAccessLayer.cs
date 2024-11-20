using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
namespace ContactsDataAccessLayer
{
  
    public class DataAccessLayer
    {
                                                            
        static public bool GetContactsData(int ID,ref string FirstName,ref string LastName,
            ref string Email,ref string Phone,ref string Adress,ref string ImagePath,ref int CountryID,ref DateTime DateOfBirth)
        {
            bool isFound=false;
            SqlConnection connection = new SqlConnection(clsConnectionSetting.ConnectionString);
            string query = "Select * From Contacts where ContactID=@ID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    FirstName=(string)reader["FirstName"];
                    LastName = (string)reader["LastName"];
                    Email = (string)reader["Email"];
                    Phone = (string)reader["Phone"];
                    Adress = (string)reader["Adress"];
                    ImagePath =   (reader["ImagePath"]   != DBNull.Value) ? (string)reader["ImagePath"]     : "Null" ;
                    DateOfBirth = (reader["DateOfBirth"] != DBNull.Value) ? (DateTime)reader["DateOfBirth"] :DateTime.MinValue ;
                    CountryID = (int)reader["CountryID"];

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                isFound = false;
            }
            finally { connection.Close(); }



            return isFound;
        }

        static public int AddNewContact(string FirstName,  string LastName,string Email,string Phone,string Adress,
                                        string ImagePath,int CountryID, DateTime DateOfBirth)
        {
            int AddNew = -1;
            SqlConnection connection = new SqlConnection(clsConnectionSetting.ConnectionString);
            string query = "INSERT INTO [dbo].[Contacts]([FirstName],[LastName],[Email],[Phone],[Adress] ,[CountryID],[ImagePath],[DateOfBirth])" +
                "VALUES(@FirstName,@LastName,@Email,@Phone,@Adress,@CountryID,@ImagePath,@DateOfBirth);" +
                "select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Adress", Adress);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            if (ImagePath != "")
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            }
            
           
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(),out int resultID))
                {
                    AddNew = resultID;
                }
                else
                {
                    Console.WriteLine("Can't Added the line to DB.");
                    AddNew = -1;
                }
              
               
            }
            catch (Exception ex)
            {
               AddNew = -1;
            }
            finally { connection.Close(); }

            return AddNew;
        }

        static public bool DeleteContact(int ID)
        {
            int RowsAfficted = 0;
            SqlConnection connection = new SqlConnection(clsConnectionSetting.ConnectionString);
            string query = "Delete From Contacts where contactID=@ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                RowsAfficted = command.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                Console.WriteLine("Error :=  "+ex.Message);
                RowsAfficted = 0;
            }
            finally { connection.Close(); }

            return (RowsAfficted > 0);
        }

        static public DataTable GetAllContact()
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection =new SqlConnection(clsConnectionSetting.ConnectionString);
            string query = "Select * from Contacts ;";
            SqlCommand command =new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    dataTable.Load(reader);
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine (ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dataTable;
        }

        static public bool isContactExist(int ID)
        {
            bool isFound=false;
            SqlConnection connection =new SqlConnection (clsConnectionSetting.ConnectionString);
            string query = "select Found =1 From Contacts where ContactID = @ID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                isFound = (reader.HasRows);
                reader.Close();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return isFound;
        }
    }
}
