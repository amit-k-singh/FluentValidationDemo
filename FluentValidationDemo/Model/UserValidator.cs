using FluentValidation;

namespace FluentValidationDemo.Model
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().Length(3,20).WithMessage("Enter valid Name. length will be with in 3 to 15");
            RuleFor(x => x.Address).NotEmpty().NotNull().Length(3,20).WithMessage("Enter valid Address. length will be with in 3 to 15");
            RuleFor(x => x.Email).EmailAddress().NotEmpty().Length(10,25).WithMessage("Enter valid EmailId");
            RuleFor(x => x.Phone.ToString()).NotNull().NotEmpty().Length(10);
            //RuleFor(x => x.DOB).NotEmpty().NotNull().Must(Date_Validate).WithMessage("date shout year=2023, month= 1 or 2, date= 10 to 15");
            RuleFor(x => x.DOB).NotEmpty().NotNull().ExclusiveBetween(new DateTime(2022, 02, 21), new DateTime(2023, 02, 21));//.WithMessage("Enter date between 21/02/2022 to 21/02/2023");
        }

        private bool Date_Validate(DateTime dob)
        {
            DateTime couuent = dob;
            var year = couuent.Year;
            var month = couuent.Month;
            var day = couuent.Day;

            if(year == 2023)
            {
                if(month >= 1 && month <= 2) 
                {
                    if(day>= 10 && day <=15)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
