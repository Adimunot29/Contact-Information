using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Phonebook_webapi.Models;

namespace Phonebook_webapi.Controllers
{
    public class PhoneBookController : ApiController
    {
        private DBModel db = new DBModel();

        // GET api/PhoneBook
        public IQueryable<tblphonebook> Gettblphonebooks()
        {
            return db.tblphonebooks;
        }

        // GET api/PhoneBook/5
        [ResponseType(typeof(tblphonebook))]
        public IHttpActionResult Gettblphonebook(int id)
        {
            tblphonebook tblphonebook = db.tblphonebooks.Find(id);
            if (tblphonebook == null)
            {
                return NotFound();
            }

            return Ok(tblphonebook);
        }

        // PUT api/PhoneBook/5
        public IHttpActionResult Puttblphonebook(int id, tblphonebook tblphonebook)
        {

            if (id != tblphonebook.ContactID)
            {
                return BadRequest();
            }

            db.Entry(tblphonebook).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblphonebookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/PhoneBook
        [ResponseType(typeof(tblphonebook))]
        public IHttpActionResult Posttblphonebook(tblphonebook tblphonebook)
        {

            db.tblphonebooks.Add(tblphonebook);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblphonebook.ContactID }, tblphonebook);
        }

        // DELETE api/PhoneBook/5
        [ResponseType(typeof(tblphonebook))]
        public IHttpActionResult Deletetblphonebook(int id)
        {
            tblphonebook tblphonebook = db.tblphonebooks.Find(id);
            if (tblphonebook == null)
            {
                return NotFound();
            }

            db.tblphonebooks.Remove(tblphonebook);
            db.SaveChanges();

            return Ok(tblphonebook);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblphonebookExists(int id)
        {
            return db.tblphonebooks.Count(e => e.ContactID == id) > 0;
        }
    }
}