using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CarCounter.Models;

namespace CarCounter.Controllers
{
    public class SensorReadingsController : ApiController
    {
        private CarCounterContext db = new CarCounterContext();

        // GET: api/SensorReadings
        public IQueryable<SensorReadingsModel> GetSensorReadingsModels()
        {
            return db.SensorReadingsModels;
        }

        // GET: api/SensorReadings/5
        [ResponseType(typeof(SensorReadingsModel))]
        public async Task<IHttpActionResult> GetSensorReadingsModel(int id)
        {
            SensorReadingsModel sensorReadingsModel = await db.SensorReadingsModels.FindAsync(id);
            if (sensorReadingsModel == null)
            {
                return NotFound();
            }

            return Ok(sensorReadingsModel);
        }

        // PUT: api/SensorReadings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSensorReadingsModel(int id, SensorReadingsModel sensorReadingsModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sensorReadingsModel.Id)
            {
                return BadRequest();
            }

            db.Entry(sensorReadingsModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SensorReadingsModelExists(id))
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

        [AuthByApiKey]
        // POST: api/SensorReadings
        [ResponseType(typeof(SensorReadingsModel))]
        public async Task<IHttpActionResult> PostSensorReadingsModel(SensorReadingsModel sensorReadingsModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SensorReadingsModels.Add(sensorReadingsModel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sensorReadingsModel.Id }, sensorReadingsModel);
        }

        // DELETE: api/SensorReadings/5
        [ResponseType(typeof(SensorReadingsModel))]
        public async Task<IHttpActionResult> DeleteSensorReadingsModel(int id)
        {
            SensorReadingsModel sensorReadingsModel = await db.SensorReadingsModels.FindAsync(id);
            if (sensorReadingsModel == null)
            {
                return NotFound();
            }

            db.SensorReadingsModels.Remove(sensorReadingsModel);
            await db.SaveChangesAsync();

            return Ok(sensorReadingsModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SensorReadingsModelExists(int id)
        {
            return db.SensorReadingsModels.Count(e => e.Id == id) > 0;
        }
    }
}