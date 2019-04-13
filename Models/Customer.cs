
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
        public string CompanyName { get; set; }
        [Required]
        //Nome fantasia - só deixei este como obrigatório pq as vezes o usuário não tem todos os dados        
        public string TradingName { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }        
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public Customer() { }

        public Customer(string id)
        {
            Id = id;
        }
    }
}
