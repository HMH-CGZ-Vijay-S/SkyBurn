using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmallWave : MonoBehaviour
{
    Vector2 presentdirection = Vector3.right;

    private void OnEnable()
    {
        presentdirection = Vector3.right;
    }
    private void Update()
    {


            transform.Translate(presentdirection  * Time.deltaTime);

        if (transform.position.x > ScreenManager.instance.maxX)
            presentdirection = Vector2.left;
        if (transform.position.x < ScreenManager.instance.minX)
            presentdirection = Vector3.right;


    }
}

