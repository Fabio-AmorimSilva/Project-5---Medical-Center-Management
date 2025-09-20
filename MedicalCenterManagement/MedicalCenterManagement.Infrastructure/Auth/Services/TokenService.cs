namespace MedicalCenterManagement.Infrastructure.Auth.Services;

public class TokenService(IOptions<JwtSettingsDto> options) : ITokenService
{
    private readonly JwtSettingsDto _jwtSettings = options.Value;

    public string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSettings.Key);
        var claims = user.GetClaims();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.Expiration),
            Audience = _jwtSettings.Audience,
            Issuer = _jwtSettings.Issuer,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256
            )
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}