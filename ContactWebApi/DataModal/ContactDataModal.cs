
using System.ComponentModel.DataAnnotations;

namespace ContactWebApi.DataModal
{
    public class ContactDataModal
    {
        [Key]
        public Guid Id { get; set; }
        public string contactName { get; set; }
        public string contactNumber { get; set; }
        public string location { get; set; }
    }

    public class ContactModal
    {
        public string contactName { get; set; }
        public string contactNumber { get; set; }
        public string location { get; set; }
    }
}
