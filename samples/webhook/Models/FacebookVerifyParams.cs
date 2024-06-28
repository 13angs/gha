using Microsoft.AspNetCore.Mvc;

namespace webhook.Models
{
    public class FacebookVerifyParams
    {
        [FromQuery(Name = "mode")]
        public virtual string? Mode { get; set; }
        
        [FromQuery(Name = "challenge")]
        public virtual long? Challenge { get; set; }

        [FromQuery(Name = "verify_token")]
        public virtual string? VerifyToken { get; set; }
    }
}