//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProductAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class Product
    {
        [DisplayName("Product Number")]
        public string Product_Number { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Units On Hand")]
        public int Units_On_Hand { get; set; }

        [DisplayName("Price")]
        public decimal Price { get; set; }
    }
}
