using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Scriptable Objects/CharacterData")]
public class CharacterData : ScriptableObject
{
    [Min(0)]
    [Range(0,20)]
    [Header("移動速度")]
    public  float moveSpeed = 3f;
}
