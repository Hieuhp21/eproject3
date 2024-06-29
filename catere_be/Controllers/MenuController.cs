﻿using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using catere_be.Data;
using catere_be.Models;

[Route("api/[controller]")]
[ApiController]
public class MenuController : ControllerBase
{
    private readonly AppDbContext _context;

    public MenuController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Menu>>> GetMenu()
    {
        return await _context.Menu.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Menu>> GetMenu(int id)
    {
        var menu = await _context.Menu.FindAsync(id);

        if (menu == null)
        {
            return NotFound();
        }

        return menu;
    }

    [HttpPost]
    public async Task<ActionResult<Menu>> PostMenu(Menu menu)
    {
        _context.Menu.Add(menu);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetMenu", new { id = menu }, menu);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutMenu(int id, Menu menu)
    {
        if (id != menu.MenuItemId)
        {
            return BadRequest();
        }

        _context.Entry(menu).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MenuExists(id))
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
    public async Task<IActionResult> DeleteMenu(int id)
    {
        var menu = await _context.Menu.FindAsync(id);
        if (menu == null)
        {
            return NotFound();
        }

        _context.Menu.Remove(menu);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool MenuExists(int id)
    {
        return _context.Menu.Any(e => e.MenuItemId == id);
    }
}
