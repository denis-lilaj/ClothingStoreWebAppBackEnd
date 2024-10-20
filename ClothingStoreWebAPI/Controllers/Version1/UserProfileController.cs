using Application;
using Application.UserProfiles.Commands;
using Application.UserProfiles.Queries;
using AutoMapper;
using ClothingStoreWebAPI.Common;
using ClothingStoreWebAPI.Contracts.Requests;
using ClothingStoreWebAPI.Contracts.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStoreWebAPI.Controllers.Version1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route(APIRoutes.BaseRoute)]
    public class UserProfileController : BaseController
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserProfileController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllUserProfiles()
        {
            var query = new GetAllUserProfilesQuery();
            var response=await _mediator.Send(query);
            var profiles= _mapper.Map<List<UserProfileResponse>>(response);
            return Ok(profiles);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateUserProfile([FromBody] UserProfileCreate profileCreate)
        {
            var command = _mapper.Map<CreateUserProfileCommand>(profileCreate);
            var response = await _mediator.Send(command);
            var userProfile = _mapper.Map<UserProfileResponse>(response);

            return CreatedAtAction(nameof(GetUserProfileById), new { id = response.Guid }, userProfile );
        }

        [Route(APIRoutes.UserProfiles.IdRoute)]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserProfileById(string id)
        {
            var query = new GetUserProfileByIdQuery { UserProfileId = Guid.Parse(id) };
            var response= await _mediator.Send(query);
            if (response is null)
            {
                return NotFound("Not any user with this profile Id found");
            }
            var userProfile = _mapper.Map<UserProfileResponse>(response);
            return Ok(userProfile);
        }


        [Route(APIRoutes.UserProfiles.IdRoute)]
        [HttpPatch]
        [Authorize]
        public async Task<IActionResult> UpdateUserProfile(string id, [FromBody] UserProfileCreate updatedProfile)
        {
            var command = _mapper.Map<UpdateUserProfileBasicInfoCommand>(updatedProfile);
            command.UserProfileId = Guid.Parse(id);
            var response = await _mediator.Send(command);
            if (response.isError)
            {
                HandleErrorResponse(response.Errors);
            }
            return NoContent();
        }


        [Route(APIRoutes.UserProfiles.IdRoute)]
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteUserProfile(string id)
        {
            var command = new DeleteUserProfileCommand { UserProfileId = Guid.Parse(id) };
            var response = await _mediator.Send(command);
            return NoContent();
        }

        [Route("LogIn/{username}")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> LogInGetUserIdTest(string username)
        {
            var command=new GetUserIdQuery { Username= username };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
      
    }
}
