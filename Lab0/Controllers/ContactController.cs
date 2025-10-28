using System.Collections.Immutable;
using Lab0.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab0.Controllers;

public class ContactController : Controller
{
    private static Dictionary<int, Contact> _contacts = new()
    {
        {
            1, new Contact()
            {
                Id = 1,
                Name = "Adam",
                Email = "ad@mail.com",
                BirthDate = new DateOnly(2000, 12, 1)
            }
        },
        {
            2, new Contact()
            {
                Id = 2,
                Name = "marek",
                Email = "marek@marek.pl",
                BirthDate = DateOnly.FromDateTime(new DateTime(1980, 1, 27))
            }
        }
    };

    private static int i = 2;
    // GET
    public IActionResult Index()
    {
        return View(_contacts.Values.ToList());
    }

    [HttpGet] // formularz
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost] // odbiór danych z formularza
    public IActionResult Create(Contact contact)
    {
        if (ModelState.IsValid)
        {
            contact.Id = ++i;
            _contacts.Add(contact.Id, contact);
            return RedirectToAction("Index");
        }

        return View(contact);
    }

    public IActionResult Details(int id)
    {
        if (_contacts.ContainsKey(id))
        {
        return View(_contacts[id]);
        }
        else
        {
            return NotFound();
        }
    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        if (_contacts.ContainsKey(id))
        {
            return View(_contacts[id]);
        }

        return NotFound();
    }
    
    [HttpPost]
    public IActionResult Edit(Contact model)
    {

        if (!ModelState.IsValid)
        {
            return View(model);
        }
        
        _contacts[model.Id] = model;
        
        return RedirectToAction("Index");
    }
}