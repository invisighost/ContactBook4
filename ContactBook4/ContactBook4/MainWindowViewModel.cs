using ContactBook4.DAL;
using ContactBook4.Model;
using System.Collections.ObjectModel;

namespace ContactBook4
{
	public class MainWindowViewModel : Observable
    {
# region INotify Properties
		private Contact selectedContact;

        public Contact SelectedContact
		{
			get { return selectedContact; }
			set 
			{ 
				selectedContact = value;
				OnPropertyChanged();
			}
		}
		#endregion

		ContactRepository _contactRepository;

		public ObservableCollection<Contact> Contacts { get; private set; }
		public MainWindowViewModel()
		{
			_contactRepository = new ContactRepository();
			Contacts = new ObservableCollection<Contact>();
			LoadContacts();
		}

		private void LoadContacts()
		{
			//var contacts = _contactRepository.LoadContacts();
			//foreach (var contact in contacts)
			//{
			//	Contacts.Add(contact);
			//}

			Contacts = _contactRepository.Contacts;
		}

		public void DeleteContact(Contact contact)
		{
			 _contactRepository.DeleteContact(contact);
		}

		public void AddContact()
		{
			Contact contact = new Contact() { FirstName = "New", LastName = "Contact" };
			_contactRepository.AddContact(contact);
		}

		public void SaveContact(Contact contact)
		{
			_contactRepository.SaveContact(contact);
		}

	}
}
