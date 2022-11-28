using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ProductAPI.Controllers
{
    public class HomeController : Controller
    {


        /// <summary>
        /// Web API Address
        /// </summary>
        private string baseAddress = "http://localhost:44355/api/";

        // GET: Home
        public ActionResult Index()
        {
            // Define the products
            IEnumerable<Models.Product> products = null;

            // Define the HttpClient that will be used for making the HTTP GET request
            using (var client = new HttpClient())
            {
                // Assign the Base URL
                client.BaseAddress = new Uri(baseAddress);

                //Append "Products" to the base URL to make the Web API Request.
                var responseTask = client.GetAsync("Products");

                // Wait for the Task to complete 
                responseTask.Wait();

                // Get the Response
                var result = responseTask.Result;

                // If the Request was successful
                if (result.IsSuccessStatusCode)
                {
                    // Get the Response
                    var readTask = result.Content.ReadAsAsync<IList<Models.Product>>();
                    readTask.Wait();

                    // Update the IEnumerable list
                    products = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    products = Enumerable.Empty<Models.Product>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            // Return the "Index" view with the Products information
            return View(products);
        }
        // GET: Home/Delete/5
        /// <summary>
        /// Returns the Delete View with information about the Product specified based
        /// on the Product Number passed in
        /// </summary>
        /// <param name="id">Product Number - Unique ID for the Product</param>
        /// <returns>The "DELETE" View with the Product Information</returns>
        public ActionResult Delete(string id)
        {
            // Return the "Delete" view with the Product's information
            return View(GetProduct(id));
        }

        /// <summary>
        /// Removes the designated product from the database
        /// </summary>
        /// <param name="id">Product Number which is the unique id for the Product</param>
        /// <returns>Returns the "Index" view if the delete was successful or the 
        /// "Delete" view if the delete was not successful.</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            // Define the HttpClient that will be used for making the HTTP GET request
            using (var client = new HttpClient())
            {
                // Assign the Base URL
                client.BaseAddress = new Uri(baseAddress);

                // Append "Products" to the base URL as well as the product Id
                // to make the Web API Request (HTTP DELETE).
                var deleteTask = client.DeleteAsync($"Products/{id}");

                // Wait for the Task to complete 
                deleteTask.Wait();

                // Get the result
                var result = deleteTask.Result;

                // Redirect to the "Index" page because the Product was successfully deleted
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            // Otherwise set the error
            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            // Redisplay the "Delete" page with the Product data.
            return View(id);
        }




        // GET: Home/Details/5
        /// <summary>
        /// Retrieves a product and displays its details. 
        /// </summary>
        /// <param name="id">Product Number which is the Product's unique ID</param>
        /// <returns>The Details View for the designated Product</returns>
        public ActionResult Details(string id)
        {
            // Return the "Details" view with the Product's information
            return View(GetProduct(id));
        }

        /// <summary>
        /// Private Helper Method that executes the web API call for a given product number
        /// and returns the associated Product Object Instance from the database
        /// </summary>
        /// <param name="id">Product Number which is the unique identifier for a Product</param>
        /// <returns>Product Object Instance</returns>
        private Models.Product GetProduct(string id)
        {
            // Declare and instance of a product and give it an initial value
            Models.Product product = null;

            // Define the HttpClient that will be used for making the HTTP GET request
            using (var client = new HttpClient())
            {
                // Assign the Base URL
                client.BaseAddress = new Uri(baseAddress);

                //Append "Products" and the Product's Id to the base URL to make the Web API Request.
                var responseTask = client.GetAsync("products?id=" + id.ToString());

                // Wait for the Task to complete 
                responseTask.Wait();

                // Get the Response
                var result = responseTask.Result;

                // If the Request was successful
                if (result.IsSuccessStatusCode)
                {

                    // Get the Response
                    var readTask = result.Content.ReadAsAsync<Models.Product>();
                    readTask.Wait();

                    // Update the Product Reference
                    product = readTask.Result;
                }
            }

            return product;
        }


        /// <summary>
        /// Processes the Creation of the Product in the database when the "Create"
        /// button is pressed.
        /// </summary>
        /// <param name="product">The form field data rendered as a Product</param>
        /// <returns>The resultant view.  In the case of some type of unexpected error, 
        /// the "Create" view will be returned.  If the create succeeds, the "Index" view will
        /// be returned.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.Product product)
        {

            // Define the HttpClient that will be used for making the HTTP GET request
            using (var client = new HttpClient())
            {
                // Assign the Base URL
                client.BaseAddress = new Uri(baseAddress);

                //Append "Products" to the base URL to make the Web API Request (HTTP POST).
                var postTask = client.PostAsJsonAsync<Models.Product>("Products", product);

                // Wait for the Task to complete 
                postTask.Wait();

                // Get the result
                var result = postTask.Result;

                // If the Request was successful
                if (result.IsSuccessStatusCode)
                {
                    // Redirect to the "Index" page because the Product was successfully created
                    return RedirectToAction("Index");
                }
            }

            // Otherwise set the error
            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            // Redisplay the "Create" page with the Product data that was entered.
            return View(product);
        }
        // GET: Home/Edit/5
        /// <summary>
        /// Retrieves a Product from the database using the web API and displays the information
        /// using the Edit view.
        /// </summary>
        /// <param name="id">Product Number which is the unique Identifier for a Product</param>
        /// <returns>The Edit view for the given product</returns>
        public ActionResult Edit(string id)
        {
            // Return the "Edit" view with the Product's information
            return View(GetProduct(id));
        }

        /// <summary>
        /// Updates the database for a given Product.
        /// </summary>
        /// <param name="product">The Product instance containing updated data</param>
        /// <returns>Returns the "index" view if the update was successful or the 
        /// "Edit" view if the update was not successful.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.Product product)
        {
            try
            {
                // Define the HttpClient that will be used for making the HTTP GET request
                using (var client = new HttpClient())
                {
                    // Assign the Base URL
                    client.BaseAddress = new Uri(baseAddress);

                    //Append "Products" to the base URL to make the Web API Request (HTTP PUT).
                    var putTask = client.PutAsJsonAsync<Models.Product>($"Products/{product.Product_Number}", product);

                    // Wait for the Task to complete 
                    putTask.Wait();

                    // Get the result
                    var result = putTask.Result;

                    // If the Request was successful
                    if (result.IsSuccessStatusCode)
                    {
                        // Redirect to the "Index" page because the Product was successfully updated
                        return RedirectToAction("Index");
                    }
                }
                // Otherwise set the error
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                // Redisplay the "Edit" page with the Product data that was updated.
                return View(product);
            }
            catch (Exception ex)
            {
                // Otherwise set the error
                ModelState.AddModelError(string.Empty, ex.Message);

                // Redisplay the "Edit" page with the Product data that was updated.
                return View(product);
            }
        }
        // GET: Home/Details/5
        public ActionResult Details(int id)
            {
                return View();
            }

            // GET: Home/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: Home/Create
            [HttpPost]
            public ActionResult Create(FormCollection collection)
            {
                try
                {
                    // TODO: Add insert logic here

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }

            // GET: Home/Edit/5
            public ActionResult Edit(int id)
            {
                return View();
            }

            // POST: Home/Edit/5
            [HttpPost]
            public ActionResult Edit(int id, FormCollection collection)
            {
                try
                {
                    // TODO: Add update logic here

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }

            // GET: Home/Delete/5
            public ActionResult Delete(int id)
            {
                return View();
            }

            // POST: Home/Delete/5
            [HttpPost]
            public ActionResult Delete(int id, FormCollection collection)
            {
                try
                {
                    // TODO: Add delete logic here

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
        }
    }

