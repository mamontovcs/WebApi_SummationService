using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace WebApi_Angular.Controllers
{
    public class SummationController : ApiController
    {
        /// <summary>
        /// Service for sessions of summation
        /// </summary>
        private readonly ISummationService _summationService;

        /// <summary>
        /// Creates instance of <see cref="SummationController"/>
        /// </summary>
        /// <param name="summationService">Service for sessions of summation</param>
        public SummationController(ISummationService summationService)
        {
            _summationService = summationService;
        }

        // GET: api/Summation
        public IEnumerable<SummationSessionDTO> Get()
        {
            return _summationService.GetSessions();
        }

        // GET: api/Summation/5
        public SummationSessionDTO Get(int id)
        {
            return _summationService.GetSessionById(id);
        }

        [Route("api/Summation/postSession")]
        [HttpPost]
        public IHttpActionResult PostSession([FromBody]SummationSessionDTO sessionDTO)
        {
            _summationService.AddSession(sessionDTO);
            return Ok();
        }

        [Route("api/Summation/getSum")]
        [HttpPost]
        [ResponseType(typeof(double))]
        public IHttpActionResult GetSum([FromBody]double[] array)
        {
            try
            {
                var sum = _summationService.CalculateSum(array[0], array[1]);
                return Ok(sum);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        // PUT: api/Summation/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Summation/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _summationService.RemoveSessionByID(id);
            return Ok();
        }
    }
}
