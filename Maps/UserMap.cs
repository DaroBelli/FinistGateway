using FinistGateway.Controllers;

namespace FinistGateway.Maps
{
    public class UserMap
    {
        public UserMap (WebApplication? app) 
        { 
            app.MapPost("/get-user", async (PhoneNumber phoneNumber) => await UserController.GetUserAsync(phoneNumber))
                .WithTags("User"); 
        }
    }
}
