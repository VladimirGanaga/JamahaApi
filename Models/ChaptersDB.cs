using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JamahaApi.Models
{
    public class ChaptersDB
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int ModelsDBID { get; set; }
        public ModelsDB? modelsDB { get; set; }
        public string? partFile { get; set; }
        public string? chapter { get; set; }
        public string? chapterID { get; set; }

    }
}
