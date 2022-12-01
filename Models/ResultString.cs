namespace JamahaApi.Models
{


    public class ResultString
    {
        public ResultParts[] ResultParts { get; set; }
        public string ModelName { get; set; } = null!;
        public string ProdPictureFileUrl { get; set; } = null!;
        public string? Chapter { get; set; }
        public string? chapterID { get; set; }

    }

    public class ResultParts
    {
        public string? RefNo { get; set; }
        public string PartNo { get; set; } = null!;
        public string PartName { get; set; } = null!;
        public int Quantity { get; set; }
        
    }
}
