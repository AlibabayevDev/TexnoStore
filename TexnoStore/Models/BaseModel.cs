﻿using System;

namespace TexnoStore.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string LognDesc { get; set; }
        public string ShortDesc { get; set; }
        public int Sale { get; set; }
        public double Price { get; set; }
        public double OldPrice { get; set; }
        public string MainImg { get; set; }
        public int ProductType { get; set; }
        public string ProductTypeName { get; set; }
        public int ProductId { get; set; }
        public DateTime AddDate { get; set; }
    }
}
