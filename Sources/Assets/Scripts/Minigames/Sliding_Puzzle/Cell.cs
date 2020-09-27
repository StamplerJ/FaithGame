public class Cell
{
    private bool isOccupied = false;
    
    public Cell()
    {
    }

    public bool IsOccupied
    {
        get => isOccupied;
        set => isOccupied = value;
    }
}
