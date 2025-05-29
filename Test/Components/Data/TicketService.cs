//klasa obsługi zgłoszeń
public static class TicketService
{
    // Lista przechowująca zgłoszenia
    private static List<Ticket> tickets = new List<Ticket>();

    // Metoda do dodawania zgłoszenia
    public static void AddTicket(Ticket ticket)
    {
        tickets.Add(ticket);
    }

    // Metoda do pozyskania isty zgłoszeń
    public static List<Ticket> GetTickets()
    {
        return tickets;
    }

    // Metoda do usuwania zgłoszenia
    public static void DeleteTicket(Ticket ticket)
    {
        tickets.Remove(ticket);
    }

}