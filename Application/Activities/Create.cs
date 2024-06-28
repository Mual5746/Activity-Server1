using Application.Core;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Create
    {
        //public class Command : IRequest
        //10
        public class Command : IRequest<Result<Unit>>
        {
            public Activity Aktivity { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Aktivity).SetValidator(new ActivityValidator());
            }
        }
        //public class Handler : IRequestHandler<Command>
        //10
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Activities.Add(request.Aktivity);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create activity");

                //return Unit.Value; //it's returning nothing, just to get ride of error for Handle
                //10
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
