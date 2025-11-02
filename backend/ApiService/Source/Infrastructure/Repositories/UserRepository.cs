using AutoMapper;
using CSharpFunctionalExtensions;
using Epam.ItMarathon.ApiService.Domain.Abstract;
using Epam.ItMarathon.ApiService.Domain.Entities.User;
using Epam.ItMarathon.ApiService.Domain.Shared.ValidationErrors;
using Epam.ItMarathon.ApiService.Infrastructure.Database;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ItMarathon.ApiService.Infrastructure.Repositories
{
    internal class UserRepository(AppDbContext context, IMapper mapper) : IUserRepository
    {
        public async Task<Result<User, ValidationResult>> DeleteAsync(ulong id, CancellationToken cancellationToken,
            bool includeRoom = false, bool includeWishes = false)
        {
            var userQuery = context.Users.AsQueryable();
            if (includeRoom)
            {
                userQuery = userQuery.Include(user => user.Room);
            }

            if (includeWishes)
            {
                userQuery = userQuery.Include(user => user.Wishes);
            }

            var userEf = await userQuery.FirstOrDefaultAsync(user => user.Id.Equals(id), cancellationToken);
            context.Users.Remove(userEf);
            await context.SaveChangesAsync();
            var result = userEf == null
                ? Result.Failure<User, ValidationResult>(new NotFoundError([
                    new ValidationFailure(nameof(id), "User with such id not found")
                ]))
                : mapper.Map<User>(userEf);
            return result;
        }
    }
}
