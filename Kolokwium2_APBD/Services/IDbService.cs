using Kolokwium2_APBD.DTOs;

namespace Kolokwium2_APBD.Services;

public interface IDbService
{
    Task<CustomerGetDto> GetCustomerPurchases(int customerId);
    Task AddCustomerWithPurchases(CustomerPostDto request);
}