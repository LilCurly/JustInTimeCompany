using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Users.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<bool>
    {
        public LoginUserCommand(string mail, string password)
        {
            Mail = mail;
            Password = password;
        }

        public string Mail { get; }
        public string Password { get; }
    }
}
