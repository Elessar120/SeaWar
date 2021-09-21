using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu (fileName = "New Stuff" , menuName = "Stuffs")]
public class GamePlayMenu : ScriptableObject
{
    public int level;
    public List<string> tradeUnit = new List<string>();
    public Sprite frame;
    public Sprite warfareIcon;
    public Sprite tradeUnitIcon;
    public float price;
}
