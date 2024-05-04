using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ServerApplication.Domain;

namespace ServerApplication.Services
{
    public interface ICreateJWT
    {
        public Task<object> Create(User userModel);
    }
    
    public class CreateJwt: ICreateJWT
    {
        public async Task<object> Create(User userModel)
        {
            // 1. Generate an asymmetric security key from your secret
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("6547647654764764767657658658758765876532540")); // replace with your secret
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // 2. Create a list of claims for user
            var claims = new[] {
                new Claim("userName", $"{userModel.FirstName} {userModel.MiddleName} {userModel.LastName}"),
                new Claim("userId", $"{userModel.Id}"),
                new Claim("phoneNumber", userModel.PhoneNumber),
                new Claim("email", userModel.Email),
                new Claim("role", userModel.UserRole.ToString())};

            // 3. Create token
            var token = new JwtSecurityToken(
                claims: claims, // User Identity with claims
                expires: DateTime.Now.AddHours(24), // token expiry, do change as per your need
                signingCredentials: credentials);

            // 4. return as object
            return await Task.FromResult(new {
                token = new JwtSecurityTokenHandler().WriteToken(token),  // generate token
                expiration = token.ValidTo  // when it expires
            });
        }
    }
}