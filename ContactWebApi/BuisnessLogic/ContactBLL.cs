using ContactWebApi.DatabaseContext;
using ContactWebApi.DataModal;

namespace ContactWebApi.BuisnessLogic
{
    public class ContactBLL
    {
        public static bool _isCalled = false;
        
        public void addContacts(ContactDatabaseContext _dbContext)
        {
            if (!_isCalled) 
            {

                addToDefaultContactList(new ContactModal { contactName = "Joseph", contactNumber = "8515848421", location = "Chennai" }, _dbContext);
                addToDefaultContactList(new ContactModal { contactName = "Hari", contactNumber = "9812848421", location = "Dubai" }, _dbContext);
                addToDefaultContactList(new ContactModal { contactName = "Vijay", contactNumber = "9715848421", location = "Banglore" }, _dbContext);
                addToDefaultContactList(new ContactModal { contactName = "Vishwa", contactNumber = "8517568721", location = "Mysore" }, _dbContext);
                addToDefaultContactList(new ContactModal { contactName = "Karthick", contactNumber = "9265848421", location = "Chennai" }, _dbContext);
                addToDefaultContactList(new ContactModal { contactName = "Maxwell", contactNumber = "7259848421", location = "Mumbai" }, _dbContext);
                addToDefaultContactList(new ContactModal { contactName = "Jadeja", contactNumber = "8547848421", location = "Banglore" }, _dbContext);
                addToDefaultContactList(new ContactModal { contactName = "Dennis", contactNumber = "8515844777", location = "Mumbai" }, _dbContext);
                addToDefaultContactList(new ContactModal { contactName = "Linga", contactNumber = "7585848421", location = "Banglore" }, _dbContext);
                addToDefaultContactList(new ContactModal { contactName = "Samuel", contactNumber = "8522228421", location = "Banglore" }, _dbContext);
                _isCalled = true;
            }
        }

        public void addToDefaultContactList(ContactModal contactObj, ContactDatabaseContext _dbContext)
        {
            ContactDataModal contact = new ContactDataModal();
            contact.Id = Guid.NewGuid();
            contact.contactName = contactObj.contactName;
            contact.contactNumber = contactObj.contactNumber;
            contact.location = contactObj.location;

            _dbContext.Contacts.Add(contact);
            _dbContext.SaveChanges();
        }

    }
}
