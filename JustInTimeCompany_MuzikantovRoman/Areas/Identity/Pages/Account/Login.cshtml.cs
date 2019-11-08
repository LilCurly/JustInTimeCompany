using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using JustInTimeCompany_MuzikantovRoman.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MediatR;
using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Users.Commands.LoginUser;

namespace JustInTimeCompany_MuzikantovRoman.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly IMediator _mediator;

        public LoginModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Le champ {0} est requis")]
            [EmailAddress(ErrorMessage = "Le format ne correspond pas à une adresse email.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Le champ {0} est requis")]
            [DataType(DataType.Password)]
            [Display(Name = "Mot de passe")]
            public string Password { get; set; }

            [Display(Name = "Se rappeler de moi ?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            var result = await _mediator.Send(new LoginUserCommand(Input.Email, Input.Password));

            if(result)
            {
                return LocalRedirect(returnUrl);
            }

            return Page();
        }
    }
}
