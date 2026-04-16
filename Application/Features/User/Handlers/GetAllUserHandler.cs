using Application.Features.User.Queries;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Handlers
{

        public class GetAllUserHandler : IRequestHandler<GetAllUserQuery, List<string>>
        {
            private readonly IUserRepository _userRepository;

            public GetAllUserHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<List<string>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
            {
            var users = await _userRepository.GetAllAsync();

            return users.Select(u => u.Name).ToList();
        }
        }
    
}
