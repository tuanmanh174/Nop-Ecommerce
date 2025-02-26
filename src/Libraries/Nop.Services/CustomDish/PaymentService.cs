using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Nop.Services.CustomDish
{
    public class PaymentService
    {
        private const string MoMoEndpoint = "https://test-payment.momo.vn/v2/gateway/api/create";

        public async Task<string> GenerateMoMoPaymentUrl(decimal amount)
        {
            var requestId = Guid.NewGuid().ToString();
            var orderId = new Random().Next(1000, 9999).ToString();

            var payload = new
            {
                partnerCode = "MOMOX0000000",
                requestId = requestId,
                orderId = orderId,
                amount = amount,
                orderInfo = "Thanh toán món ăn",
                returnUrl = "https://yourwebsite.com/payment-success",
                notifyUrl = "https://yourwebsite.com/payment-callback",
                requestType = "captureWallet"
            };

            var jsonPayload = JsonSerializer.Serialize(payload);
            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(MoMoEndpoint, new StringContent(jsonPayload, Encoding.UTF8, "application/json"));
                var responseString = await response.Content.ReadAsStringAsync();
                dynamic jsonResponse = JsonSerializer.Deserialize<dynamic>(responseString);
                return jsonResponse?.payUrl;
            }
        }
    }
}
