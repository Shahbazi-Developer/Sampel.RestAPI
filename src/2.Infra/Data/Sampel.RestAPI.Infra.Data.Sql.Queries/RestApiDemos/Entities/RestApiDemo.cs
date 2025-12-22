using Sampel.RestAPI.Core.Domain.RestApiDemos.ValueObjects;
using Sampel.RestAPI.Core.RequestResponse.RestApiDemos.Queries.GetById;
using Sampel.RestAPI.Core.RequestResponse.RestApiDemos.Queries.GetPageFilter;
using Sampel.RestAPI.Core.RequestResponse.RestApiDemos.Queries.GetSelectList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sampel.RestAPI.Infra.Data.Sql.Queries.RestApiDemos.Entities
{
    public class RestApiDemo
    {
        public int Id { get; set; }
        public string? LastName { get;  set; }
        public string? FirstName { get;  set; }
        public string? NationalId { get;  set; }
        public string? PhoneNumber { get;  set; }
        public bool Deleted { get;  set; }
        public DateTime? CreatedDateTime { get; set; }


        public static explicit operator RestApiDemoGetByIdQr(RestApiDemo entity) => new()
        {
            Id = entity.Id,
            LastName = entity.LastName,
            FirstName = entity.FirstName,
            NationalId = entity.NationalId,
            PhoneNumber = entity.PhoneNumber

        };

        public static explicit operator RestApiDemoGetPageFilterQr(RestApiDemo entity) => new()
        {
            Id = entity.Id,
            LastName = entity.LastName,
            FirstName = entity.FirstName,
            NationalId = entity.NationalId,
            PhoneNumber = entity.PhoneNumber

        };

        public static explicit operator RestApiDemoGetSelectListQr(RestApiDemo entity) => new()
        {
            Id = entity.Id,
            LastName = entity.LastName,
            FirstName = entity.FirstName,
            NationalId = entity.NationalId,
            PhoneNumber = entity.PhoneNumber

        };


    }
}
