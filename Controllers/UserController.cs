using Grpc.Net.Client;

namespace FinistGateway.Controllers
{
    public static class UserController
    {
        /// <summary>
        /// Запрашивает у бизнес логики данные по пользователю.
        /// </summary>
        /// <param name="phoneNumber">Номер телефона пользователя.</param>
        /// <returns></returns>
        public async static Task<UserReply?> GetUserAsync(PhoneNumber phoneNumber)
        {
            using var channel = GrpcChannel.ForAddress(ConfigJSON.GetConfig().GetSection("BusinessLogicAddress").Value);

            var client = new UserService.UserServiceClient(channel);

            var user = await client.GetUserAsync(phoneNumber);

            return user;
        }
    }
}
