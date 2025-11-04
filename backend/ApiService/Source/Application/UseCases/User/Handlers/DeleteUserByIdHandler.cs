using CSharpFunctionalExtensions;
using Epam.ItMarathon.ApiService.Domain.Abstract;
using FluentValidation.Results;
using MediatR;
using UserEntity = Epam.ItMarathon.ApiService.Domain.Entities.User.User;
using Epam.ItMarathon.ApiService.Application.UseCases.User.Commands;

namespace Epam.ItMarathon.ApiService.Application.UseCases.User.Handlers
{
    /// <summary>
    /// Handler for deleting user by id.
    /// </summary>
    public class DeleteUserByIdHandler(IUserRepository userRepository) :
        IRequestHandler<DeleteUserByIdRequest, Result<UserEntity, ValidationResult>>
    {
        public async Task<Result<UserEntity, ValidationResult>> Handle(DeleteUserByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.UserId is null)
                return Result.Failure<UserEntity, ValidationResult>(
                    new ValidationResult([new FluentValidation.Results.ValidationFailure("UserId", "UserId cannot be null")])
                );

            var result = await userRepository.DeleteAsync(
                request.UserId.Value,
                cancellationToken,
                includeRoom: false,
                includeWishes: true
            );

            return result;
        }
    }
}
