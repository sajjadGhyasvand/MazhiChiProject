namespace BlogManagement.Application.Contracts.ArticlePicture
{
    public class ArticlePictureViewModel 
    {
        public long Id { get; set; }
        public string Article { get; set; }
        public string Picture { get; set; }
        public string PictureTitle { get; set; }
        public string CreationDate { get; set; }
        public bool IsRemoved { get; set; }
        public long ArticleId { get; set; }
        public  string Link { get; set; }
    }
}