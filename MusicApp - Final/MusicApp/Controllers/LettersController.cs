using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicApp.Data;
using MusicApp.Models;
using System.Net.Mail;
using System.Text;

namespace MusicApp.Controllers
{
    public class LettersController : Controller
    {
        private readonly MusicAppContext _context;
        public int sID;
        public string fName;

        public LettersController(MusicAppContext context)
        {
            _context = context;
        }

        // GET: Letters
        public async Task<IActionResult> Index(string searchString)
        {
            var musicAppContext = from l in _context.Letters.Include(l => l.LessonDT).Include(l => l.LessonTY).Include(l => l.Students)
                                  select l;

            if (!string.IsNullOrEmpty(searchString))
            {
                musicAppContext = musicAppContext.Where(l => l.AccName.Contains(searchString));
            }
            return View(await musicAppContext.ToListAsync());
        }

        // GET: Letters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var letters = await _context.Letters
                .Include(l => l.LessonDT)
                .Include(l => l.LessonTY)
                .Include(l => l.Students)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (letters == null)
            {
                return NotFound();
            }

            var letter = _context.Letters.Find(id);
            fName = letter.Students.FullName;

            fName = _context.Students
                .Where(s => s.Id == 1)
                .Select(s => s.FullName)
                .FirstOrDefault();

            if (fName == null)
            {
                return NotFound();
            }

            fName = fName.Trim();
            return View(letters);
        }

        // GET: Letters/Create
        public IActionResult Create()
        {
            ViewData["LessonDTId"] = new SelectList(_context.LessonDT, "Id", "StartDate");
            ViewData["LessonTYId"] = new SelectList(_context.LessonTY, "Id", "Term");
            ViewData["StudentsId"] = new SelectList(_context.Students, "Id", "FullName");
            ViewData["Semester"] = new SelectList(Enum.GetValues(typeof(Letters.SemesterType)));
            return View();
        }

        // POST: Letters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentsId,LessonTYId,LessonDTId,Semester,BankId,AccName,BSBNo,AccNo,Cost,Paid,Signature")] Letters letters)
        {
            if (ModelState.IsValid)
            {
                _context.Add(letters);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LessonDTId"] = new SelectList(_context.LessonDT, "Id", "StartDate", letters.LessonDTId);
            ViewData["LessonTYId"] = new SelectList(_context.LessonTY, "Id", "Term", letters.LessonTYId);
            ViewData["StudentsId"] = new SelectList(_context.Students, "Id", "FullName", letters.StudentsId);
            ViewData["Semester"] = new SelectList(Enum.GetValues(typeof(Letters.SemesterType)));
            return View(letters);
        }

        // GET: Letters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var letters = await _context.Letters.FindAsync(id);
            if (letters == null)
            {
                return NotFound();
            }
            ViewData["LessonDTId"] = new SelectList(_context.LessonDT, "Id", "StartDate", letters.LessonDTId);
            ViewData["LessonTYId"] = new SelectList(_context.LessonTY, "Id", "Term", letters.LessonTYId);
            ViewData["StudentsId"] = new SelectList(_context.Students, "Id", "FullName", letters.StudentsId);
            ViewData["Semester"] = new SelectList(Enum.GetValues(typeof(Letters.SemesterType)));
            return View(letters);
        }

        // POST: Letters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentsId,LessonTYId,LessonDTId,Semester,BankId,AccName,BSBNo,AccNo,Cost,Paid,Signature")] Letters letters)
        {
            if (id != letters.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(letters);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LettersExists(letters.Id))
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
            ViewData["LessonDTId"] = new SelectList(_context.LessonDT, "Id", "StartDate", letters.LessonDTId);
            ViewData["LessonTYId"] = new SelectList(_context.LessonTY, "Id", "Term", letters.LessonTYId);           
            ViewData["StudentsId"] = new SelectList(_context.Students, "Id", "FullName", letters.StudentsId);
            ViewData["Semester"] = new SelectList(Enum.GetValues(typeof(Letters.SemesterType)));
            return View(letters);
        }

        // GET: Letters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var letters = await _context.Letters
                .Include(l => l.LessonDT)
                .Include(l => l.LessonTY)
                .Include(l => l.Students)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (letters == null)
            {
                return NotFound();
            }

