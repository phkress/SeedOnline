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
using Service;

namespace InfTeamApi.Controllers
{
    public class ProfilesController : ApiController
    {
        ProfileService profileService = new ProfileService();

        // GET: api/Profiles
        public IEnumerable<Profile> GetProfiles()
        {
            return profileService.GetProfiles();
        }

        // GET: api/Profiles/5
        [ResponseType(typeof(Profile))]
        public IHttpActionResult GetProfile(String id)
        {
            Profile profile = profileService.GetProfile(id);

            if (profile == null)
            {
                return NotFound();
            }

            return Ok(profile);
        }

        // PUT: api/Profiles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProfile(String id, Profile profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profile.Id)
            {
                return BadRequest();
            }

           
            var result = profileService.UpdateProfile(profile);

            if (result)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return NotFound();
            }            
        }

        // POST: api/Profiles
        [ResponseType(typeof(Profile))]
        public IHttpActionResult PostProfile(Profile profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            profileService.Add(profile);

            return CreatedAtRoute("DefaultApi", new { id = profile.Id }, profile);
        }

        // DELETE: api/Profiles/5
        [ResponseType(typeof(Profile))]
        public IHttpActionResult DeleteProfile(String id)
        {
            Profile profile = profileService.GetProfile(id);

            if (profile == null)
            {
                return NotFound();
            }

            profileService.Delete(profile);
            return Ok(profile);
        }
    }
}