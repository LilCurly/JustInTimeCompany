using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<bool>
    {
        public CreateUserCommand(string firstName, string lastName, string mail, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Mail = mail;
            Password = password;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string Mail { get; }
        public string Password { get; }
    }
}
