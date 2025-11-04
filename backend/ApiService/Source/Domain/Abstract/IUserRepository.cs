using CSharpFunctionalExtensions;
using Epam.ItMarathon.ApiService.Domain.Entities.User;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Epam.ItMarathon.ApiService.Domain.Abstract
{

    public interface IUserRepository
    {
        /// <summary>
        /// Delete user by id.
        /// </summary>
        /// <param name="id">Unique User's unique identifier.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/> that can be used to cancel operation.</param>
        /// <param name="includeRoom">Include dependent Room to response.</param>
        /// <param name="includeWishes">Include list of dependent wishes to response.</param>
        /// <returns>Returns <see cref="User"/> if found, otherwise <see cref="ValidationResult"/></returns>
        public Task<Result<User, ValidationResult>> DeleteAsync(ulong id, CancellationToken cancellationToken,
            bool includeRoom = false, bool includeWishes = false);
    }
}
