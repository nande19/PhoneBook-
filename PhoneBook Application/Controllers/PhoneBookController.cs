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
        public async Task<IActionResult> Table(string searchQuery)
        {
            // Store the search query in ViewData so it can be reflected in the search bar
            ViewData["SearchQuery"] = searchQuery;

            // Retrieve the contacts based on search query
            var contacts = string.IsNullOrWhiteSpace(searchQuery)
                ? await db_Context.Peoples.ToListAsync()  // Return all contacts if no query
                : await db_Context.Peoples
                                   .Where(p => (p.Name.Contains(searchQuery) || p.PhoneNumber.Contains(searchQuery)))
                                   .ToListAsync(); // Filter by name or phone number

            return View(contacts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddContactViewModel addContactViewModel)
        {
            // Check if the phone number has only the default +27 (i.e., no numbers other than +27)
            if (string.IsNullOrWhiteSpace(addContactViewModel.PhoneNumber) || addContactViewModel.PhoneNumber == "+27")
            {
                ModelState.AddModelError("PhoneNumber", "Please enter a valid phone number, excluding the default '+27' prefix.");
            }

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

        [HttpPost]
        public IActionResult AddContact(People contact)
        {
            if (ModelState.IsValid)
            {
                // Save the contact to the database
                db_Context.Peoples.Add(contact);
                db_Context.SaveChanges();
                return RedirectToAction("Index"); // or any other appropriate redirect
            }

            return View(contact); // If validation fails, return the same view with the errors
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
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var person = await db_Context.Peoples.FindAsync(viewModel.Id);
            if (person is not null)
            {
                person.Name = viewModel.Name;
                person.PhoneNumber = viewModel.PhoneNumber;
                person.Email = viewModel.Email;

                await db_Context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Contact updated successfully!";
                return RedirectToAction("Table", "PhoneBook");
            }

            ModelState.AddModelError(string.Empty, "Contact not found.");
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var person = await db_Context.Peoples.FindAsync(id);

            if (person != null)
            {
                db_Context.Peoples.Remove(person);
                await db_Context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Contact deleted successfully!";
            }
            else
            {
                TempData["ErrorMessage"] = "Contact not found.";
            }

            return RedirectToAction("Table", "PhoneBook");
        }

        
    }
}