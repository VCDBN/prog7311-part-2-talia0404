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

        // POST: FarmerUsers/Login User
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Farmer farmerUsers)
        {
            connectString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Farmer where Farmer_Username= '" + farmerUsers.FarmerUsername +
                "' and Farmer_Password='" + farmerUsers.FarmerPassword + "'";
            dr = com.ExecuteReader();
            if (dr.Read()) // if statement: if it reads the db, draw the username and password from db and send the user to anoher page
            {
                con.Close();
                return Redirect("https://localhost:44337/FarmerProducts/Create");
            }
            else
            {
                con.Close();
                return Redirect("https://localhost:44337/Home/FailedLogin");
            }
        }



        /*// GET: Farmers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Farmer.ToListAsync());
        }

        // GET: Farmers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmer = await _context.Farmer
                .FirstOrDefaultAsync(m => m.FarmerId == id);
            if (farmer == null)
            {
                return NotFound();
            }

            return View(farmer);
        }*/

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

       /* // GET: Farmers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmer = await _context.Farmer.FindAsync(id);
            if (farmer == null)
            {
                return NotFound();
            }
            return View(farmer);
        }

        // POST: Farmers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FarmerId,FarmerUsername,FarmerPassword")] Farmer farmer)
        {
            if (id != farmer.FarmerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(farmer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FarmerExists(farmer.FarmerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(farmer);
        }

        // GET: Farmers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmer = await _context.Farmer
                .FirstOrDefaultAsync(m => m.FarmerId == id);
            if (farmer == null)
            {
                return NotFound();
            }

            return View(farmer);
        }

        // POST: Farmers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var farmer = await _context.Farmer.FindAsync(id);
            _context.Farmer.Remove(farmer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FarmerExists(int id)
        {
            return _context.Farmer.Any(e => e.FarmerId == id);
        }*/
    }
}
