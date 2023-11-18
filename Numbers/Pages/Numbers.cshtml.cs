using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Numbers.Models;

namespace Numbers.Pages
{
    
    public class NumbersModel : PageModel
    {
        public List<Contact> contacts = new List<Contact>();
        public void OnGet()
        {
            var c1 = new Contact()
            {
                Id = 1,
                Name = "���� ��������� ������",
                Phone = "8 (383) 346 04 92",
                Description = "������������� ����",
            };
            contacts.Add(c1);
            var c2 = new Contact()
            {
                Id = 2,
                Name = "����� �������",
                Phone = "+7-913-398-99-00",
                Description = "�������� � ������ � ����",
            };
            contacts.Add(c2);
            var c3 = new Contact()
            {
                Id = 3,
                Name = "�������",
                Phone = "123452",
                Description = "������� ������",
            };
            contacts.Add(c3);
            var c4 = new Contact()
            {
                Id = 4,
                Name = "����� �����",
                Phone = "+7(913)456-32-12",
                Description = "��������� �������",
            };
            contacts.Add(c4);
        }

    }

    
}
