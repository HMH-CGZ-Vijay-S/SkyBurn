using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    public PowerUps powervalue;

    Color lerpedColor = Color.white;

    void Update()
    {
        transform.Translate(Vector3.down * Utility.bulletSpeed *.2f* Time.deltaTime );

        lerpedColor = Color.Lerp(Color.yellow, Color.blue, Mathf.PingPong(Time.time, 1));
        transform.GetComponent<SpriteRenderer>().color = lerpedColor;
    }

}
