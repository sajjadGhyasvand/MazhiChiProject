using AccountManagement.Domain.Account.Agg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialManagement.Domain.TutorialVideo.Agg
{
    public class VideoView
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int VideoId { get; set; }
        public DateTime ViewTimestamp { get; set; }

    }
}
