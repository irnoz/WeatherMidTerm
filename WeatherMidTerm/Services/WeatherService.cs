using Flurl.Http;
using WeatherMidTerm.Models;
using WeatherMidTerm.Utils;

namespace WeatherMidTerm.Services;

public class WeatherService
{
    public async Task<ResponseModel> GetWeatherData(string location)
    {
        var url = Constants.WEATHER_URL;
        var apiKey = Constants.WEATHER_API_KEY;
        
        try
        {
            LocationService locationService = new LocationService();
            
            var locationResponse = locationService.GetLocationData(location);

            if (!locationResponse.Result.IsSuccess) return ResponseModel.Error("error: could not get location");
            var coordinates = locationResponse.Result.JsonData;
            var latitude = coordinates?[1];
            var longitude = coordinates?[0];

            string apiUrl = $"{url}?access_key={apiKey}&query={latitude},{longitude}";
            var weatherResponse = await apiUrl.GetAsync();
                
            Console.WriteLine($"Weather API URL: {apiUrl}");
            if (weatherResponse.StatusCode != 200)
                return ResponseModel.Error(weatherResponse.ResponseMessage.ToString());
            var responseData = await weatherResponse.GetJsonAsync<WeatherModel>();
            return ResponseModel.Success(responseData);

        }
        catch (FlurlHttpException exception)
        {
            var errorResponse = await exception.GetResponseJsonAsync<dynamic>();
            return ResponseModel.Error(errorResponse.ToString());
        }
    }
}

