﻿using UnityEngine;
using System.Collections;

public class MovingWorld : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector2(-0.06f, 0));
	}
}