using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Attachment 
{
    public string FileName { get; set; } = string.Empty; // Nazwa pliku załącznika
    public string ContentType { get; set; } = string.Empty; // Typ pliku (np. "image/png", "application/pdf")
    public byte[] Data { get; set; } = Array.Empty<byte>(); // Zawartość pliku załącznika jako tablica bajtów
}
