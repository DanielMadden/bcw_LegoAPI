namespace legos.Models
{
  public class KitBrick
  {
    public int Id { get; set; }
    public int KitId { get; set; }
    public int BrickId { get; set; }

    public KitBrick(int kitId, int brickId)
    {
      KitId = kitId;
      BrickId = brickId;
    }

    public KitBrick()
    {
    }
  }
}