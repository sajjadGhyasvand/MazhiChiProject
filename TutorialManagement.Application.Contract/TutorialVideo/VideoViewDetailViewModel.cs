using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialManagement.Application.Contract.TutorialVideo
{
    public class VideoViewDetailViewModel
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public DateTime ViewTimestamp { get; set; }
    }
}
