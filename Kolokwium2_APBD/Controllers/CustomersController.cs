using Kolokwium2_APBD.DTOs;
using Kolokwium2_APBD.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomersController(IDbService customersService) : ControllerBase
{
    [HttpGet("/api/[controller]/{customerId}/purchases")]
    public async Task<ActionResult<CustomerGetDto>> GetCustomerPurchases(int customerId)
    {
        try
        {
            return Ok(await customersService.GetCustomerPurchases(customerId));
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddCustomerWithPurchases(CustomerPostDto request)
    {
        try
        {
            await customersService.AddCustomerWithPurchases(request);
            return CreatedAtAction(nameof(GetCustomerPurchases), 
                new { customerId = request.Customer.Id }, null);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}