using AvDennison.API.Contract.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvDennison.API.Validators
{
    public class InsertArticleRequestValidator: AbstractValidator<ArticleInsertRequest>
    {
        public InsertArticleRequestValidator()
        {
            RuleFor(x => x.ArticleNumber)
                .NotEmpty()
                .MaximumLength(30)
                .Matches("^[a-zA-Z0-9 ]*$");

            RuleFor(x => x.SalesPrice)
               .NotEmpty()
               .GreaterThan(0);
        }
    }
}
