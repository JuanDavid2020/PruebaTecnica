using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Model
{
    public class Jwt
    {
        public string Key { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string Subject { get; set; }

        public static dynamic validateToken(ClaimsIdentity identity)
        {
            try
            {
                if (identity.Claims.Count() == 0)
                {

                    return new
                    {
                        success = false,
                        message = "token invalido",
                        result = ""
                    };
                }
                var id = identity.Claims.FirstOrDefault(x => x.Type == "id").Value;

                return new
                {
                    success = true,
                    message = "Exito",
                    result = ""
                };

            }
            catch (Exception ex)
            {
                return new
                {
                    success = false,
                    message = "Catch:" + ex.Message,
                    result = ""
                };
            }
        }
    }
}
