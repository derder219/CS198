﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerWall : ScriptableObject {

    public AudioClip chopSound1;                //1 of 2 audio clips that play when the wall is attacked by the player.
    public AudioClip chopSound2;                //2 of 2 audio clips that play when the wall is attacked by the player.
    public Sprite dmgSprite;                    //Alternate sprite to display after Wall has been attacked by player.
    public int hp = 3;                          //hit points for the wall.

}
