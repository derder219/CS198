using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealthController : MonoBehaviour
{

    public TextMeshProUGUI text;
    public GameObject player;

    private void Awake()
    {
        text.SetText("Health: {0}", player.GetComponent<PlayerControllerModified>().health);
    }

    // Use this for initialization
    void Start()
    {
        //text.SetText("Health: {0}", player.GetComponent<PlayerControllerModified>().health);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateHealth()
    {
        text.SetText("Health: {0}", player.GetComponent<PlayerControllerModified>().health);
    }
}
