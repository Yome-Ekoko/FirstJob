
using System.Net.Http;
using System.Net.Http.Json;

class program
{
    static void Main(string[] sargs)

    {
        String url = "http://10.111.23.13:7843/testaccountequiry/v1/GenerateRetailAccount";
        var authTokenAlt = "TSTo4fA4qFFCTFswX7OrA==";
        var merchantId = Console.ReadLine();
        var channelCode = "TESTAPP";  
        var payload=new { merchant_id = merchantId, channel_code = channelCode };   

        var amount = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < amount; i++)
        {            
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", authTokenAlt);
            var response = client.PostAsJsonAsync(url,payload).Result;
            response.Content.ReadAsStringAsync().Wait();
            if (response.IsSuccessStatusCode)
            {
                var message = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }


            Console.WriteLine($"Called external service {amount} times for merchant {merchantId}");
        }
    }
}


