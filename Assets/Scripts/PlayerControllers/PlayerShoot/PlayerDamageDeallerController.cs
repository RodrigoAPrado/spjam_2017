using UnityEngine;
using System.Collections;

public class PlayerDamageDeallerController : DamageDeallerController {

    private string type;

    public void setType(string type)
    {
        this.type = type;
    }

    public string getType()
    {
        return type;
    }
}
