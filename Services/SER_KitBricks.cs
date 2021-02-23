using System.Collections.Generic;
using legos.Models;
using legos.Repositories;

namespace legos.Services
{
  public class SER_KitBricks
  {
    private readonly REP_KitBricks _repo;

    public SER_KitBricks(REP_KitBricks repo)
    {
      _repo = repo;
    }

    public KitBrick Create(KitBrick newKitBrick)
    {
      return _repo.Create(newKitBrick);
    }

    public int Delete(int id)
    {
      return _repo.Delete(id);
    }
  }
}