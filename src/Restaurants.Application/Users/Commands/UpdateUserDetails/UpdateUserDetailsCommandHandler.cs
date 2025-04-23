using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Restaurants.Application.Users.Commands.UpdateUserDetails
{
 public class UpdateUserDetailsCommandHandler(ILogger<UpdateUserDetailsCommandHandler> _logger,
    IUserContext _userContext,
    IUserStore<User> _userStore) : IRequestHandler<UpdateUserDetailsCommand>
    {
       

        public async Task Handle(UpdateUserDetailsCommand request, CancellationToken cancellationToken)
        {
            var User = _userContext.GetCurrentUser();

            _logger.LogInformation("Updateing user :{UserId}, with{@Request}", User!.Id, request);
                
            var dbUser = await _userStore.FindByIdAsync(User!.Id, cancellationToken);

            if (dbUser == null) throw new NotFoundException(nameof(User), User!.Id);
            dbUser.Nationality = request.Nationality;
            dbUser.DateOfBirth = request.DateOfBirth;


          await _userStore.UpdateAsync(dbUser, cancellationToken);
        }
    }
}
