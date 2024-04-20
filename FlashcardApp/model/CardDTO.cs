internal class CardDTO
{
    public int Id {get; set;}
    public string Front {get; set;}

    public string Back {get; set;}

    public CardDTO(int Id, string Front, string Back)
    {
        this.Front = Front;
        this.Back = Back;
        this.Id = Id;
    }
    public CardDTO(){}
}