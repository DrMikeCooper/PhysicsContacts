using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position = 23.5f * Mathf.Sin(Time.time * 0.1f) * Vector3.forward;
    }
}
