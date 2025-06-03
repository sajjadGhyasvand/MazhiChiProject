using EventManagement.Domain.Event.Agg;
using My_Shop_Framework.Domain;

namespace EventManagement.Domain.EventPicture
{
    public class EventPicture : EntityBase
    {
        public long EventId { get; private set; }
        public string Picture{ get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Link { get; private set; }
        public bool IsRemoved { get; private set; }
        public Events Events { get; private set; }

        public EventPicture(long eventId, string picture, string pictureAlt, string pictureTitle,string link)
        {
            EventId = eventId;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Link = link;
            IsRemoved = false;
        }


        public void Edit(long articleId, string pictureName, string pictureAlt, string pictureTitle, string link)
        {
            EventId = articleId;
            if(!string.IsNullOrWhiteSpace(pictureName))
                Picture = pictureName;
            PictureAlt = pictureAlt;
            Link = link;
            PictureTitle = pictureTitle;
        }

        public void Remove()
        {
            IsRemoved = true;
        }
        public void Restore()
        {
            IsRemoved = false;
        }
    }
}