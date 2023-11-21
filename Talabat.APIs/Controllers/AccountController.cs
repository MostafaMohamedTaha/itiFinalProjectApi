//using AutoMapper;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using System.Security.Claims;
//using System.Threading.Tasks;
//using Talabat.APIs.Dtos;
//using Talabat.APIs.Errors;
//using Talabat.APIs.Extensions;
//using Talabat.Core.Entities.Identity;
//using Talabat.Core.Services;

//namespace Talabat.APIs.Controllers
//{
//    public class AccountController : BaseApiController
//    {
//        private readonly UserManager<AppUser> _userManager;
//        private readonly SignInManager<AppUser> _signInManger;
//        private readonly ITokenService _tokenService;
//        private readonly IMapper _mapper;

//        public AccountController(
//            UserManager<AppUser> userManager,
//            SignInManager<AppUser> signInManger,
//            ITokenService tokenService,
//            IMapper mapper)
//        {
//            _userManager = userManager;
//            _signInManger = signInManger;
//            _tokenService = tokenService;
//            _mapper = mapper;
//        }

//        [HttpPost("login")]
//        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
//        {
//            var user = await _userManager.FindByEmailAsync(loginDto.Email);
//            if (user == null) return Unauthorized(new ApiResponse(401));
//            var result = await _signInManger.CheckPasswordSignInAsync(user, loginDto.Password, false);
//            if (!result.Succeeded) return Unauthorized(new ApiResponse(401));


//            return Ok(new UserDto()
//            {
//                DisplayName = user.DisplayName,
//                Email = user.Email,
//                Token = await _tokenService.CreateToken(user, _userManager)
//            });
//        }

//        [HttpPost("register")]
//        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
//        {
//            if (CheckEmailExistAsync(registerDto.Email).Result.Value)
//            {
//                return new BadRequestObjectResult(new ApiValidationErrorResponse() { Errors = new[] { "Email address is in use" } });
//            }
//            var user = new AppUser()
//            {
//                DisplayName = registerDto.DisplayName,
//                Email = registerDto.Email,
//                UserName = registerDto.Email.Split('@')[0],
//                PhoneNumber = registerDto.PhoneNumber

//            };

//            var result = await _userManager.CreateAsync(user, registerDto.Password);

//            if (!result.Succeeded) return BadRequest(new ApiResponse(400));

//            return Ok(new UserDto()
//            {
//                DisplayName = user.DisplayName,
//                Email = user.Email,
//                Token = await _tokenService.CreateToken(user, _userManager)
//            });
//        }

//        [HttpGet("emailexists")]
//        public async Task<ActionResult<bool>> CheckEmailExistAsync(string email)
//        {
//            return await _userManager.FindByEmailAsync(email) != null;
//        }

//        //[Authorize]
//        [HttpGet]
//        public async Task<ActionResult<UserDto>> GetCurrentUser()
//        {
//            var email = User.FindFirstValue(ClaimTypes.Email);
//            var user = await _userManager.FindByEmailAsync(email);
//            return Ok(new UserDto()
//            {
//                Email = email,
//                DisplayName = user.DisplayName,
//                Token = await _tokenService.CreateToken(user, _userManager)
//            });
//        }

//        //[Authorize]
//        [HttpGet("address")]
//        public async Task<ActionResult<AddressDto>> GetUserAddress()
//        {
//            var user = await _userManager.FindUserWithAddressByEmailAsync(User);

//            return Ok(_mapper.Map<Address, AddressDto>(user.Address));
//        }
//        //[Authorize]
//        [HttpPost("address")]
//        public Task<ActionResult<AddressDto>> PostUserAddress(AddressDto address)
//        {
//            var Address = new Address()
//            {

//                FirstName = address.FirstName,
//                LastName = address.LastName,
//                City = address.City,
//                Country = address.Country,
//                Street = address.Street,


//            };

//            return Task.FromResult<ActionResult<AddressDto>>(Ok(Address));
//        }
//        [Authorize]
//        [HttpPut("address")]
//        public async Task<ActionResult<AddressDto>> UpdateUserAddress(AddressDto newAddress)
//        {
//            var email = User.FindFirstValue(ClaimTypes.Email);
//            var user = await _userManager.FindByEmailAsync(email);

//            user.Address = _mapper.Map<AddressDto, Address>(newAddress);

//            var result = await _userManager.UpdateAsync(user);

//            if (!result.Succeeded) return BadRequest(new ApiValidationErrorResponse() { Errors = new[] { "An error occured during updating the address" } });

//            return Ok(newAddress);
//        }
//    }
//}
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Talabat.APIs.Dtos;
using Talabat.APIs.Errors;
using Talabat.APIs.Extensions;
using Talabat.Core.Entities.Identity;
using Talabat.Core.Services;

namespace Talabat.APIs.Controllers
{
    public class AccountController : BaseApiController
    {
        #region params manager|signIn|token|mapper

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        #endregion

        #region ctor

        public AccountController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ITokenService tokenService,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }
        #endregion

        #region login

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return Unauthorized(new ApiResponse(401));
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded)
            {
                return Unauthorized(new ApiResponse(401));
            }

            return Ok(new UserDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = await _tokenService.CreateToken(user, _userManager)
            });
        }
        #endregion

        #region register

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (CheckEmailExistAsync(registerDto.Email).Result.Value)
            {
                return new BadRequestObjectResult(new ApiValidationErrorResponse() { Errors = new[] { "Email address is in use" } });
            }

            var user = new AppUser()
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.Email.Split('@')[0],
                PhoneNumber = registerDto.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(new ApiResponse(400));
            }

            return Ok(new UserDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = await _tokenService.CreateToken(user, _userManager)
            });
        }
        #endregion

        #region email exist

        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExistAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }
        #endregion

        #region current user

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            return Ok(new UserDto()
            {
                Email = email,
                DisplayName = user.DisplayName,
                Token = await _tokenService.CreateToken(user, _userManager)
            });
        }
        #endregion

        #region get address

        [Authorize]
        [HttpGet("address")]
        public async Task<ActionResult<AddressDto>> GetUserAddress()
        {
            var user = await _userManager.FindUserWithAddressByEmailAsync(User);
            return Ok(_mapper.Map<Address, AddressDto>(user.Address));
        }
        #endregion

        #region post address

        [Authorize]
        [HttpPost("address")]
        public Task<ActionResult<AddressDto>> PostUserAddress(AddressDto address)
        {
            var newAddress = new Address()
            {
                FirstName = address.FirstName,
                LastName = address.LastName,
                City = address.City,
                Country = address.Country,
                Street = address.Street,
            };

            return Task.FromResult<ActionResult<AddressDto>>(Ok(newAddress));
        }
        #endregion

        #region put address

        [Authorize]
        [HttpPut("address")]
        public async Task<ActionResult<AddressDto>> UpdateUserAddress(AddressDto newAddress)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);

            user.Address = _mapper.Map<AddressDto, Address>(newAddress);

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return BadRequest(new ApiValidationErrorResponse() { Errors = new[] { "An error occurred during updating the address" } });
            }

            return Ok(newAddress);
        }
        #endregion
    }
}

