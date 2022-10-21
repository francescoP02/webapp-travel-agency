using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webapp_travel_agency.Validation;

namespace webapp_travel_agency.Models
{
    public class TravelPackage
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Il campo nome è obbligatorio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Il campo foto è obbligatorio")]
        public string Photo { get; set; }
        [Required(ErrorMessage = "Il campo descrizione è obbligatorio")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Il campo durata è obbligatorio")]
        public int Duration { get; set; }
        [Required(ErrorMessage = "Il campo numero di persone è obbligatorio")]
        public int PeopleNumber { get; set; }
        [Required(ErrorMessage = "Il campo prezzo è obbligatorio")]
        [NegativeOrZero]
        public int Price { get; set; }

        public List<Message> messages { get; set; }
        public TravelPackage()
        {

        }

        public TravelPackage(int id, string name, string photo, string description, int duration, int peopleNumber, int price)
        {
            Id = id;
            Name = name;
            Photo = photo;
            Description = description;
            Duration = duration;
            PeopleNumber = peopleNumber;
            Price = price;
        }
    }
}
