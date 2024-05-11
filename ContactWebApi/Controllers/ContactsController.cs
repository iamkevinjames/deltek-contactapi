using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ContactWebApi.DatabaseContext;
using ContactWebApi.DataModal;
using ContactWebApi.BuisnessLogic;

namespace ContactWebApi.Controllers
{
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactDatabaseContext _dbContext;

        ContactBLL contactBll = new ContactBLL();

        public ContactsController(ContactDatabaseContext dbContext)
        {
            contactBll.addContacts(dbContext);
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("getContactsList")]
        public async Task<IActionResult> GetContactsList()
        {
            return Ok( _dbContext.Contacts.ToList() );
        }

        [HttpPost]
        [Route("addContact")]
        public async Task<IActionResult> AddContact(ContactModal contactObj)
        {
            ContactDataModal contact = new ContactDataModal();
            contact.Id = Guid.NewGuid();
            contact.contactName = contactObj.contactName;
            contact.contactNumber = contactObj.contactNumber;
            contact.location = contactObj.location;

            _dbContext.Contacts.Add(contact);
            _dbContext.SaveChanges();   

            return Ok(_dbContext.Contacts.ToList());
        }

        [HttpPut]
        [Route("updateContact")]
        public async Task<IActionResult> updateContact(ContactDataModal contactObj)
        {
            var contact = _dbContext.Contacts.Where(contact => contact.Id == contactObj.Id).FirstOrDefault<ContactDataModal>();
            
            if(contact != null)
            {
                contact.contactName = contactObj.contactName;
                contact.contactNumber = contactObj.contactNumber;
                contact.location = contactObj.location;
                
            }
            _dbContext.SaveChanges();

            return Ok(_dbContext.Contacts.ToList());
        }
            
        [HttpDelete]
        [Route("deleteContact")]
        public async Task<IActionResult> deleteContact(Guid id)
        {
            var contact = _dbContext.Contacts.Where(contact => contact.Id == id).FirstOrDefault<ContactDataModal>();
            _dbContext.Contacts.Remove(contact);
            _dbContext.SaveChanges();
            return Ok(_dbContext.Contacts.ToList());
        }
    }
}
