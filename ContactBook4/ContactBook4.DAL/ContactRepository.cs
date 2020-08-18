using ContactBook4.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace ContactBook4.DAL
{
    public class ContactRepository
    {
        //public List<Contact> Contacts;

        private List<Contact> contacts = new List<Contact>();

        public ObservableCollection<Contact> Contacts;

        private string contactFileName = "\\contacts.json";
        private string contactFile;

        public ContactRepository()
        {
            Contacts = new ObservableCollection<Contact>();
            LoadContacts();
        }

        //public List<Contact> LoadContacts()
        //{
        //    CheckForContactsFile();
        //    ReadJson();

        //    return Contacts;
        //}

        public ObservableCollection<Contact> LoadContacts()
        {
            CheckForContactsFile();
            ReadJson();

            return Contacts;
        }

        private void ReadJson()
        {
            using (var reader = File.OpenText(contactFile))
            {
                using (var jsonReader = new JsonTextReader(reader))
                {
                    var serializer = JsonSerializer.CreateDefault();
                    contacts = serializer.Deserialize<List<Contact>>(jsonReader);

                    foreach (var contact in contacts)
                    {
                        Contacts.Add(contact);
                    }
                }
            }
        }

        private void CheckForContactsFile()
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + contactFileName))
            {
                contactFile = Directory.GetCurrentDirectory() + contactFileName;
                GenerateDemoList();
            }

            contactFile = Directory.GetCurrentDirectory() + contactFileName;
        }

        private void GenerateDemoList()
        {
            var tempList = new List<Contact>()
            {
                new Contact {FirstName = "Michael", LastName = "Bishop",
                Address1 = "1225 Norris Rd", Address2 = "", Zipcode = "32514",
                City = "Pensacola", State = "FL", PhoneNo ="850-123-4567", Email = "Michael@email.com"},
                new Contact {FirstName = "Kaitlynn", LastName = "Bishop",
                Address1 = "1225 Norris Rd", Address2 = "", Zipcode = "32514",
                City = "Pensacola", State = "FL", PhoneNo = "251-123-4567", Email = "Kaitlynn@email.com"},
                new Contact {FirstName = "Binx", LastName = "Bishop",
                Address1 = "1970 Chuck Blvd", Address2 = "D19", Zipcode = "32514",
                City = "Pensacola", State = "FL", PhoneNo = "850-345-6789"}
            };

            var json = JsonConvert.SerializeObject(tempList, Formatting.Indented);
            File.WriteAllText(contactFile, json);
        }

        public void SaveContact(Contact contact)
        {
            SaveCurrentList();
        }

        private void SaveCurrentList()
        {
            var json = JsonConvert.SerializeObject(Contacts, Formatting.Indented);
            File.WriteAllText(contactFile, json);
            ReLoadContacts();
        }

        private void ReLoadContacts()
        {
            Contacts.Clear();
            LoadContacts();
        }

        public void DeleteContact(Contact contact)
        {
            Contacts.Remove(contact);
            SaveCurrentList();
        }

        public void AddContact(Contact contact)
        {
            Contacts.Add(contact);
            SaveCurrentList();
        }
    }
}
