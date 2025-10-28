using Lab0.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab0.Controllers;

public class ContactController : Controller
{
    private IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    // GET
    public IActionResult Index()
    {
        return View(_contactService.GetContacts());
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
            _contactService.CreateContact(contact);
            return RedirectToAction("Index");
        }

        return View(contact);
    }

    public IActionResult Details(int id)
    {
        var contact = _contactService.GetContactById(id);
        if (contact is not null)
        {
            return View(contact);
        }
        
        return NotFound();

    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var contact = _contactService.GetContactById(id);
        if (contact is not null)
        {
            return View(contact);
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

        _contactService.UpdateContact(model);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var contact = _contactService.GetContactById(id);
        if (contact is not null)
        {
            return View(contact);
        }

        return NotFound();
    }

    [HttpPost]
    public IActionResult Delete(Contact contact)
    {
        var succes = _contactService.DeleteContactById(contact.Id);

        if (succes)
        {
            return RedirectToAction("Index");
        }
        else
        {
            return BadRequest();
        }
        
    }
}