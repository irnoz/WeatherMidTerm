namespace WeatherMidTerm.Models;

public class MapModel
{
    public List<Feature> features { get; set; } 
}

public class Feature
{
    public List<double> center { get; set; }
}