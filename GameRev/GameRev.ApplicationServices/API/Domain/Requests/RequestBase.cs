using Newtonsoft.Json;

namespace GameRev.ApplicationServices.API.Domain.Requests
{
    public class RequestBase
    {
        [JsonIgnore]
        public int AuthenticationIdentifier { get; set; }
        [JsonIgnore]
        public string ?AuthenticationLogin { get; set; }
        [JsonIgnore]
        public string ?AuthenticationUserRole { get; set; }
    }
}
