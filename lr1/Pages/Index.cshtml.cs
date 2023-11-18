using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lr1.Pages
{
    public class Index1Model : PageModel
    {
        public List<int> Array { get; set; } = new List<int>();

        [BindProperty]
        public int Sum { get; set; } = 0;
        private readonly ILogger<Index1Model> _logger;

        public Index1Model(ILogger<Index1Model> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public void OnPost(string numbers)
        {
            var parsedNumbers = numbers.Split(" ");
            _logger.Log(LogLevel.Information, numbers);
            int sum = 0;
            for (int i = 0; i < parsedNumbers.Length; i++)
            {
                int x = Int32.Parse(parsedNumbers[i]);
                sum += x;
            }
            Sum = sum;
        }
    }
}
