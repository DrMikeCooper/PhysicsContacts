using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsContactTracker : MonoBehaviour
{
    Dictionary<Collider, List<ContactPoint>> contacts = new Dictionary<Collider, List<ContactPoint>>();
    public GameObject marker;
    List<Transform> markers = new List<Transform>();
    public Collider crusher;
    public bool crushed;

    private void OnCollisionStay(Collision collision)
    {
        contacts[collision.collider] = new List<ContactPoint>();
        contacts[collision.collider].AddRange(collision.contacts);
    }

    private void OnCollisionExit(Collision collision)
    {
        contacts.Remove(collision.collider);
    }

    private void Start()
    {
        for (int i = 0; i < 50; i++)
        {
            GameObject go = Instantiate(marker);
            go.SetActive(false);
            markers.Add(go.transform);
        }
    }

    private void Update()
    {
        // move all the amrkers around so we can see every collision and its normal
        int index = 0;
        foreach (KeyValuePair<Collider, List<ContactPoint>> pair in contacts)
        {
            foreach (ContactPoint cp in pair.Value)
            {
                markers[index].gameObject.SetActive(true);
                markers[index].position = cp.point;
                markers[index].up = cp.normal;
                index++;
            }
        }

        for (int i = index; i < 50; i++)
            markers[i].gameObject.SetActive(false);

        crushed = false;
        // check if the crusher is crushing us
        if (crusher && contacts.ContainsKey(crusher))
        {
            Vector3 crusherNormal = contacts[crusher][0].normal;

            foreach (KeyValuePair<Collider, List<ContactPoint>> pair in contacts)
            {
                foreach (ContactPoint cp in pair.Value)
                {
                    if (Vector3.Dot(crusherNormal, cp.normal) < -0.8f)
                        crushed = true;
                }
            }

                }
    }
}
