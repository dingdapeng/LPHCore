using System;
using System.Collections.Generic;

namespace LPHCore.Model
{
    public partial class News
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string ImgUrl { get; set; }
        public string Contents { get; set; }
        public DateTime CreateTime { get; set; }
        public int Click { get; set; }
        public byte Status { get; set; }
        public int Seq { get; set; }

        public virtual NewsCategory Category { get; set; }
    }
}
