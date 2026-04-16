using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Queries
{
    public class GetTestStatusHandler : IRequestHandler<GetTestStatusQuery, string>
    {
        public Task<string> Handle(GetTestStatusQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult("API is Up and Running with MediatR!");
        }
    }
}
