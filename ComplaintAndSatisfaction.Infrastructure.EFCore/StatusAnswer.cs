using System.Collections.Generic;

namespace ComplaintAndSatisfaction.Infrastructure.EFCore
{
    public class StatusAnswer
    {
        public const int StatusId1 = 1;
        public const string StatusStr1 = "پاسخ داده شده";

        public const int StatusId2 = 2;
        public const string StatusStr2 = "پاسخ داده نشده";

    }
    public class StatusAnswerItem
    {
        public int Id { get; set; }
        public string Status { get; set; }

    }

    public static class StatusAnswerService
    {
        public static List<StatusAnswerItem> GetStatusAnswerList()
        {
            return new List<StatusAnswerItem>
            {
                new StatusAnswerItem { Id = StatusAnswer.StatusId1, Status = StatusAnswer.StatusStr1},
                new StatusAnswerItem { Id = StatusAnswer.StatusId2, Status = StatusAnswer.StatusStr2},
            };
        }
    }
}