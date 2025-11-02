using CSharpFunctionalExtensions;
using MediatR;
using System;
using CSharpFunctionalExtensions;
using FluentValidation.Results;
using MediatR;
using UserEntity = Epam.ItMarathon.ApiService.Domain.Entities.User.User;

namespace Epam.ItMarathon.ApiService.Application.UseCases.User.Commands
{
    /// <summary>
    /// Query for getting Users from Room.
    /// /// </summary>
    /// <param name="UserCode">User authorization code.</param>
    /// /// <param name="UserId">User's unique identifier.</param>
    public record DeleteUserByIdRequest : IRequest<Result<UserEntity, ValidationResult>>
    {
        public string UserCode { get; init; }
        public ulong? UserId { get; init; }
    };
}
