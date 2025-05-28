//Klasa definiująca zgłoszenie.
public class Ticket
{
    public string ClientName { get; set; } = string.Empty;
    public string Device { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Status { get; set; } = "Nowe";
}
