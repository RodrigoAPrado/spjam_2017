using UnityEngine;
using System.Collections;

public class LaneController : MonoBehaviour
{
    private  float[] lanePositionStart;
    
    private float[] lanePositionEnd;

    void Start()
    {
        lanePositionStart = new float[] { 0.76f, 2.42f, 4.1f, -4.3f, - 2.6f,  - 0.93f };
    }

    public float getLanePositionStart(int i)
    {
        Debug.Log(i);
        return lanePositionStart[i];
    }

}
