using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using JamahaApi.Models;


namespace JamahaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotoController : ControllerBase
    {
      
        [HttpGet]
        public IQueryable Get()
        {
            //return YamahaContext.Modeldatacollections.AsQueryable();
            //return BadRequest(ModelState);
        }

        /// <summary>
        /// Create a new movie
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Modeldatacollection modeldatacollection)
        {
            
                return BadRequest(ModelState);
                   }

        
        [HttpPut("{movieId:int}")]
        public IActionResult Update(int movieId, [FromBody] Modeldatacollection modeldatacollection)
        {
           
                return BadRequest(ModelState);
                }

        [HttpDelete("{movieId:int}")]
        public IActionResult Delete(int movieId)
        {
            
            return NoContent();
        }

    }
}