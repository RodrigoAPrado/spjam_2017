using UnityEngine;
using System.Collections;

public class ButtonShop : ButtonChangePage {

	// Use this for initialization
	void Start () {
        sceneToLoad = "Shop";
        if (!PlayerPrefs.HasKey("hasSaveFile"))
        {
            disabled = true;
        }
    }
}
