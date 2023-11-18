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
                Name = "Илья Сергеевич Дубков",
                Phone = "8 (383) 346 04 92",
                Description = "Преподаватель НГТУ",
            };
            contacts.Add(c1);
            var c2 = new Contact()
            {
                Id = 2,
                Name = "Серёга Овчаров",
                Phone = "+7-913-398-99-00",
                Description = "Продавец в ларьке у дома",
            };
            contacts.Add(c2);
            var c3 = new Contact()
            {
                Id = 3,
                Name = "Людочка",
                Phone = "123452",
                Description = "Соседка сверху",
            };
            contacts.Add(c3);
            var c4 = new Contact()
            {
                Id = 4,
                Name = "Сосед слева",
                Phone = "+7(913)456-32-12",
                Description = "ПОстоянно сверлит",
            };
            contacts.Add(c4);
        }

    }

    
}
