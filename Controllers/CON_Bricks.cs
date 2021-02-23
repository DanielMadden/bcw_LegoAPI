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
  public class BricksController : ControllerBase
  {
    private readonly SER_Bricks _service;

    public BricksController(SER_Bricks service)
    {
      _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Brick>> Get()
    {
      try { return Ok(_service.Get()); }
      catch (Exception err) { return BadRequest(err.Message); }
    }

    [HttpGet("{id}")]
    public ActionResult<Brick> GetById(int id)
    {
      try { return Ok(_service.GetById(id)); }
      catch (Exception err) { return BadRequest(err.Message); }
    }

    [HttpPost]
    public ActionResult<Brick> Create([FromBody] Brick newBrick)
    {
      try { return Ok(_service.Create(newBrick)); }
      catch (Exception err) { return BadRequest(err.Message); }
    }

    [HttpPut("{id}")]
    public ActionResult<Brick> Edit(int id, [FromBody] JsonElement edits)
    {
      try { return Ok(_service.Edit(id, edits)); }
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