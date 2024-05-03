using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RealEstateProject.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
