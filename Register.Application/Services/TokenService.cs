using AutoMapper;
using Register.Application.Services.Interfaces;
using System.Security.Claims;
using System.Text;

namespace SADC.Application
{
    public class TokenService : ITokenService
    {
        //private readonly IConfiguration _configuration;
        //private readonly UserManager<IdentityUser> _userManager;
        //private readonly IMapper _mapper;
        //public readonly SymmetricSecurityKey _key;

        //public TokenService(IConfiguration configuration, UserManager<IdentityUser> userManager, IMapper mapper)
        //{
        //    _configuration = configuration;
        //    _userManager = userManager;
        //    _mapper = mapper;
        //    _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));
        //}
        //public async Task<string> CreateToken(UserLoginDto userLoginDto)
        //{
        //    var user = _mapper.Map<IdentityUser>(userLoginDto);

        //    var claims = new List<Claim> {

        //        new Claim(ClaimTypes.NameIdentifier, user.Id),
        //        new Claim(ClaimTypes.Name, user.UserName)
        //    };

        //    var roles = await _userManager.GetRolesAsync(user);

        //    claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        //    var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

        //    // Token Expiration Time
        //    var expiracao = _configuration["TokenConfiguration:ExpireHours"];
        //    var expiration = DateTime.UtcNow.AddHours(double.Parse(expiracao));

        //    var tokenDescription = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(claims),
        //        Expires = expiration,
        //        SigningCredentials = creds
        //    };

        //    var tokenHandler = new JwtSecurityTokenHandler();

        //    var token = tokenHandler.CreateToken(tokenDescription);

        //    return tokenHandler.WriteToken(token);
        //}
    }
}
