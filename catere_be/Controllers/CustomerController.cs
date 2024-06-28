using Microsoft.AspNetCore.Mvc;
using catere_be.Data;
using catere_be.Models;
using Microsoft.EntityFrameworkCore;
using catere_be.Dto;


[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly AppDbContext _context;

    public CustomerController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
    {
        return await _context.Customer.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> GetCustomer(int id)
    {
        var customer = await _context.Customer.FindAsync(id);

        if (customer == null)
        {
            return NotFound();
        }

        return customer;
    }

    [HttpPost]
    public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
    {
        // Hash mật khẩu của người dùng
        customer.PasswordHash = catere_be.Hash.PasswordHasher.HashPassword(customer.PasswordHash);

        // Thêm người dùng vào cơ sở dữ liệu
        var customerEntity = new Customer
        {
            FirstName = customer.FirstName,
            MiddleName = customer.MiddleName,
            LastName = customer.LastName,
            Gender = customer.Gender,
            DateOfBirth = customer.DateOfBirth,
            PhoneNumber = customer.PhoneNumber,
            Email = customer.Email,
            Address = customer.Address,
            ImageUrl = customer.ImageUrl,
            CustomerType = customer.CustomerType,
            LoginName = customer.LoginName,
            PasswordHash = customer.PasswordHash,
            IsActive= customer.IsActive
        };

        _context.Customer.Add(customerEntity);
        await _context.SaveChangesAsync();

        customer.CustomerId = customerEntity.CustomerId;

        return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> PutCustomer(int id, Customer customer)
    {
        if (id != customer.CustomerId)
        {
            return BadRequest();
        }

        _context.Entry(customer).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CustomerExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        var customer = await _context.Customer.FindAsync(id);
        if (customer == null)
        {
            return NotFound();
        }

        _context.Customer.Remove(customer);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CustomerExists(int id)
    {
        return _context.Customer.Any(e => e.CustomerId == id);
    }
}
