using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjectLighthouse.Pages
{
    public class ContactModel : PageModel
    {
        private readonly ILogger<ContactModel> _logger;

        [BindProperty]
        public string Name { get; set; } = string.Empty;

        [BindProperty]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        public string Message { get; set; } = string.Empty;

        [TempData]
        public string? SuccessMessage { get; set; }

        public ContactModel(ILogger<ContactModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Log the contact form submission (not saving to database yet)
            _logger.LogInformation("Contact form submitted - Name: {Name}, Email: {Email}, Message: {Message}", 
                Name, Email, Message);

            // Set success message
            SuccessMessage = "🎉 Thank you for your message! We'll get back to you soon! 🎉";

            // Clear the form
            ModelState.Clear();
            Name = string.Empty;
            Email = string.Empty;
            Message = string.Empty;

            return RedirectToPage();
        }
    }
}
