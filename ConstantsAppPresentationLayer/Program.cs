using ConstantBusinssLayer;
using System;


namespace ConstantsAppPresentationLayer
{
    internal class Program
    {
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
        
        static void Main(string[] args)
        {

            //  testContactFind(1008);
           // testContactAdd();
            Console.ReadKey();
        }
    }
}
