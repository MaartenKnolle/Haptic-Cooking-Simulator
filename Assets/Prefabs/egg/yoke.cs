using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yoke : MonoBehaviour
{
    public GameObject eggInPan;
    public Vector3 currentpos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= 0.05)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision collision) { 
        if (collision.gameObject.name == "pan")
        {
            currentpos = transform.position;
            Instantiate(eggInPan, currentpos, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
