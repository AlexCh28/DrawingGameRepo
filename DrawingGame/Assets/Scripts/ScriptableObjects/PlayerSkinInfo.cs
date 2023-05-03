using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSkinInfo", menuName = "ScriptableObjects/PlayerSkinInfo", order = 2)]
public class PlayerSkinInfo : ScriptableObject
{
    public List<Sprite> Sprites;
    public List<Color> LineColor;
    public List<Color> FinishColor;
    public int SkinIndex;
    
}
