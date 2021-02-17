using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMovement : MonoBehaviour
{
    float myValue = 1; 
    // Start is called before the first frame update
    void Start()
    {
        myValue = ScreenManager.instance.minY / transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * .5f);
        if(transform.position.y<ScreenManager.instance.minY+transform.localScale.y*myValue-2)
        {
            transform.position += Vector3.up * 33;
        }
    }
}
