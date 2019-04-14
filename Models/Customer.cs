
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Customer : ICustomer
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        //Razão social
        [Required]
        public string CompanyName { get; set; }
        //Nome fantasia 
        [Required]              
        public string TradingName { get; set; }
        [Required]
        public string CNPJ { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }

        public Customer() { }

        public Customer(string id)
        {
            Id = id;
        }
    }
}
