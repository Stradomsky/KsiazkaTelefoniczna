using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KsiazkaTelefoniczna
{
    class PhoneBook
    {
        public List<Contact> Contacts { get; set; } = new List<Contact>();


        public void AddContact(Contact contact)
        {
            var checkContact = Contacts.FirstOrDefault(c => c.Number == contact.Number);

            // if which checks if such a contact exists
            if (checkContact == null)
            {
                Contacts.Add(contact);
            }
            else
            {
                Console.WriteLine("This number is already in PhoneBook");
            }
        }

        public void DeleteContact(string number)
        {
            var contact = Contacts.FirstOrDefault(c => c.Number == number);

            Contacts.Remove(contact);
        }

        private void DisplayContactsDetails(List<Contact> contacts)
        {
            foreach (var contact in contacts)
            {
                DisplayContactDetails(contact);
            }
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found in PhoneBook");
            }
        }

        private void DisplayContactDetails(Contact contact)
        {
            Console.WriteLine($"Contact: {contact.Name}, {contact.Number}");
        }

        public void DisplayContact(string number)
        {
            var contact = Contacts.FirstOrDefault(c => c.Number == number);

            if (contact == null)
            {
                Console.WriteLine("Contact not found");
            }
            else
            {
                DisplayContactDetails(contact);
            }
        }
        public void DisplayAllContacts()
        {
            DisplayContactsDetails(Contacts);

        }

        public void DisplayMatchingContacts(string searchPhrase)
        {
            var matchingContacts = Contacts.Where(c => c.Name.Contains(searchPhrase)).ToList();
            DisplayContactsDetails(matchingContacts);
        }
    }
}