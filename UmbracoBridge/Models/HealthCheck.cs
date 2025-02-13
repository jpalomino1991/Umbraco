namespace UmbracoBridge.Models
{
   public class HealthCheck
   {
      public int Total { get; set; }
      public List<HealthCheckItem> Items { get; set; } = new List<HealthCheckItem>();
   }
}
