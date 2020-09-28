using System;

[Serializable]
public class Response 
{
    public int next;
    public string reply;
    public bool endsConversation;
    public Character requiredCharacter;
    public MapPart triggerMap;
}