using System.ComponentModel.DataAnnotations;

namespace webapp_travel_agency.Models
{
    public class Message
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Il campo nome è obbligatorio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Il campo cognome è obbligatorio")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Il campo mail è obbligatorio")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Il campo messaggio è obbligatorio")]
        public string Text { get; set; }
        public int? TravelPackageId { get; set; }
        public TravelPackage? TravelPackage { get; set; }

        public Message()
        {

        }
    }
}
