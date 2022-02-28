using System;
using FluentValidation;

namespace WebApi.BookOperations.GetBooksDetail
{
    public class GetBooksDetailValidator : AbstractValidator<GetBooksDetailQuery>
    {
      public GetBooksDetailValidator()
      {
          RuleFor(command => command.BookId).GreaterThan(0);
          
      }
         
    }
}