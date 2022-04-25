﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiBarApp.Data.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Guid ProductId { get; set; }
        public string Sentiment { get; set; } = null;
    }
}
