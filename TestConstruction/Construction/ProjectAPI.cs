using TestConstruction.Construction.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConstruction.Construction
{
    public class ProjectAPI
    {
        private HttpClient restclient = new HttpClient();
        private string URI = "localhost:7007/";
        private string project = "GetAllProjectModels";

        public async Task<GetProjectResponse?> GetProject()
        {
            UriBuilder builder = new UriBuilder($"{URI}{project}");
            var response = await restclient.GetAsync(builder.Uri);
            var context = await response.Content.ReadAsStringAsync();

            try
            {
                var responseModel = JsonConvert.DeserializeObject<GetProjectResponse>(context);
                return responseModel;
            }
            catch
            {
                return null;
            }

        }
    }
}
