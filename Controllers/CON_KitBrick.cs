using System;
using System.Collections.Generic;
using System.Text.Json;
using legos.Models;
using legos.Services;
using Microsoft.AspNetCore.Mvc;

namespace legos.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class KitBricksController : ControllerBase
  {
    private readonly SER_KitBricks _service;

    public KitBricksController(SER_KitBricks service)
    {
      _service = service;
    }

    [HttpPost]
    public ActionResult<KitBrick> Create([FromBody] KitBrick newKitBrick)
    {
      try { return Ok(_service.Create(newKitBrick)); }
      catch (Exception err) { return BadRequest(err.Message); }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try { return Ok(_service.Delete(id) + " rows deleted"); }
      catch (Exception err) { return BadRequest(err.Message); }
    }
  }
}