using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductsUI
{
    public partial class Form1 : Form
    {
        /// Product List
        /// </summary>
        private List<Product> productList = new List<Product>();
        /// <summary>
        /// Binding Source for setting the DataGridView's Datasource
        /// </summary>
        BindingSource source = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Add the HttpClient for executing the web API request
            HttpClient client = new HttpClient();

            // Clear the Request Header 
            client.DefaultRequestHeaders.Accept.Clear();

            // Add the Content-Type to the Request Header
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            // The Http client executes asynchronously, but we want to execute this
            // synchronously.  In order to do that, we use the Task.Run/task.Wait.
            var task = Task.Run(() => client.GetAsync("http://localhost:49421/api/Products"));
            task.Wait();

            // We receive the task result which will contain the HTTP Response
            HttpResponseMessage response = task.Result;

            // Check to see if the call was successful.  If not, this will throw an exception.
            response.EnsureSuccessStatusCode();

            // Otherwise, if everything is ok, get the contents of the response, i.e., the response body
            string responseBody = response.Content.ReadAsStringAsync().Result;

            // This response body is a JSON string that we need to deserialize into a List of Products
            productList = (new JavaScriptSerializer()).Deserialize<List<Product>>(responseBody);

            // Now that we have the results as a List of Product, we can use this to create a Binding Source
            source = new BindingSource(productList, null);

            // And assign the binding source as the DataGridView's DataSource
            productsDataGridView.DataSource = source;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (productIDTextBox.Text.Length > 0)
            {
                // Search by Product ID
                var products = productList.Where(p => p.Product_Number == productIDTextBox.Text);

                // Bind the resultant list from the LINQ expression to the binding source
                source = new BindingSource(products, null);
            }
            else if (productDescTextBox.Text.Length > 0)
            {
                // Search by Product Description
                var products = productList.Where(p => p.Description.Contains(productDescTextBox.Text));

                // Bind the resultant list from the LINQ expression to the binding source
                source = new BindingSource(products, null);
            }
            else
            {
                // Show the message
                MessageBox.Show("No Search Condition was entered.");

                // Get out and return prematurely
                return;
            }

            // Update the DataGridView's Datasource
            productsDataGridView.DataSource = source;
        }

        private void sortAscButton_Click(object sender, EventArgs e)
        {
            // Order the List by Product Number.  Default Order is Ascending
            var products = productList.OrderBy(x => x.Product_Number);

            // Update the Binding Source to utilize the resultant list
            source = new BindingSource(products, null);

            // Update the DataGridView's datasource
            productsDataGridView.DataSource = source;
        }

        private void sortDescButton_Click(object sender, EventArgs e)
        {
            // Order the List by Product Number.  Use the OrderByDescending to get list in Descending order.
            var products = productList.OrderByDescending(x => x.Product_Number);

            // Update the Binding Source to utilize the resultant list
            source = new BindingSource(products, null);

            // Update the DataGridView's datasource
            productsDataGridView.DataSource = source;
        }

        private void minPriceButton_Click(object sender, EventArgs e)
        {
            // Get the product(s) that contains the minimum price
            var products = productList.Where(x => x.Price == productList.Min(y => y.Price));

            // Update the Binding Source to utilize the resultant list
            source = new BindingSource(products, null);

            // Update the DataGridView's datasource
            productsDataGridView.DataSource = source;
        }

        private void maxPriceButton_Click(object sender, EventArgs e)
        {
            // Get the product(s) that contains the maximum price
            var products = productList.Where(x => x.Price == productList.Max(y => y.Price));

            // Update the Binding Source to utilize the resultant list
            source = new BindingSource(products, null);

            // Update the DataGridView's datasource
            productsDataGridView.DataSource = source;
        }
    }
}
