using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace qansapi
{
    public class AuthorizationManager
    {
        private readonly string key;
        private IReadOnlyDictionary<string, string> user = new Dictionary<string, string> { { "rishi","pani"},{"Test","pwd" } };
        public AuthorizationManager(string key)
        {
            this.key = key;
        }
        public String Authincate(String username,String password)
        {
            if (!user.Any(x => x.Key == username && x.Value == password))
            {
                return null;
            }
            JwtSecurityTokenHandler tokenHandler= new JwtSecurityTokenHandler();
            var tokenkey=Encoding.ASCII.GetBytes(key);
            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey),SecurityAlgorithms.HmacSha256Signature) 
            };
            var token = tokenHandler.CreateToken(securityTokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
