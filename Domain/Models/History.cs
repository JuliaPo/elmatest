using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class History
    {
        public virtual Guid Id { get; set; }

        [Required]
        [Display(Name ="Первая переменная")]
        public virtual int X { get; set; }

        [Required]
        [Display(Name = "Первая переменная")]
        public virtual int Y { get; set; }

        [Required]
        [Display(Name = "Результат")]
        public virtual string Operation { get; set; }

        [Required]
        [Display(Name = "Операция")]
        public virtual double Result { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата создания")]
        public virtual DateTime CreationDate { get; set; }

    }
}
