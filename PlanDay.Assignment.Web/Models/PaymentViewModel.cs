using PlanDay.Assignment.Core.Payment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlanDay.Assignment.Web.Models
{
    public class PaymentViewModel
    {
        public string Description { get; set; }

        [Required]
        public PaymentStatus Status { get; set; }

        [Required]
        public int? ProductId { get; set; }

        [Required]
        public int ProductTagId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }
    }
}