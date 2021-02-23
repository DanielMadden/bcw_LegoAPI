using System.Collections.Generic;
using System.Text.Json;
using legos.Models;
using legos.Repositories;

namespace legos.Services
{
  public class SER_Bricks
  {
    private readonly REP_Bricks _repo;

    public SER_Bricks(REP_Bricks repo)
    {
      _repo = repo;
    }

    public IEnumerable<Brick> Get()
    {
      return _repo.Get();
    }

    public Brick GetById(int id)
    {
      return _repo.GetById(id);
    }

    public IEnumerable<Brick> GetByKitId(int kitId)
    {
      return _repo.GetByKitId(kitId);
    }

    public Brick Create(Brick newBrick)
    {
      newBrick.Name = newBrick.StudWidth + "x" + newBrick.StudHeight;
      return _repo.Create(newBrick);
    }

    public Brick Edit(int id, JsonElement edits)
    {
      Brick editBrick = _repo.GetById(id);
      editBrick.Edit(edits);
      return _repo.Edit(editBrick);
    }

    public int Delete(int id)
    {
      return _repo.Delete(id);
    }
  }
}