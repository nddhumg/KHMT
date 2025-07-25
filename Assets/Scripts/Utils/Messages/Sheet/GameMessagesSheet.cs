using Cathei.BakingSheet;

public class GameMessagesSheet : Sheet<GameMessagesSheet.Messages>
{
    public class Messages : SheetRow { 
    
        public string Vi { get; private set; }
        public string Eng { get; private set; }
    }
}
