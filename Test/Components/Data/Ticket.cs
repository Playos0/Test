//Klasa definiująca zgłoszenie.
using System.ComponentModel.DataAnnotations;
public class Ticket
{
    public int Id { get; set; } // Id zgłoszenia

    [Required(ErrorMessage = "Imię klienta jest wymagane!")]
    public string ClientName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Nazwa urządzenia jest wymagana!")]
    public string Device { get; set; } = string.Empty;

    [Required(ErrorMessage = "Opis jest wymagany!")]
    public string Description { get; set; } = string.Empty;
    public string Status { get; set; } = "Nowe";
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Lista załączników do zgłoszenia
    public List<Attachment> Attachments { get; set; } = new();
}
