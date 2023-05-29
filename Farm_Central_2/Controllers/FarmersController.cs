using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Farm_Central_2.Models;
using Microsoft.Data.SqlClient;

namespace Farm_Central_2.Controllers
{
    public class FarmersController : Controller
    {
        private readonly PROG_2023Context _context;

        public FarmersController(PROG_2023Context context)
        {
            _context = context;
        }

        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        void connectString()
        {
            con.ConnectionString = "Data Source=lab000000\\SQLEXPRESS;Initial Catalog=PROG_2023;Integrated Security=True";
        }

        // GET: FarmerUsers/Login User
        public IActionResult Login()
        {

            return View();   
            
        }

        //Farmer Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Farmer farmerUsers)
        {
            connectString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Farmer where Farmer_Username = '" + farmerUsers.FarmerUsername +
                "' and Farmer_Password ='" + farmerUsers.FarmerPassword + "'";
            dr = com.ExecuteReader();
            if (dr.Read()) 
                
                //If the username and password matches with database then the user will be directed to new page
            /*site Name: Complete Login And Registration System In ASP.NET MVC Application With Database Connection
             * C# Corner
             * url: https://www.c-sharpcorner.com/article/simple-login-and-registration-form-in-asp-net-mvc-using-ado-net/
             */

            {
                con.Close();
                return Redirect("https://localhost:44337/FarmerProducts/Create");
            }
            else
            {
                con.Close();
                return Redirect("https://localhost:44337/FarmerProducts/Create");
            }
        }



      

        // GET: Farmers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Farmers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FarmerId,FarmerUsername,FarmerPassword")] Farmer farmer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(farmer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(farmer);
        }

       
    }
}
