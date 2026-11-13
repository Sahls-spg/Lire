namespace ProjetoLire.Services.DTOs
{
    public class GoogleVolumeInfo
    {
        public string? Title { get; set; }
        public List<string>? Authors { get; set; }
        public int? PageCount { get; set; }
        public string? Description { get; set; }
        public GoogleImageLinks? ImageLinks { get; set; }
    }
}