using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.ApiClient.Models.ApiModels
{
    public class Product
    {

        public int Id { get; set; }

        public string? ProductName { get; set; }
        public string? ProductCode { get; set; }
        public decimal Price  { get; set; }

    }
}
