using Lab0.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab0.Controllers;

public class OrganizationController(AppDbContext context) : Controller
{
    // GET
    public IActionResult Index()
    {
        return View(context.Organizations.ToList());
    }

    [HttpGet]
    public IActionResult AddContactsToOrganization(int id)
    {
        return View(new OrganizationContactModel()
        {
            Organization = context.Organizations.Find(id),
            Contacts = context.Contacts.ToList()
        });
    }
    
    [HttpPost]
    public IActionResult AddContactsToOrganization(List<int> contactsId)
    {
        return View();
    }
    
}