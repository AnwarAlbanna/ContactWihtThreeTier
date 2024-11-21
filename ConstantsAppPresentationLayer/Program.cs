using ConstantBusinssLayer;
using System;
using System.Data;


namespace ConstantsAppPresentationLayer
{
    internal class Program
    {
        // this is function to table contacts in database
        static void testContactFind(int ID)
        {
            clsContacts contact =clsContacts.Find(ID);
            if(contact != null )
            {
                Console.WriteLine( contact.FirstName + " " + contact.LastName );
                Console.WriteLine( contact.Email );
                Console.WriteLine( contact.Phone );
                Console.WriteLine(contact.ImagePath);
                Console.WriteLine(contact.CountryID);
                Console.WriteLine(contact.DateOfBirth);
                

            }
            else
            {
                Console.WriteLine("the contact {" + ID + "} is Not Found !!!");
            }


        }
        static void testContactAdd()
        {
            clsContacts contact = new clsContacts();
            contact.FirstName = "Lamar";
            contact.LastName = "Anwar";
            contact.Email = "lmar@gmail.com";
            contact.Phone = "772652347";
            contact.Adress = "Ibb-Yemen";
            contact.ImagePath = "Null";
            contact.CountryID = 4;
            contact.DateOfBirth = new DateTime(2024, 04, 04);
            if (contact.Save())
            {
                Console.WriteLine("Added Successfully!! :-)[" + contact.ContacID + "]");
            }
            else
            {
                Console.WriteLine(" Can't Added Successfully!! :-( ");

            }
        }

        static void testContactDelete(int ID)
        {

           if( clsContacts.Delete(ID))
                Console.WriteLine("Deleted Successfuly.");
           else
                Console.WriteLine("Can't Deleted ");
        }

        static void testGetAllContact()
        {
            DataTable dataTable = new DataTable();
            dataTable =clsContacts.GetAllContact();
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row["ContactID"]}, {row["FirstName"]} {row["LastName"]}");
            }
        }

        static void isContactExist(int ID)
        {
            if (clsContacts.isContactExist(ID))
                Console.WriteLine("the Contact is Found");
            else
                Console.WriteLine("the contact is not Found");
        }

        // this is function to table Countrys in database
        static void testCountryFind(string Name)
        {
            clsCountry country = clsCountry.Find(Name);

            Console.WriteLine(country.CountryID);
            Console.WriteLine(country.Name);
        }
        static void isCountryExist(string  Name)
        {
            if(clsCountry.IsCountryExist(Name))
                { Console.WriteLine(    "Is found ["+Name+"]"); }
            else
                { Console.WriteLine("Not Found ["+Name+"]"); }
        }

        static void DeleteCountry(string Name)
        {
            if(!clsCountry.IsCountryExist(Name))
            {
                Console.WriteLine("Can't Deleted this Country due to Not Found.");
            }
            else
            {
                clsCountry.DeleteCountry(Name);
                Console.WriteLine("Deleted is Successfully ");
            }
        }




        static void Main(string[] args)
        {

            //testContactFind(10);
            // testContactAdd();
            // testContactDelete(1006);
            //testGetAllContact();
            //isContactExist(10);
            //testCountryFind("Uk");
            //isCountryExist("chaina");
            //DeleteCountry("china");
           

            Console.ReadKey();
        }
    }
}
