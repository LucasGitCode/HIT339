using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ass1.Data;
using Ass1.Models;
using System.Net.Mail;
using System.Text;




namespace Ass1.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly Ass1Context _context;
        public int sID;
        public string fName;

        public InvoicesController(Ass1Context context)
        {
            _context = context;
        }

        // GET: Search Invoices
        public async Task<IActionResult> Index(string searchString)
        {
            var Invoices = from s in _context.Invoice
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                Invoices = Invoices.Where(s => s.AccName.Contains(searchString));
            }

            return View(await Invoices.ToListAsync());
        }

        // GET: Invoices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inv = _context.Invoice.Find(id);
            fName = inv.AccName;

            fName = _context.Student
                    .Where(s => s.Id == 1)
                    .Select(s => s.FirstName)
                    .FirstOrDefault();

            if (fName == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice
                .FirstOrDefaultAsync(m => m.Id == id);

            if (invoice == null)
            {
                return NotFound();
            }

            fName = fName.Trim();

            return View(invoice);
        }

        // GET: Invoices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BankId,AccName,BSBNo,AccNo,Cost")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invoice);
        }

        // GET: Invoices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BankId,AccName,BSBNo,AccNo,Cost")] Invoice invoice)
        {
            if (id != invoice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceExists(invoice.Id))
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
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoice = await _context.Invoice.FindAsync(id);
            _context.Invoice.Remove(invoice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceExists(int id)
        {
            return _context.Invoice.Any(e => e.Id == id);
        }

        public async Task<IActionResult> SendInvoice(int? id)
        {
            {
                var invoice = await _context.Invoice
                .FirstOrDefaultAsync(m => m.Id == sID);

                string bank = _context.Invoice
                    .Where(s => s.Id == id)
                    .Select(s => s.BankId)
                    .SingleOrDefault();

                string emailQuery = _context.Student
                    .Where(s => s.Id == id)
                    .Select(s => s.ContactEmail)
                    .SingleOrDefault();

                string accName = _context.Invoice
                    .Where(s => s.Id == id)
                    .Select(s => s.AccName)
                    .SingleOrDefault();

                int BSB = _context.Invoice
                    .Where(s => s.Id == id)
                    .Select(s => s.BSBNo)
                    .SingleOrDefault();

                int accNo = _context.Invoice
                    .Where(s => s.Id == id)
                    .Select(s => s.AccNo)
                    .SingleOrDefault();

                decimal cost = _context.Invoice
                    .Where(s => s.Id == id)
                    .Select(s => s.Cost)
                    .SingleOrDefault();

                Console.WriteLine("Hello");
                

                //string to = emailQuery; //To address    
                //string from = "HIT339TEST@gmail.com"; //From address    
                //MailMessage message = new MailMessage(from, to);

                MailAddress addressFrom = new MailAddress("HIT339TEST@gmail.com", "Ass1 App");
                MailAddress addressTo = new MailAddress(emailQuery);
                MailMessage message = new MailMessage(addressFrom, addressTo);

                string mailbody = "Dear " + accName +
                    "        <br>" +
                    "        Welcome to all existing students and new students.Semester 2 will commence from Date" +
                    "        Please ensure your payment is finalised by payment_finaldate" +
                    "        If a student is no longer attending" +
                    "        lessons, please email the CYCM to be removed off the email list." +
                    "        If paying by Bank Transfer - EFT, please forward a copy of your payment to the office, to follow up" +
                    "        and allocate to the student. <br> " +
                    
                    "        <br>BANK:                "+bank+"<br>                   " +
                             
                    "        <br>ACCOUNT NAME:        "+accName+"<br>                " +

                    "        <br>BSB NUMBER:          "+BSB+"<br>                    " +

                    "        <br>ACCOUNT NUMBER:      "+accNo+"<br>                  " +

                    "        <br>COST:                "+cost+"<br>                   " +

                    "        <br>Please follow hyperlink<br>" +
                    "        http://webpay.cdu.edu.au/musicschool/tran-type=006&REFNO=reference_number&CUSTNAME=lastname_firstname&PARENTSNAME=parents_name&UNITAMOUNTINCTAX=amount" +
                    "        Apply for your sport Vouchers for term @Html.DisplayFor(model => model.Term) and before @Html.DisplayFor(model => model.Date)<br> <br>please visit the hyperlink http://www.sportvoucher.nt.gov.au, as schhols are no longer providing students with sport vouchers.";


                
                message.Subject = "Check it out!";
                message.Body = mailbody;
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
                System.Net.NetworkCredential basicCredential1 = new
                System.Net.NetworkCredential("HIT339TEST@gmail.com", "PassWord01");
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = basicCredential1;

                try
                {
                    client.Send(message);
                }

                catch (Exception ex)
                {
                    throw ex;
                }

            }
            return RedirectToAction(nameof(Index));
        }
    }   
}
