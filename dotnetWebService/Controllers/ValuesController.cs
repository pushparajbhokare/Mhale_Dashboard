using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace New_project
{
    
    [ApiController]
    public class ValuesController : ControllerBase
    {

        //[Route("DashboardLevel3/All")]
        [HttpGet]
        public string GetLevel3DashboardData()
        {
            return "Response from GetLevel3DashboardData Method";
        }
    }
}













