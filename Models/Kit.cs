using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace legos.Models
{
  public class Kit
  {

    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public double Price { get; set; }
    [Required]
    public string Instructions { get; set; }
    public Kit()
    {
    }

    public Kit(string name, double price, string instructions)
    {
      Name = name;
      Price = price;
      Instructions = instructions;
    }

    public void Edit(JsonElement edits)
    {
      if (edits.TryGetProperty("name", out JsonElement newName)) { Name = newName.ToString(); }
      if (edits.TryGetProperty("price", out JsonElement newWidth)) { Price = newWidth.GetDouble(); }
      if (edits.TryGetProperty("instructions", out JsonElement newHeight)) { Instructions = newHeight.ToString(); }
    }
  }
}