﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly BookContext _context;

    public BooksController(BookContext context)
    {
        _context = context;
    }

    // GET: api/Books
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetAll()
    {
        return await _context.Books
            .Where(b => !b.IsDeleted)
            .ToListAsync();
    }

    // GET: api/Books/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> Get(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null || book.IsDeleted) return NotFound();

        // Increment views count
        book.ViewsCount++;
        await _context.SaveChangesAsync();

        return book;
    }

    // POST: api/Books
    [HttpPost]
    public async Task<ActionResult<Book>> Create(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
    }

    // POST bulk: api/Books/bulk
    [HttpPost("bulk")]
    public async Task<IActionResult> CreateBulk(List<Book> books)
    {
        _context.Books.AddRange(books);
        await _context.SaveChangesAsync();
        return Ok("Bulk insert completed");
    }

    // PUT: api/Books/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Book updatedBook)
    {
        if (id != updatedBook.Id) return BadRequest("ID mismatch");

        var book = await _context.Books.FindAsync(id);
        if (book == null || book.IsDeleted) return NotFound();

        book.Title = updatedBook.Title;
        book.AuthorName = updatedBook.AuthorName;
        book.PublicationYear = updatedBook.PublicationYear;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE (soft delete): api/Books/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null || book.IsDeleted) return NotFound();

        book.IsDeleted = true;
        await _context.SaveChangesAsync();
        return NoContent();
    }
}