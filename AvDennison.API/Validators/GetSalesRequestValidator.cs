using AvDennison.API.Contract.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvDennison.API.Validators
{
    public class GetSalesRequestValidator: AbstractValidator<GetSalesPerDayRequest>
    {
        public GetSalesRequestValidator()
        {
            RuleFor(m => m.dateFrom)
                .NotEmpty()
                .WithMessage("Start Date is Required");

            RuleFor(m => m.dateTo)
                .NotEmpty().WithMessage("End date is required")
                .GreaterThanOrEqualTo(m => m.dateFrom)
                                .WithMessage("End date must after Start date");
        }
    }
}
