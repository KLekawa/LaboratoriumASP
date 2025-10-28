namespace Lab0.Models;

public class ContactServiceInMemory : IContactService
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
    
    private static int _i = 2;
    public List<Contact> GetContacts()
    {
        return _contacts.Values.ToList();
    }

    public Contact? GetContactById(int id)
    {
        if (_contacts.ContainsKey(id))
        {
            return _contacts[id];
        }

        return null;
    }

    public void CreateContact(Contact contact)
    {
        contact.Id = ++_i;
        _contacts.Add(contact.Id, contact);
    }

    public bool UpdateContact(Contact contact)
    {
        if (_contacts.ContainsKey(contact.Id))
        {
            _contacts[contact.Id] = contact;
            return true;
        }

        return false;
    }

    public bool DeleteContactById(int id)
    {
        if (_contacts.ContainsKey(id))
        {
            _contacts.Remove(id);
            return true;
        }

        return false;
    }
}