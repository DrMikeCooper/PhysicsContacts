using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsRoller : MonoBehaviour
{
    public float speed = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 force = Camera.main.transform.forward * Input.GetAxis("Vertical") + Camera.main.transform.right * Input.GetAxis("Horizontal");
        GetComponent<Rigidbody>().AddForce(force * speed);
    }
}
