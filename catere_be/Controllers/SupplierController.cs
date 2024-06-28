using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using catere_be.Data;
using catere_be.Models;

[Route("api/[controller]")]
[ApiController]
public class SupplierController : ControllerBase
{
    private readonly AppDbContext _context;

    public SupplierController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliers()
    {
        return await _context.Supplier.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Supplier>> GetSupplier(int id)
    {
        var supplier = await _context.Supplier.FindAsync(id);

        if (supplier == null)
        {
            return NotFound();
        }

        return supplier;
    }

    [HttpPost]
    public async Task<ActionResult<Supplier>> PostSupplier(Supplier Supplier)
    {
        // Hash mật khẩu của người dùng
        Supplier.PasswordHash = catere_be.Hash.PasswordHasher.HashPassword(Supplier.PasswordHash);

        // Thêm người dùng vào cơ sở dữ liệu
        var SupplierEntity = new Supplier
        {
            Name = Supplier.Name,
         
            
            PhoneNumber = Supplier.PhoneNumber,
            Email = Supplier.Email,
            Address = Supplier.Address,
            ImageUrl = Supplier.ImageUrl,
            Level = Supplier.Level,
            LoginName = Supplier.LoginName,
            PasswordHash = Supplier.PasswordHash,
            IsActive = Supplier.IsActive
        };

        _context.Supplier.Add(SupplierEntity);
        await _context.SaveChangesAsync();

        Supplier.SupplierId = SupplierEntity.SupplierId;

        return CreatedAtAction("GetSupplier", new { id = Supplier.SupplierId }, Supplier);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutSupplier(int id, Supplier supplier)
    {
        if (id != supplier.SupplierId)
        {
            return BadRequest();
        }

        _context.Entry(supplier).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!SupplierExists(id))
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
    public async Task<IActionResult> DeleteSupplier(int id)
    {
        var supplier = await _context.Supplier.FindAsync(id);
        if (supplier == null)
        {
            return NotFound();
        }

        _context.Supplier.Remove(supplier);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool SupplierExists(int id)
    {
        return _context.Supplier.Any(e => e.SupplierId == id);
    }
}


