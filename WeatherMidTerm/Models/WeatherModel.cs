namespace WeatherMidTerm.Models;

public class WeatherModel
{
    public Location location { get; set; }
    public Current current { get; set; }
}

public class Location
{
    public string name { get; set; }
    public string country { get; set; }
    public string region { get; set; }
    public string localTime { get; set; }
}

public class Current
{
    public int temperature { get; set; }
    public string[] weather_descriptions { get; set; }
    public int wind_speed { get; set; }
    public string wind_dir { get; set; }
    public int precip { get; set; }
    public int humidity { get; set; }
    public int cloudcover { get; set; }
}