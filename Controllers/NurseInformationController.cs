using Microsoft.AspNetCore.Mvc;
using capstone_backend.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace capstone_backend.Controllers
{
  [ApiController]
  [EnableCors]
  [Route("api/[controller]")]
  public class NurseInformationController : ControllerBase
  {

    static DatabaseContext Db = new DatabaseContext();

    [HttpPost]

    public ActionResult PostNurseInformation(Nurse newNurse)
    {
      Db.Nurse.Add(newNurse);
      Db.SaveChanges();
      Email.SendEmail(newNurse);
      return Ok(newNurse);
    }

    [HttpGet("All")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public ActionResult GetAllNurses()
    {
      return Ok(Db.Nurse);
    }
    [HttpGet("{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public ActionResult GetANurse(int id)
    {
      var nurse = Db.Nurse.FirstOrDefault(theId => theId.Id == id);
      if (id != 0)
      {
        return Ok(nurse);
      }
      else
      {
        return NotFound();
      }
    }


  }
}