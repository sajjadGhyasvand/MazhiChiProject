﻿using System;

namespace CommentManagement.Application.Contracts.Comment
{
    public class CommentViewModel
    {
        public long  Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public string OwnerName { get; set; }
        public long OwnerId { get; set; }
        public int Type { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsCancel { get; set; }
        public bool IsActive { get; set; }
        public string CommentDate { get; set; }
        public DateTime Date { get; set; }

    }
}