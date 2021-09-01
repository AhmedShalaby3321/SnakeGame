using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Snake colors",menuName ="Snake Color")]
public class SnakeColorsSO : ScriptableObject
{
    public List<Color> Cyan;
    public List<Color> Green;
    public List<Color> Purple;
    public List<Color> Yellow;

    public Dictionary<SnakeColors_Enum, List<Color>> Colors_Dict = new Dictionary<SnakeColors_Enum, List<Color>>();
}
