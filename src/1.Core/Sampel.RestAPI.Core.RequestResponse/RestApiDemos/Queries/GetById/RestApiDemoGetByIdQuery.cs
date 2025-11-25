using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.RequestResponse.Queries;

namespace Sampel.RestAPI.Core.RequestResponse.RestApiDemos.Queries.GetById
{
    public sealed class RestApiDemoGetByIdQuery : IQuery<RestApiDemoGetByIdQr>
    {
        public int Id { get; set; }
    }
}
