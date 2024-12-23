
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyModel_CodeFirst.Models
{
    public class Book
    {
        // 建構函式中初始化所有必要屬性
        public Book()
        {
            Title = string.Empty;
            Author = string.Empty;
            Description = string.Empty;
            ReBooks = new HashSet<ReBook>();
            PublishDate = DateTime.Now; // 設定預設值
        }

        [Key]
        public int BookId { get; set; }

        [Required(ErrorMessage = "標題是必填的")]
        [StringLength(100, ErrorMessage = "標題不能超過 100 個字元")]
        [Display(Name = "書名")]
        public string Title { get; init; }

        [Required(ErrorMessage = "作者是必填的")]
        [StringLength(50, ErrorMessage = "作者名稱不能超過 50 個字元")]
        [Display(Name = "作者")]
        public string Author { get; init; }

        [DataType(DataType.Date)]
        [Display(Name = "出版日期")]
        public DateTime PublishDate { get; set; }

        [Display(Name = "描述")]
        [DataType(DataType.MultilineText)]
        public string Description { get; init; }

        public virtual ICollection<ReBook> ReBooks { get; init; }
    }
}