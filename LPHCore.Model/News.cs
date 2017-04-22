using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LPHCore.Model
{
    public partial class News
    {
        public int Id { get; set; }
        [Display(Name = "所属类别")]
        public int CategoryId { get; set; }
        [Display(Name = "标题")]
        [Required]
        public string Title { get; set; }
        [Display(Name = "图片")]
        public string ImgUrl { get; set; }
        [Display(Name = "内容")]
        public string Contents { get; set; }
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }
        [Required]
        [Display(Name = "点击次数")]
        public int Click { get; set; }
        [Required]
        [Display(Name = "状态")]
        public byte Status { get; set; }
        [Display(Name = "排序")]
        public int Seq { get; set; }
        [Display(Name = "所属类别")]
        public virtual NewsCategory Category { get; set; }
    }
}
