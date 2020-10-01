namespace MarkDocsAppContracts.DTO.Markers
{
    public class Marker
    {
        public string DocID { get; set; }
        public string MarkerID { get; set; }
        public string UserID { get; set; }
        public string MarkerType { get; set; }
        public string StrokeColor { get; set; }
        public string BackgroundColor { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public string XRadius { get; set; }
        public string YRadius { get; set; }
    }
}
