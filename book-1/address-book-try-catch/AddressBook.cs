using System;
using System.Collections.Generic;

namespace address_book_try_catch
{
    class AddressBook
    {

        public Dictionary<string, Contact> contactList { get; set; } = new Dictionary<string, Contact>();

        public void AddContact(Contact contactParam)
        {
            try
            {
                contactList.Add(contactParam.Email, contactParam);

            }
            catch (ArgumentException)
            {
                Console.WriteLine($"{contactParam.FirstName} has already been added to the address book");

            }

        }

        public Contact GetByEmail(string emailParam)
        {

            return contactList[emailParam];
        }

    }

}
