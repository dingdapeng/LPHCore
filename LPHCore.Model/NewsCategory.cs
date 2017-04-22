using System;
using System.Collections.Generic;

namespace LPHCore.Model
{
    public partial class NewsCategory
    {
        public NewsCategory()
        {
            News = new HashSet<News>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}
