internal class CardDisplayDTO
{
    public int DisplayId {get; set;}
    
    public string Front {get; set;}

    public string Back {get; set;}

    public int Id {get; set;}

    public CardDisplayDTO(int DisplayId, string Front, string Back, int Id)
    {
        this.DisplayId = DisplayId;
        this.Front = Front;
        this.Back = Back;
        this.Id = Id;
    }
}