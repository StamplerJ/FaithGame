using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/Character")]
[System.Serializable]
public class Character : ScriptableObject
{
    public new string name;
    public Sprite portrait;
    public Sprite sprite;
}
