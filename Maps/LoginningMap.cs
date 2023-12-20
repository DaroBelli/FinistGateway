using FinistGateway.Controllers;

namespace FinistGateway.Maps
{
    public class LoginningMap
    {
        public LoginningMap(WebApplication? app)
        {
            app.MapPost("/check-loginning", async ( LoginInfo loginInfo) => await LoginningController.CheckCorrectLoginIfo(loginInfo))
                .WithTags("Loginning");
        }
    }
}
