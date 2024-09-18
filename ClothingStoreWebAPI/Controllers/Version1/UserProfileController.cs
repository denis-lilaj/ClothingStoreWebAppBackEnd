using Application.UserProfiles.Commands;
using Application.UserProfiles.Queries;
using AutoMapper;
using ClothingStoreWebAPI.Contracts.Requests;
using ClothingStoreWebAPI.Contracts.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStoreWebAPI.Controllers.Version1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route(APIRoutes.BaseRoute)]
    public class UserProfileController : Controller
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserProfileController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserProfiles()
        {
            var query = new GetAllUserProfilesQuery();
            var response=_mediator.Send(query);
            var profiles= _mapper.Map<List<UserProfileResponse>>(response);
            return Ok(profiles);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserProfile([FromBody] UserProfileCreate profileCreate)
        {
            var command = _mapper.Map<CreateUserProfileCommand>(profileCreate);
            var response = await _mediator.Send(command);
            var userProfile = _mapper.Map<UserProfileResponse>(response);

            return CreatedAtAction(nameof(GetUserProfileById), new { id = response.Guid }, userProfile );
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetUserProfileById(string id)
        {
            var query = new GetUserProfileById { UserProfileId = Guid.Parse(id) };
            var response= await _mediator.Send(query);
            var userProfile = _mapper.Map<UserProfileResponse>(response);
            return Ok(userProfile);
        }
    }
}
