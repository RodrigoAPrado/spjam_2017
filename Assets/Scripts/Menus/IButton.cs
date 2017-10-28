using UnityEngine;
using System.Collections;

public abstract class IButton : MonoBehaviour {

    protected bool selected = false;

    protected bool disabled = false;
    
    public abstract bool getSelected();

    public abstract void switchSelected();

    public abstract bool getDisabled();

    public abstract void doAction();
}
