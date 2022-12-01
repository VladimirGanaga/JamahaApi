using Microsoft.AspNetCore.Mvc;
using JamahaApi.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Collections.Immutable;

namespace JamahaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotoController : ControllerBase
    {

        YamahaContext context=new YamahaContext();


        [HttpGet]
        public string Get(string ModelName, string ChapterID)
        {
            var chapterID = ChapterID;
            if (int.Parse(ChapterID) < 10)
            {
                chapterID = "0" + ChapterID;
            }

            List <List<Partsdatacollection>> chekListAll = new List<List<Partsdatacollection>>();
            YamahaContext ctx = new YamahaContext();
            var desiredModelsFromBase = ctx.Modeldatacollection.Where(dm => dm.ModelName == ModelName);
            foreach (Modeldatacollection dm in desiredModelsFromBase)
            {
                List<Partsdatacollection> chekList = new List<Partsdatacollection>();
                var PartsFromBase = context.Partsdatacollection.Where(pfb => pfb.ModeldatacollectionId == dm.Id && pfb.chapterID == chapterID);
                foreach (var part in PartsFromBase)
                {
                    chekList.Add(part);

                }
                chekListAll.Add(chekList);

            }

            var jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            var answer = JsonConvert.SerializeObject(chekListAll, jsonSettings);
            

            if ((string.IsNullOrEmpty(answer.ToString())) || (answer.ToString()=="[]"))
            {
                return "Model not found";
            }
            return answer.ToString();

            
        }
        



        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Modeldatacollection modeldatacollection)
        {
            
                return BadRequest(ModelState);
                   }

        
        [HttpPut("{ModelID:int}")]
        public IActionResult Update(int ModelID, [FromBody] Modeldatacollection modeldatacollection)
        {
           
                return BadRequest(ModelState);
                }

        [HttpDelete("{ModelID:int}")]
        public IActionResult Delete(int ModelID)
        {
            
            return NoContent();
        }

    }
}