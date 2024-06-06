using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;
using PayPalHttp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatUnit21Web.Controllers
{
    public class PayPalClient
    {
        private readonly PayPalHttpClient _client;

        public PayPalClient(string clientId, string clientSecret)
        {
            _client = new PayPalHttpClient(new SandboxEnvironment(clientId, clientSecret));
        }

        public async Task<Order> CreateOrder(decimal amount, string currency)
        {
            var request = new OrdersCreateRequest();
            request.Prefer("return=representation");
            request.RequestBody(BuildRequestBody(amount, currency));

            var response = await _client.Execute(request);
            return response.Result<Order>();
        }

        private OrderRequest BuildRequestBody(decimal amount, string currency)
        {
            var orderRequest = new OrderRequest()
            {
                CheckoutPaymentIntent = "CAPTURE",
                PurchaseUnits = new List<PurchaseUnitRequest>()
                {
                    new PurchaseUnitRequest()
                    {
                        AmountWithBreakdown = new AmountWithBreakdown()
                        {
                            CurrencyCode = currency,
                            Value = amount.ToString()
                        }
                    }
                }
            };

            return orderRequest;
        }
    }
}
