using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Numbers.Models;

namespace Numbers.Pages
{
    public class Master3Model : PageModel
    {
        public List<Contact> blackList = new List<Contact>();
        public void OnGet()
        {
            var c1 = new Contact()
            {
                Id = 1,
                Name = "Черный мальчик",
                Phone = "+68 932 123 22",
                Description = "Мошенники",
            };
            var c2 = new Contact()
            {
                Id = 1,
                Name = "Central Cee",
                Phone = "+44 00 123 3434 123",
                Description = "Uk chel",
            };

            blackList.Add(c1);
            blackList.Add(c2);
        }
    }
}
