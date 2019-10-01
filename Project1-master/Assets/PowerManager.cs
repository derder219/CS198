using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManager : MonoBehaviour {

    public bool timeFrozen;                     //Boolean letting know whether player has hit timeFreeze powerup.
    public int deltaTimeFrozen;                 //Number of moves since time frozen
    
    // Use this for initialization
    void Start () {
        timeFrozen = false;
        deltaTimeFrozen = 0;
	}
}
