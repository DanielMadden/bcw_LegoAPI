using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using legos.Models;

namespace legos.Repositories
{
  public class REP_Bricks
  {
    public readonly IDbConnection _db;

    public REP_Bricks(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Brick> Get()
    {
      string sql = "SELECT * FROM bricks";
      return _db.Query<Brick>(sql);
    }

    public Brick GetById(int id)
    {
      string sql = "SELECT * FROM bricks WHERE id = @id";
      return _db.QueryFirstOrDefault<Brick>(sql, new { id });
    }

    internal IEnumerable<Brick> GetByKitId(int kitId)
    {
      string sql = @"
      SELECT b.*,
      kb.id as KitBrickId
      FROM kitBricks kb
      JOIN bricks b ON b.id = kb.brickId
      WHERE kitId = @kitId";
      return _db.Query<KitBrickViewModel>(sql, new { kitId });
    }

    public Brick Create(Brick newBrick)
    {
      string sql = @"
      INSERT INTO bricks
      (name, color, studWidth, studHeight)
      VALUES
      (@Name, @Color, @StudWidth, @StudHeight);
      SELECT LAST_INSERT_ID()";
      newBrick.Id = _db.ExecuteScalar<int>(sql, newBrick);
      return newBrick;
    }

    public Brick Edit(Brick newBrick)
    {
      string sql = @"
      UPDATE bricks
      SET
        name = @Name,
        color = @Color,
        studWidth = @StudWidth,
        studHeight = @StudHeight
      WHERE id = @Id;
      SELECT * FROM bricks WHERE id = @Id";
      return _db.QueryFirstOrDefault<Brick>(sql, newBrick);
    }

    public int Delete(int id)
    {
      string sql = "DELETE FROM bricks WHERE id = @id";
      return _db.Execute(sql, new { id });
    }
  }
}