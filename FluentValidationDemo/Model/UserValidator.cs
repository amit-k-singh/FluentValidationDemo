using FluentValidation;

namespace FluentValidationDemo.Model
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().Length(3,15).WithMessage("Enter valid Name. length will be with in 3 to 15");
            RuleFor(x => x.Address).NotEmpty().NotNull().Length(3,15).WithMessage("Enter valid Address. length will be with in 3 to 15");
            RuleFor(x => x.Email).EmailAddress().NotEmpty().Length(10,25).WithMessage("Enter valid EmailId");
            RuleFor(x => x.Phone.ToString()).NotNull().NotEmpty().Length(10);
        }
    }
}
