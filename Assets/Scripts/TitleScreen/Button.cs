using UnityEngine;
using System.Collections;

public abstract class Button : MonoBehaviour {

    protected bool selected = false;

    public abstract bool getSelected();

    public abstract void doAction();
}
