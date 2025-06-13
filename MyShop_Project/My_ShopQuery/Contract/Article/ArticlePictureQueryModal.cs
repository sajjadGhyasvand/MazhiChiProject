namespace My_ShopQuery.Contract.Article
{
    public class ArticlePictureQueryModal
    {
        public long Id { get; set; }
        public long ArticleId { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Link { get; set; }
        public bool IsRemoved { get; set; }
    }
}