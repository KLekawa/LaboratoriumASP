using Lab0.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab0.Controllers;

public class PhotoController : Controller
{
    private static Dictionary<int, PhotoModel> _photos = new()
    {
        {1, new PhotoModel
        {
            Id = 1,
            Date = new DateTime(1111, 11, 11, 11, 11, 11),
            Description = "Opis1",
            Camera = "Sony1",
            Author = "Adam1",
            Resolution = "1080p",
            Format = ".png"
        }},
        {2, new PhotoModel
        {
            Id = 2,
            Date = new DateTime(2222, 12, 22, 22, 22, 22),
            Camera = "Canon2",
            Author = "Ewa2",
            Resolution = "720p",
            Format = ".jpg"
        }}
    };
    private static int _id = 2;
    public IActionResult Index()
    {
        return View(_photos);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(PhotoModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        model.Id = ++_id;
        _photos.Add(model.Id, model);
        return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
        if (_photos.ContainsKey(id))
        {
            return View(_photos[id]);
        }

        return NotFound();
    }
    
    public IActionResult Delete(int id)
    {
        if (_photos.ContainsKey(id))
        {
            _photos.Remove(id);
            return RedirectToAction("Index");

        }

        return NotFound();
    }
    
    public IActionResult ConfirmDelete(int id)
    {
        if (_photos.ContainsKey(id))
        {
            return View(_photos[id]);
        }

        return NotFound();
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        if (_photos.ContainsKey(id))
        {
            return View(_photos[id]);
        }

        return NotFound();
    }
    
    [HttpPost]
    public IActionResult Edit(PhotoModel model)
    {

        if (!ModelState.IsValid)
        {
            return View(model);
        }
        
        _photos[model.Id] = model;


        return RedirectToAction("Index");
    }
}