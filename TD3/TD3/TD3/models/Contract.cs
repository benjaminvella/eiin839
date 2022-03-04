namespace TD3.models;

public class Contract
{
    public string name { get; set; }
    public string commercial_name { get; set; }
    public List<string> cities { get; set; }
    public string country_code { get; set; }

    public override string ToString()
    {
        string citiesString = "";
        if(cities != null) cities.ForEach(c => citiesString += c.ToString() + " , ");
        return $"{nameof(name)}: {name}, {nameof(commercial_name)}: {commercial_name}, {nameof(cities)}: {citiesString}, {nameof(country_code)}: {country_code}";
    }
}