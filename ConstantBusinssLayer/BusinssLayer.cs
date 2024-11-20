using System;
using System.Data;
using ContactsDataAccessLayer;

namespace ConstantBusinssLayer
{
    public class clsContacts
    {
        public int ContacID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public int CountryID { get; set; }
        public string ImagePath { get; set; }
        public DateTime DateOfBirth { get; set; }
        enum enMode { AddNew=1, Update=2 };
        enMode Mode = enMode.Update;

       
       public  clsContacts()
        {
            this.ContacID = 0;
            this.FirstName = "";
            this.FirstName = "";
            this.LastName = "";
            this.Email = "";
            this.Phone = "";
            this.Adress = "";
            this.CountryID = -1;
            this.ImagePath = "";
            this.DateOfBirth = DateTime.MinValue;
            this.Mode= enMode.AddNew;
        }
     
       private clsContacts(string firstName, string lastName, string email, string phone, string adress, int countryID, string imagePath, DateTime dateOfBirth)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Phone = phone;
            this.Adress = adress;
            this.CountryID = countryID;
            this.ImagePath = imagePath;
            this.DateOfBirth = dateOfBirth;
            this.Mode = enMode.Update;

        }
       
        static public clsContacts Find(int ID)
        {
            string FirstName = "", LastName = "", Email = "", Phone = "", Adress = "", ImagePath = "";
            int CountryID = -1;
            DateTime dateOfBirth = DateTime.Now;
            if (DataAccessLayer.GetContactsData(ID,ref FirstName,ref LastName,ref Email,ref Phone,ref Adress,ref ImagePath,ref CountryID,ref dateOfBirth))
            {
                return new clsContacts(FirstName,LastName,Email,Phone,Adress,CountryID,ImagePath,dateOfBirth);
            }
            
         else
            {
            return null; 
            }
        }

         private bool _AddNewContact()
        {
            this.ContacID =DataAccessLayer.AddNewContact(FirstName,LastName,Email,Phone,Adress,ImagePath,CountryID,DateOfBirth);


            return (this.ContacID!=-1);
        }

         public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if(_AddNewContact())
                    {
                        Mode = enMode.Update;
                        return true;

                    }
                    else
                    {
                        return false;
                    }
                    case enMode.Update:
                    return true;
            }
            return false;
        }

        static public bool Delete(int ID)
        {
            return DataAccessLayer.DeleteContact(ID);
        }

        static public DataTable GetAllContact() {
            return DataAccessLayer.GetAllContact(); 
        }

        static public bool isContactExist(int ID)
        {
            return DataAccessLayer.isContactExist(ID);
        }
    }
}
