using System.Collections.Generic;
using System.Data;
using Dapper;
using legos.Models;

namespace legos.Repositories
{
  public class REP_KitBricks
  {
    public readonly IDbConnection _db;

    public REP_KitBricks(IDbConnection db)
    {
      _db = db;
    }

    public KitBrick Create(KitBrick newKitBrick)
    {
      string sql = @"
      INSERT INTO kitBricks
      (kitId, brickId)
      VALUES
      (@KitId, @BrickId);
      SELECT LAST_INSERT_ID()";
      newKitBrick.Id = _db.ExecuteScalar<int>(sql, newKitBrick);
      return newKitBrick;
    }

    public int Delete(int id)
    {
      string sql = "DELETE FROM kitBricks WHERE id = @id";
      return _db.Execute(sql, new { id });
    }
  }
}