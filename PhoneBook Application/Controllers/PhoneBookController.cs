using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneBook_Application.Models;
using PhoneBook_Application.Models.Entities;
using PhoneBook_Application.PhoneData;

namespace PhoneBook_Application.Controllers
{
    public class PhoneBookController : Controller
    {
        private readonly ApplicationDbContext db_Context;
        public PhoneBookController(ApplicationDbContext dbContext)
        {
            this.db_Context = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddContactViewModel addContactViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(addContactViewModel); // Return the same view with validation errors.
            }

            try
            {
                var person = new People
                {
                    Id = Guid.NewGuid(),
                    Name = addContactViewModel.Name,
                    PhoneNumber = addContactViewModel.PhoneNumber,
                    Email = addContactViewModel.Email
                };

                db_Context.Peoples.Add(person);
                await db_Context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Contact saved successfully!";
                return RedirectToAction("Table"); // Redirect to another page or reload the form.
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while saving the contact. Please try again.");
                // Optionally log the exception here.
                return View(addContactViewModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Table()
        {
            var person = await db_Context.Peoples.ToListAsync();

            return View(person);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var person = await db_Context.Peoples.FindAsync(id);

            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(People viewModel)
        {
            var person = await db_Context.Peoples.FindAsync(viewModel.Id);

            if (person is not null)
            {
                person.Name = viewModel.Name;
                person.Email = viewModel.Email;
                person.PhoneNumber = viewModel.PhoneNumber;

                await db_Context.SaveChangesAsync();
            }

            return RedirectToAction("Table", "People");
        }
    }
}