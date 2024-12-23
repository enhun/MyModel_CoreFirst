using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyModel_CodeFirst.Models
{
    public class ReBook
    {
        public ReBook()
        {
            Content = string.Empty;
            ReplyTime = DateTime.Now; // 設定預設值
        }

        [Key]
        public int ReBookId { get; set; }

        [Required(ErrorMessage = "回覆內容是必填的")]
        [StringLength(500, ErrorMessage = "回覆內容不能超過 500 個字元")]
        [Display(Name = "回覆內容")]
        public string Content { get; init; }

        [DataType(DataType.DateTime)]
        [Display(Name = "回覆時間")]
        public DateTime ReplyTime { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }

        public virtual Book? Book { get; set; }
    }
}