            return View(letters);
        }

        // POST: Letters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var letters = await _context.Letters.FindAsync(id);
            _context.Letters.Remove(letters);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LettersExists(int id)
        {
            return _context.Letters.Any(e => e.Id == id);
        }
        //POST: Letters/Send/S
        public async Task<IActionResult> Send(int? id)
        {
            {
                var invoice = await _context.Letters
                .FirstOrDefaultAsync(m => m.Id == sID);

                string Students = _context.Students
                    .Where(s => s.Id == id)
                    .Select(s => s.FullName)
                    .SingleOrDefault();

                var Term = _context.LessonTY
                    .Where(s => s.Id == id)
                    .Select(s => s.Term)
                    .SingleOrDefault();

                var Year = _context.LessonTY
                   .Where(s => s.Id == id)
                   .Select(s => s.Year)
                   .SingleOrDefault();

                var Semester = _context.Letters
                   .Where(s => s.Id == id)
                   .Select(s => s.Semester)
                   .SingleOrDefault();

                var StartDate = _context.LessonDT
                    .Where(s => s.Id == id)
                    .Select(s => s.StartDate)
                    .SingleOrDefault();

                var EndDate = _context.LessonDT
                    .Where(s => s.Id == id)
                    .Select(s => s.EndDate)
                    .SingleOrDefault();

                Decimal Cost = _context.Letters
                    .Where(s => s.Id == id)
                    .Select(s => s.Cost)
                    .SingleOrDefault();

                string Bank = _context.Letters
                    .Where(s => s.Id == id)
                    .Select(s => s.BankId)
                    .SingleOrDefault();

                string emailQuery = _context.Students
                    .Where(s => s.Id == id)
                    .Select(s => s.ContactEmail)
                    .SingleOrDefault();

                string AccName = _context.Letters
                    .Where(s => s.Id == id)
                    .Select(s => s.AccName)
                    .SingleOrDefault();

                int BSB = _context.Letters
                    .Where(s => s.Id == id)
                    .Select(s => s.BSBNo)
                    .SingleOrDefault();

                int AccNo = _context.Letters
                    .Where(s => s.Id == id)
                    .Select(s => s.AccNo)
                    .SingleOrDefault();

                string Signature = _context.Letters
                    .Where(s => s.Id == id)
                    .Select(s => s.Signature)
                    .SingleOrDefault();

                Console.WriteLine("Hello");


                //string to = emailQuery; //To address    
                //string from = "HIT339TEST@gmail.com"; //From address    
                //MailMessage message = new MailMessage(from, to);

                MailAddress addressFrom = new MailAddress("HIT339TEST@gmail.com", "CDU Music School");
                MailAddress addressTo = new MailAddress(emailQuery);
                MailMessage message = new MailMessage(addressFrom, addressTo);

                string mailbody =
                   "<p> Dear " + Students + "," + "</p>" +
                   "<p> Welcome to all existing students and new students." + Term + " will commence from " + StartDate + "</p>" +
                   "<p> Please ensure your payment is finalised by " + EndDate + "." + " If a student is no longer attending lessons, please email the CYCM to be removed off the email list. </p>" +
                   "<p> If paying by Bank Transfer - EFT, please forward a copy of your payment to the office, to follow up" + " and allocate to the student. </p> " +

                   "<p> Payment Details: </p>" +
                   "<p> Ref#: REFERNCE NUMBER" +
                   "<p> Student: " + Students + "</p>" +
                   "<p> Amount: $" + Cost + "</p>" +

                   "<p> Please follow http://webpay.cdu.edu.au/musicschool/tran-type=006&REFNO=reference_number&CUSTNAME=lastname_firstname&PARENTSNAME=parents_name&UNITAMOUNTINCTAX=amount to make payment for " + Term + ", " + Year + " </p>" +
                   "<p> Apply for your sport voucehr for" + Semester + "," + "please visit http://www.sportvoucher.nt.gov.au" + "," + " as schools are no longer providing students with sports vouchers. </p>" +

                   "<p> *Alternatively pay via Bank Transfer - EFT - CDU bank details, delete old bank details:* </p>" +

                   "<p> Bank: " + Bank + "</p>" +
                   "<p> Account Name: " + AccName + "</p>" +
                   "<p> BSB Number: " + BSB + "<p>" +
                   "<p> Account Number: " + AccNo + "<p>" +
                   "<p> Cost: $" + Cost + "<p>" +

                   "<p> Reference number - please inlclude 'CYCM, Reference number and student name'</p>" +
                   "<p> The CYCM is committed to providing students with quality lessons in a positive learning environment</p>" +
                   
                   "<p> Regards,</p>" +
                   "<p>" + Signature + "</p>";


                message.Subject = "Payment Receipt";
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

                catch (Exception)
                {
                    throw;
                }

            }
            return RedirectToAction(nameof(Index));
        }

    }
}
