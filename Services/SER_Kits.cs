using System.Collections.Generic;
using System.Text.Json;
using legos.Models;
using legos.Repositories;

namespace legos.Services
{
  public class SER_Kits
  {
    private readonly REP_Kits _repo;

    public SER_Kits(REP_Kits repo)
    {
      _repo = repo;
    }

    public IEnumerable<Kit> Get()
    {
      return _repo.Get();
    }

    public Kit GetById(int id)
    {
      return _repo.GetById(id);
    }

    public Kit Create(Kit newKit)
    {
      return _repo.Create(newKit);
    }

    public Kit Edit(int id, JsonElement edits)
    {
      Kit editKit = _repo.GetById(id);
      editKit.Edit(edits);
      return _repo.Edit(editKit);
    }

    public int Delete(int id)
    {
      return _repo.Delete(id);
    }
  }
}