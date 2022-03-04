namespace TD3.models;

public class Station
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    
    public int number { get; set; }
    public string contract_name { get; set; }
    public string name { get; set; }
    public string address { get; set; }
    public Position position { get; set; }
    public bool banking { get; set; }
    public bool bonus { get; set; }
    public int bike_stands { get; set; }
    public int available_bike_stands { get; set; }
    public int available_bikes { get; set; }
    public string status { get; set; }
    public object last_update { get; set; }

    public override string ToString()
    {
        return
            $"{nameof(name)}: {name}, " + "\n  " +
            $"{nameof(contract_name)}: {contract_name}, " + "\n  " +
            $"{nameof(number)}: {number}, " + "\n  " +
            $"{nameof(address)}: {address}, " + "\n  " +
            $"{nameof(position)}: {position}, " + "\n  " +
            $"{nameof(banking)}: {banking}, " + "\n  " +
            $"{nameof(bonus)}: {bonus}, " + "\n  " +
            $"{nameof(bike_stands)}: {bike_stands}, " + "\n  " +
            $"{nameof(available_bike_stands)}: " + "\n  " +
            $"{available_bike_stands}, " + "\n  " +
            $"{nameof(available_bikes)}: " + "\n  " +
            $"{available_bikes}, " + "\n  " +
            $"{nameof(status)}: {status}, " + "\n  " +
            $"{nameof(last_update)}: {last_update}";
    }

}