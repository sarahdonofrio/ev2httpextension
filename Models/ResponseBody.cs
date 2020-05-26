using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EV2HttpExtension.Models
{
    public class ResponseBody
    {
        // 	Extension instance name
        [DefaultValue("{extensionNamespace}/{extensionType}")]
        public string type { get; set; }

        // Full extension type in format {extensionNamespace}/{extensionType}
        [DefaultValue("{extensionName}")]
        public string name { get; set; }

        // Custom message string (e.g. descriptive free-text progress information)
        [Required]
        public string message { get; set; }

        // Execution state of the extension : succeeded/failed/canceled
        [DefaultValue("running")]
        public string state { get; set; }

        // 	Extension's output in json format (can be a complex json object)
        public JObject outputs { get; set; }
    }
}
