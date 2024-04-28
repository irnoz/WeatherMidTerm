using Flurl.Http;
using WeatherMidTerm.Models;
using WeatherMidTerm.Utils;

namespace WeatherMidTerm.Services;

class LocationService
{
    public async Task<ResponseModel> GetLocationData(string location)
    {
        string url = Constants.MAP_URL;
        string apiKey = Constants.MAP_API_KEY;
        string apiUrl = $"{url}{location}.json?access_token={apiKey}&limit=1";
        try
        {
            var response = await apiUrl.GetAsync();
            if (response.StatusCode == 200)
            {
                var responseData = await response.GetJsonAsync<MapModel>();
                return ResponseModel.Success(responseData.features[0].center);
            }

            return ResponseModel.Error(response.ResponseMessage.ToString());
        }
        catch (FlurlHttpException exception)
        {
            var errorResponse = await exception.GetResponseJsonAsync<dynamic>();
            return ResponseModel.Error(errorResponse.ToString());
        }
    }
}