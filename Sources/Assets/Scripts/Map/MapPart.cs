using UnityEngine;

[CreateAssetMenu(fileName = "Map Part", menuName = "ScriptableObjects/Map Part")]
[System.Serializable]
public class MapPart : ScriptableObject
{
    public new string name;
    public Sprite sprite;
}
