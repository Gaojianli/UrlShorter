﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ShortUrl.Entities
{
    [Table("urls")]
    public class Url
    {
        [Column("id")]
        public int id { get; set; }
        [Column("long_url")]
        public string longUrl { get; set; }
        [Column("short_url")]
        public string shortUrl { get; set; }
        [Column("revoke_pwd")]
        public string revokePassword { get; set; }
    }
}
