﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fora.Shared
{
    public class MessageModel
    {
        [Key]
        public int Id { get; set; }
        public string Message { get; set; } = String.Empty;
        public bool Deleted { get; set; }
        public bool Edited { get; set; }
        public DateTime? Created { get; set; }
        public string? Username { get; set; }

        // Relations
        [ForeignKey(nameof(Thread))]
        public int? ThreadId { get; set; }
        public ThreadModel? Thread { get; set; }

        [ForeignKey(nameof(User))]
        public int? UserId { get; set; }
        public UserModel? User { get; set; }
    }
}
