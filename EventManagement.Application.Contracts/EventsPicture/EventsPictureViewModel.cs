namespace EventManagement.Application.Contracts.EventsPicture
{
    public class EventsPictureViewModel 
    {
        public long Id { get; set; }
        public string Events { get; set; }
        public string Picture { get; set; }
        public string PictureTitle { get; set; }
        public string CreationDate { get; set; }
        public bool IsRemoved { get; set; }
        public long EventsId { get; set; }
        public  string Link { get; set; }
    }
}