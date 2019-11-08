using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using JustInTimeCompany_MuzikantovRoman.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MediatR;
using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Users.Commands.CreateUser;

namespace JustInTimeCompany_MuzikantovRoman.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly IMediator _mediator;

        public RegisterModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Le champ {0} est requis")]
            [EmailAddress(ErrorMessage ="Le format ne correspond pas à une adresse email.")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Le champ {0} est requis")]
            [StringLength(100, ErrorMessage = "Le {0} doit être composé d'au moins {2} et au plus {1} caractères.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Mot de passe")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Répétez votre mot de passe")]
            [Compare("Password", ErrorMessage = "Les mots de passe ne correspondent pas.")]
            public string ConfirmPassword { get; set; }
            
            [Required(ErrorMessage = "Le champ {0} est requis")]
            [Display(Name = "Prénom")]
            public string FirstName { get; set; }
            
            [Required(ErrorMessage = "Le champ {0} est requis")]
            [Display(Name = "Nom")]
            public string LastName { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            var result = await _mediator.Send(new CreateUserCommand(Input.FirstName, Input.LastName, Input.Email, Input.Password));

            if(result) {
                return LocalRedirect(returnUrl);
            }

            return Page();
        }
    }
}
