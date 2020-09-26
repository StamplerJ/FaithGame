using System;

[Serializable]
public class Message
{
    public bool isPlayer;
    public string text;
    public Response[] responses;
}
