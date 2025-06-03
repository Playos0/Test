using System.Text.Json;
using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.FileIO;
using System.Linq;


//klasa obsługi zgłoszeń
public static class TicketService
{
    // Statyczny konstruktor, który jest wywoływany przy pierwszym użyciu klasy TicketService
    static TicketService()
    {
        LoadTicketsFromFile(); // Ładowanie zgłoszeń z pliku podczas inicjalizacji klasy
    }

    // Lista przechowująca zgłoszenia
    private static List<Ticket> tickets = new List<Ticket>();

    // Metoda do dodawania zgłoszenia
    public static void AddTicket(Ticket ticket)
    {
        //nadaje unikalne ID dla zgłoszenia
        ticket.Id = tickets.Count > 0 ? tickets.Max(t => t.Id) + 1 : 1; // Ustawia ID na podstawie maksymalnego ID w liście lub 1, jeśli lista jest pusta
        tickets.Add(ticket);
        SaveTicketsToFile(); // Zapisanie zgłoszeń do pliku po dodaniu nowego zgłoszenia
    }

    // Metoda do usuwania zgłoszenia
    public static void DeleteTicket(Ticket ticket)
    {
        tickets.Remove(ticket);
        SaveTicketsToFile(); // Zapisanie zgłoszeń do pliku po usunięciu zgłoszenia
    }

    /* POZA UŻYCIEM, MOŻE SIĘ PRZYDA
    //Metoda do usuwania załączników
    public static void DeleteTicketsAttachment(Ticket ticket, Attachment attachment)
    {
        ticket.Attachments.Remove(attachment);
        SaveTicketsToFile();
    }
    */

    // Metoda do pozyskania isty zgłoszeń
    public static List<Ticket> GetTickets()
    {
        return tickets;
    }

    // Metoda do zapisywania zgłoszeń do pliku JSON
    private static readonly string filePath = "tickets.json";
    public static void SaveTicketsToFile()
    {
        var options = new JsonSerializerOptions { WriteIndented = true }; // Opcje serializacji, aby formatować JSON w czytelny sposób
        string json = JsonSerializer.Serialize(tickets, options); // Serializacja listy zgłoszeń do formatu JSON
        File.WriteAllText(filePath, json); // Zapisanie JSON do pliku
    }

    // Metoda do wczytywania zgłoszeń z pliku JSON
    public static void LoadTicketsFromFile()
    {
        if (File.Exists(filePath)) // Sprawdzenie, czy plik istnieje
        {
            string json = File.ReadAllText(filePath); // Wczytanie zawartości pliku
            tickets = JsonSerializer.Deserialize<List<Ticket>>(json) ?? new List<Ticket>(); // Deserializacja JSON do listy zgłoszeń
        }
        else
        {
            tickets = new List<Ticket>(); // Jeśli plik nie istnieje, inicjalizujemy pustą listę zgłoszeń
        }
    }

    //Metoda do Zmiany statusu zgłoszenia
    public static void ChangeStatus(Ticket ticket, string newStatus)
    {
        var existingTicket = tickets.FirstOrDefault(t => t.Id == ticket.Id); // Znajdujemy istniejące zgłoszenie po ID
        if (existingTicket != null) // Sprawdzamy, czy zgłoszenie istnieje
        {
            existingTicket.Status = newStatus; // Zmieniamy status zgłoszenia
            SaveTicketsToFile(); // Zapisujemy zmiany do pliku
        }

    }

    public static Ticket? GetTicketById(int id) // Metoda do znajdowania zgłoszenia po ID
    {
        return tickets.FirstOrDefault(t => t.Id == id); // Znajdowanie zgłoszenia po ID
    }


}