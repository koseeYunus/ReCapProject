using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator: AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).Length(2);
            RuleFor(u => u.Email).Must(EndsWithMail).WithMessage("Lütfen bir mail adresi giriniz.");
        }

        private bool EndsWithMail(string arg)
        {
            return arg.EndsWith("@gmail.com") || arg.EndsWith("@hotmail.com");
        }
    }
}
