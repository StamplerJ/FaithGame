using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "ScriptableObjects/Dialogue")]
[System.Serializable]
public class Dialogue : ScriptableObject
{
    public Character character;
    public Message[] messages;
}
