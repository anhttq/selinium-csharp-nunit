// using System.Net;
// using System.Text;
// using CoreFramework.Reporter;
// using RestSharp;

// namespace CoreFramework.APICore;
// public class RestSharpClient
// {
//     private static readonly RestClient _client = new RestClient();
//     public RestRequest Request;
//     public string Url { get; set; }
//     public string Method { get; set; }
//     public string RequestBody { get; set; }
//     public int ResponseCode { get; set; }
//     public string ResponseBody { get; set; }
//     public RestSharpClient(string url, string method, string body)
//     {
//         this.Url = url;
//         this.Method = method;
//         RequestBody = "";
//     }


//     public static async Task<string> GetRequest(string url)
//     {
//         var response = await _client.Execute(Reque);
//         var responseString = await response.Content.ReadAsStringAsync();
//         return responseString;
//     }

//     public void SendRequest()
//     {
//         var content = new StringContent(body, Encoding.UTF8, "application/json");
//         var response = _client.PostAsync(, content).Result;
//         ResponseCode = (int)response.StatusCode;
//         ResponseBody = response.Content.ReadAsStringAsync().Result;
//     }
// }
