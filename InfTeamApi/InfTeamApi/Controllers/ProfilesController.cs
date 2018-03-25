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
using Model;
using Repository.Persistence;
using Repository;

namespace InfTeamApi.Controllers
{
    public class ProfilesController : ApiController
    {
        ModelUOW db = new ModelUOW(new InfTeamApiDBContext());

        // GET: api/Profiles
        public IEnumerable<Profile> GetProfiles()
        {
            return db.Profiles.GetAll();
        }

        // GET: api/Profiles/5
        [ResponseType(typeof(Profile))]
        public IHttpActionResult GetProfile(int id)
        {
            Profile profile = db.Profiles.get(id);
            if (profile == null)
            {
                return NotFound();
            }

            return Ok(profile);
        }

        // PUT: api/Profiles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProfile(int id, Profile profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profile.Id)
            {
                return BadRequest();
            }

            db.Profiles.Update(profile);

            try
            {
                db.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Profiles
        [ResponseType(typeof(Profile))]
        public IHttpActionResult PostProfile(Profile profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Profiles.Add(profile);
            db.Complete();

            return CreatedAtRoute("DefaultApi", new { id = profile.Id }, profile);
        }

        // DELETE: api/Profiles/5
        [ResponseType(typeof(Profile))]
        public IHttpActionResult DeleteProfile(int id)
        {
            Profile profile = db.Profiles.get(id);
            if (profile == null)
            {
                return NotFound();
            }

            db.Profiles.Remove(profile);
            db.Complete();

            return Ok(profile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}