using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sampel.RestAPI.Core.RequestResponse.RestApiDemos.Commands.Create;
using Sampel.RestAPI.Core.RequestResponse.RestApiDemos.Commands.Delete;
using Sampel.RestAPI.Core.RequestResponse.RestApiDemos.Commands.Update;
using Sampel.RestAPI.Core.RequestResponse.RestApiDemos.Queries.GetPageFilter;
using Sampel.RestAPI.Core.RequestResponse.RestApiDemos.Queries.GetSelectList;
using Sampel.RestAPI.Endpoints.API.DTOs;
using Zamin.Core.RequestResponse.Queries;
using Zamin.EndPoints.Web.Controllers;
using Zamin.Extensions.UsersManagement.Abstractions;

namespace Sampel.RestAPI.Endpoints.API.RestApiDemos
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RestApiDemoController : BaseController
    {

        #region Command

        [HttpPost("Create")]
        public async Task<IActionResult> CreateRestApiDemo([FromBody] RestApiDemoCreateDto dto)
        {
            RestApiDemoCreateCommand command = new RestApiDemoCreateCommand()
            {
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                NationalId = dto.NationalId,
                PhoneNumber = dto.PhoneNumber,
            };
            return await Create<RestApiDemoCreateCommand, int> (command);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteRestApiDemo([FromQuery] RestApiDemoDeleteCommand command)
        {
            return await Delete(command);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateRestApiDemot([FromQuery] RestApiDemoUpdateDto dto)
        {
            RestApiDemoUpdateCommand command = new RestApiDemoUpdateCommand()
            {
                Id = dto.Id,
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                NationalId = dto.NationalId,
                PhoneNumber = dto.PhoneNumber,

            };
            return await Edit(command);
        }

        #endregion


        #region Query

        [HttpGet("GetPagedFilter")]
        public async Task<IActionResult> GetRestApiDemoPagedFilter([FromQuery] RestApiDemoGetPagedFilterDto dto)
        {
            RestApiDemoGetPageFilterQuery query = new RestApiDemoGetPageFilterQuery()
            {
                NeedTotalCount = dto.NeedTotalCount,
                PageNumber = dto.PageNumber,
                PageSize = dto.PageSize,
                SortAscending = dto.SortAscending,
                SortBy = dto.SortBy,
            };

            return await Query<RestApiDemoGetPageFilterQuery, PagedData<RestApiDemoGetPageFilterQr>>(query);
        }
        [HttpGet("GetSelectList")]
        public async Task<IActionResult> GetRestApiDemoSelectList()
        {
            RestApiDemoGetSelectListQuery query = new RestApiDemoGetSelectListQuery()
            {
            };
            return await Query<RestApiDemoGetSelectListQuery, List<RestApiDemoGetSelectListQr>>(query);
        }

        #endregion


    }
}
