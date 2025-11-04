using System.Diagnostics;

namespace Lab0.Models;

public class OrganizationContactModel
{
    public Organization Organization { get; set; }
    public List<Contact> Contacts { get; set; }
}