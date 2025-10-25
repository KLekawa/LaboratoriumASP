using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Lab0.Models;

public class PhotoModel
{
    [HiddenInput]
    public int Id { get; set; }
    
    
    [Required(ErrorMessage = "Pole jest wymagane")]
    [Display(Name = "Data wykonania*: ")]
    public DateTime Date { get; set; }
    
    
    [StringLength(500, ErrorMessage = "Opis może mieć maksymalnie 500 znaków")]
    [Display(Name = "Opis: ")]
    public string? Description { get; set; }
    
    
    [Required(ErrorMessage = "Pole jest wymagane")]
    [StringLength(100, ErrorMessage = "Model aparatu może mieć maksymalnie 100 znaków")]
    [Display(Name = "Model aparatu*: ")]
    public string Camera { get; set; }
    
    
    [Required(ErrorMessage = "Pole jest wymagane")]
    [StringLength(100, ErrorMessage = "Autor może mieć maksymalnie 100 znaków")]
    [Display(Name = "Autor*: ")]
    public string Author { get; set; }
    
    
    [StringLength(20, ErrorMessage = "Rozdzielczość może mieć maksymalnie 20 znaków")]
    [Display(Name = "Rozdzielczość: ")]
    public string? Resolution { get; set; }
    
    
    [StringLength(10, ErrorMessage = "Format może mieć maksymalnie 100 znaków")]
    [Display(Name = "Format: ")]
    public string? Format { get; set; }
}