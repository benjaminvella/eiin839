namespace TD3.models;

public class Position
{
    public double lat { get; set; }
    public double lng { get; set; }

    public override string ToString()
    {
        return $"{nameof(lat)}: {lat}, {nameof(lng)}: {lng}";
    }
}