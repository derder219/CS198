using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnSc : ScriptableObject {

    public int playerDamage;                            //The amount of food points to subtract from the player when attacking.


    private Animator animator;                          //Variable of type Animator to store a reference to the enemy's Animator component.
    private Transform target;                           //Transform to attempt to move toward each turn.
    private bool skipMove;                              //Boolean to determine whether or not enemy should skip a turn or move this turn.
    public AudioClip enemyAttack1;
    public AudioClip enemyAttack2;
}
