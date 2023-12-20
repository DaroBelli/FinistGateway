using Grpc.Net.Client;

namespace FinistGateway.Controllers
{
    public class LoginningController
    {
        /// <summary>
        /// Запрашивает у бизнес логики проверку корректности внесённых пользователем данных.
        /// </summary>
        /// <param name="loginInfo">Данные для входа.</param>
        /// <returns></returns>
        public async static Task<IsCorrectLoginInfo> CheckCorrectLoginIfo(LoginInfo loginInfo)
        {
            using var channel = GrpcChannel.ForAddress(ConfigJSON.GetConfig().GetSection("BusinessLogicAddress").Value);

            var client = new LoginningService.LoginningServiceClient(channel);

            var isCorrectLoginInfo = await client.TryLoginningAsync(loginInfo);

            return isCorrectLoginInfo;
        }
    }
}
