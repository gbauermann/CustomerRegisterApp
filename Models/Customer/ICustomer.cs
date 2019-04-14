
namespace Models
{
    public interface ICustomer: IMongoModel
    {
        string Address { get; set; }
        string CNPJ { get; set; }
        string CompanyName { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }
        string TradingName { get; set; }
    }
}