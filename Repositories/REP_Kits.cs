using System.Collections.Generic;
using System.Data;
using Dapper;
using legos.Models;

namespace legos.Repositories
{
  public class REP_Kits
  {
    public readonly IDbConnection _db;

    public REP_Kits(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Kit> Get()
    {
      string sql = "SELECT * FROM kits";
      return _db.Query<Kit>(sql);
    }

    public Kit GetById(int id)
    {
      string sql = "SELECT * FROM kits WHERE id = @id";
      return _db.QueryFirstOrDefault<Kit>(sql, new { id });
    }

    public Kit Create(Kit newKit)
    {
      string sql = @"
      INSERT INTO kits
      (name, price, instructions)
      VALUES
      (@Name, @Price, @Instructions);
      SELECT LAST_INSERT_ID()";
      newKit.Id = _db.ExecuteScalar<int>(sql, newKit);
      return newKit;
    }

    public Kit Edit(Kit newKit)
    {
      string sql = @"
      UPDATE kits
      SET
        name = @Name,
        price = @Price,
        instructions = @Instructions
      WHERE id = @Id;
      SELECT * FROM kits WHERE id = @Id";
      return _db.QueryFirstOrDefault<Kit>(sql, newKit);
    }

    public int Delete(int id)
    {
      string sql = "DELETE FROM kits WHERE id = @id";
      return _db.Execute(sql, new { id });
    }
  }
}