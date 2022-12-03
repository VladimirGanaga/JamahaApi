using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JamahaApi.Models
{
    public class PartsDB
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int chapterID { get; set; }
        public ChaptersDB? chapterDB { get; set; }
        public string partNo { get; set; }
        public string partName { get; set; }
        public int quantity { get; set; }
        public string? refNo { get; set; }

    }
}
