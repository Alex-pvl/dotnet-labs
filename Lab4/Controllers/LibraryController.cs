using Lab4.Models;
using Lab4.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Serialization;

namespace Lab4.Controllers
{
    public class LibraryController : Controller
    {
        private readonly Repository repository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public LibraryController(Repository repository, IWebHostEnvironment webHostEnvironment)
        {
            this.repository = repository;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var books = repository.Books.ToList();
            return View(books);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddBookViewModel addBookRequest)
        {
            var book = new Book()
            {
                Title = addBookRequest.Title,
                Author = addBookRequest.Author,
                Description = addBookRequest.Description,
                Count = addBookRequest.Count,
            };

            repository.Books.Add(book);
            repository.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult View(int id)
        {
            var book = repository.Books.FirstOrDefault(x => x.Id == id);

            if (book != null)
            {
                var viewModel = new UpdateBookViewModel()
                {
                    Title = book.Title,
                    Author = book.Author,
                    Description = book.Description,
                    Count = book.Count,
                };

                repository.SaveChanges();

                return View("View", viewModel);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult View(UpdateBookViewModel updateBookRequest)
        {
            var book = repository.Books.Find(updateBookRequest.Id);

            if (book != null)
            {
                book.Title = updateBookRequest.Title;
                book.Author = updateBookRequest.Author;
                book.Description = updateBookRequest.Description;
                book.Count = updateBookRequest.Count;

                repository.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(UpdateBookViewModel updateBookRequest)
        {
            var book = repository.Books.Find(updateBookRequest.Id);

            if (book != null)
            {
                repository.Books.Remove(book);
                repository.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult SaveAsXml()
        {
            var books = repository.Books.ToList();

            if (books.Count > 0)
            {
                var serializer = new XmlSerializer(typeof(List<Book>));
                var path = Path.Combine(Directory.GetCurrentDirectory(), "books.xml");

                using (var stream = new StreamWriter(path))
                {
                    serializer.Serialize(stream, books);
                }

                byte[] fileBytes = System.IO.File.ReadAllBytes(path);
                return File(fileBytes, "application/xml", "books.xml");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteAllBooks()
        {
            repository.Books.RemoveRange(repository.Books);
            repository.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UploadFromXml(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                try
                {
                    var tempPath = Path.GetTempFileName();

                    using (var stream = new FileStream(tempPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    var serializer = new XmlSerializer(typeof(List<Book>));

                    using (var stream = new StreamReader(tempPath))
                    {
                        var books = (List<Book>)serializer.Deserialize(stream);

                        if (books != null && books.Count > 0)
                        {
                            repository.Books.AddRange(books);
                            repository.SaveChanges();
                        }
                    }

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
    }
}
