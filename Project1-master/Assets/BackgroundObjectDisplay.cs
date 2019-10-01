using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Credit to website http://backgroundcheckall.com/survival-background/ for providing my example background of a scriptable object

public class BackgroundObjectDisplay : MonoBehaviour {

    public BackgroundObject BG;
    public Image artworkImage;

    public Text name1;
    public Text name2;
    public Text version;

	// Use this for initialization
	void Start () {
        name1.text = BG.namePart1;
        name2.text = BG.namePart2;
        version.text = BG.version.ToString("G2");
        artworkImage.sprite = BG.artwork;
	}

}
