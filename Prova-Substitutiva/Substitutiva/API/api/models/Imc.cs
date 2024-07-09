public class Imc{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string? nome { get; set; }
    public Date datanasc { get; set; } 
    public string? altura { get; set; }
    public string? peso { get; set; } 
    public string? IMC { get; set; } 
   public string? classificação { get; set; } 
   public DateTime Criacao { get; set; } = DateTime.Now;
}
