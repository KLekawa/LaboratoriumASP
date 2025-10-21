using Lab0.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab0.Controllers;

public class ContactController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
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
            //zapamiętanie nowego kontaktu
            return RedirectToAction("Index");
        }

        return View(contact);
    }
}