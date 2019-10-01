using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BG", menuName = "Background (BG)")]
public class BackgroundObject : ScriptableObject {

    public Sprite artwork;

    public float version;

    public string namePart1;
    public string namePart2;
}
