using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace SolarLab.MyAvito.Api
{
    public class AuthOptions
    {
        const string KEY = "EehsguehefaIOwAFJokafjfwnjfioESopfowjqfmq24532";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
