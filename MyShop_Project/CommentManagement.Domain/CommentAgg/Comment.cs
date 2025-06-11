using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using My_Shop_Framework.Domain;

namespace CommentManagement.Domain.CommentAgg
{
    public class Comment : EntityBase
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Subject { get; private set; }
        public string Message { get; private set; }
        public bool IsConfirmed { get; private set; }
        public bool IsCancel { get; private set; }
        public long OwnerId { get; private set; }
        public int Type { get; private set; }


        public bool IsActive { get; private set; }
        public Comment(string name, string email, string phone, string message,long ownerId ,int type, string subject)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Message = message;
            OwnerId = ownerId;
            Type = type;
            Subject = subject;
        }

        public void Confirm()
        {
            IsConfirmed = true;
            IsCancel = false;
        }

        public void Cancel()
        {
            IsCancel = true;
            IsConfirmed = false;
        }

        public void Active()
        {
            IsActive = true;
        }
        public void DeActive()
        {
            IsActive = false;
        }
    }
}
