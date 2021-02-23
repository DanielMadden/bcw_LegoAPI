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
  public class KitsController : ControllerBase
  {
    private readonly SER_Kits _service;
    private readonly SER_Bricks _brickService;

    public KitsController(SER_Kits service, SER_Bricks brickService)
    {
      _service = service;
      _brickService = brickService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Kit>> Get()
    {
      try { return Ok(_service.Get()); }
      catch (Exception err) { return BadRequest(err.Message); }
    }

    [HttpGet("{id}")]
    public ActionResult<Kit> GetById(int id)
    {
      try { return Ok(_service.GetById(id)); }
      catch (Exception err) { return BadRequest(err.Message); }
    }

    [HttpGet("{id}/bricks")]
    public ActionResult<IEnumerable<Brick>> GetBricks(int id)
    {
      try { return Ok(_brickService.GetByKitId(id)); }
      catch (Exception err) { return BadRequest(err.Message); }
    }

    [HttpPost]
    public ActionResult<Kit> Create([FromBody] Kit newKit)
    {
      try { return Ok(_service.Create(newKit)); }
      catch (Exception err) { return BadRequest(err.Message); }
    }

    [HttpPut("{id}")]
    public ActionResult<Kit> Edit(int id, [FromBody] JsonElement edits)
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