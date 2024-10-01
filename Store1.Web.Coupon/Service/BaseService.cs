using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;
using Store1.Web.Coupon.Models;
using Store1.Web.Coupon.Service.IService;
using System.Net;
using System.Text;
using static Store1.Web.Coupon.Utility.SD;

namespace Store1.Web.Coupon.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        //private readonly ITokenProvider _tokenProvider;

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            //_tokenProvider = tokenProvider;
        }
        public async Task<ResponseDto?> SendAsync(RequestDto requestDto)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("Store1Api");
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");

                //token
                //if (withBearer)
                //{
                //    var token = _tokenProvider.GetToken();
                //    message.Headers.Add("Authorization", $"Bearer {token}");
                //}



                message.RequestUri = new Uri(requestDto.Url);
                if (requestDto.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
                }

                HttpResponseMessage? apiResponse = null;

                switch (requestDto.ApiType)
                {
                    case ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    case ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;

                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                apiResponse = await client.SendAsync(message);

                switch (apiResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new() { ISSuccess = false, Message = "Not Found" };
                    case HttpStatusCode.Forbidden:
                        return new() { ISSuccess = false, Message = "Access Denied" };
                    case HttpStatusCode.Unauthorized:
                        return new() { ISSuccess = false, Message = "Unauthorized" };
                    case HttpStatusCode.InternalServerError:
                        return new() { ISSuccess = false, Message = "Internal Server Error" };
                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                        return apiResponseDto;
                }
            }
            catch (Exception ex)
            {
                var dto = new ResponseDto()
                {
                    Message = ex.Message.ToString(),
                    ISSuccess = false
                };
                return dto;

            }
        }
    }
}
