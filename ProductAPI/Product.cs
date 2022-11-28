using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ProductAPI
{
    public class Product
    {

        public class Product1
        {
            /// <summary>
            /// Product Number
            /// </summary>
            [DisplayName("Product Number")]
            public string Product_Number { get; set; }

            /// <summary>
            /// Description
            /// </summary>
            [DisplayName("Description")]
            public string Description { get; set; }

            /// <summary>
            /// Units On Hand
            /// </summary>
            [DisplayName("Units On Hand")]
            public int Units_On_Hand { get; set; }

            /// <summary>
            /// Price
            /// </summary>
            [DisplayName("Price")]
            public decimal Price { get; set; }
        }


    }
}