namespace UmbracoBridge.Models
{
   public class DocumentType
   {
      public string Alias { get; set; } = string.Empty;
      public string Name { get; set; } = string.Empty;
      public string Description { get; set; } = string.Empty;
      public string Icon { get; set; } = string.Empty;
      public bool AllowedAsRoot { get; set; }
      public bool VariesByCulture { get; set; }
      public bool VariesBySegment { get; set; }
      public Collection? Collection { get; set; }
      public bool IsElement { get; set; }
   }

   public class Collection
   {
      public string Id { get; set; } = string.Empty;
   }
}
