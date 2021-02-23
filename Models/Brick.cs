using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace legos.Models
{
  public class Brick
  {

    public int Id { get; set; }
    public string Name { get; set; } = "";
    [Required]
    public string Color { get; set; }
    [Required]
    public int StudWidth { get; set; } = 1;
    [Required]
    public int StudHeight { get; set; } = 1;
    public Brick()
    {
    }

    public Brick(string color, int studWidth, int studHeight)
    {
      Color = color;
      StudWidth = studWidth;
      StudHeight = studHeight;
      Name = studWidth + "x" + studHeight;
    }

    public void Edit(JsonElement edits)
    {
      if (edits.TryGetProperty("color", out JsonElement newColor)) { Color = newColor.ToString(); }
      if (edits.TryGetProperty("studWidth", out JsonElement newWidth)) { StudWidth = newWidth.GetInt32(); }
      if (edits.TryGetProperty("studHeight", out JsonElement newHeight)) { StudHeight = newHeight.GetInt32(); }
      Name = StudWidth + "x" + StudHeight;
    }
  }

  public class KitBrickViewModel : Brick
  {
    public int KitBrickId { get; set; }
  }
}