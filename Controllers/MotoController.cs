using Microsoft.AspNetCore.Mvc;
using JamahaApi.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Collections.Immutable;
using JamahaApi.Models;

namespace JamahaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotoController : ControllerBase
    {

        


        [HttpGet]
        public string Get(string ModelName, string ChapterID)
        {
            var jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            
            var chapterID = int.Parse(ChapterID);
            string answer = "{";
            int count = 0;
            YamahaContext contextModels = new YamahaContext();
            List<PartsDB> chekListParts = new List<PartsDB>();
            
            var desiredModelsFromBase = contextModels.ModelDB.Where(dm => dm.modelName == ModelName);
            foreach (ModelsDB dm in desiredModelsFromBase)
            {
                YamahaContext contextChapter = new YamahaContext();
                answer += $"\"ModelID{dm.Id}\": "+ JsonConvert.SerializeObject(dm, jsonSettings)+",";

                var ChapterFromBase = contextChapter.ChapterDB.Where(cfb => cfb.ModelsDBID == dm.Id && cfb.chapterID == String.Format("{0:D2}", chapterID));
                foreach (var chapters in ChapterFromBase)
                {
                    answer += $"\"chapterID{chapters.Id}\": " + JsonConvert.SerializeObject(chapters, jsonSettings) + ",";
                    YamahaContext contextParts = new YamahaContext();
                    var partsFromBase = contextParts.PartDB.Where(pfb => pfb.chapterID == chapters.Id );
                    foreach (var parts in partsFromBase)
                    {
                        chekListParts.Add(parts);
                        count++;
                    }
                    contextParts.Dispose();
                    answer += $"\"partsForChapterID{chapters.Id}\": " + JsonConvert.SerializeObject(chekListParts, jsonSettings) + ",";
                    chekListParts.Clear();
                }
                contextChapter.Dispose();

            }
            contextModels.Dispose();
            answer += $"\"totalPartsInList\": {count}}}";


           //var answer = JsonConvert.SerializeObject(chekListParts, jsonSettings);


            if ((string.IsNullOrEmpty(answer.ToString())) || (answer.ToString() == "[]"))
            {
                return "Model not found";
            }
            return answer.ToString();


        }




        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] Modeldatacollection modeldatacollection)
        //{

        //    return BadRequest(ModelState);
        //}


        //[HttpPut("{ModelID:int}")]
        //public IActionResult Update(int ModelID, [FromBody] Modeldatacollection modeldatacollection)
        //{

        //    return BadRequest(ModelState);
        //}

        //[HttpDelete("{ModelID:int}")]
        //public IActionResult Delete(int ModelID)
        //{

        //    return NoContent();
        //}

    }
}