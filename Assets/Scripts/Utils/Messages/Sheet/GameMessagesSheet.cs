using Cathei.BakingSheet;

public class GameMessagesSheet : Sheet<MessageKey, GameMessagesSheet.Messages>
{
    public class Messages : SheetRow<MessageKey> { 
    
        public string Vi { get; private set; }
        public string Eng { get; private set; }
    }
}
