using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eggScript : MonoBehaviour
{

    public GameObject egg;
    public GameObject topEgg;
    public GameObject bottomEgg;
    public GameObject yoke;
    public Vector3 spawnpoint;
    public Vector3 topOffset;
    public Vector3 tyokeOffset;
    public Vector3 tbottomOffset;

    AudioSource audioData;


    // Start is called before the first frame update
    void Start()
    {
        egg.transform.position = spawnpoint;

        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= 0.05)
        {
            kill();
        }
    }

    public void breakEgg()
    {
        Instantiate(topEgg, this.transform.position + topOffset, egg.transform.rotation);
        Instantiate(bottomEgg, this.transform.position + tbottomOffset, egg.transform.rotation);
        Instantiate(yoke, this.transform.position + tyokeOffset, egg.transform.rotation);

    
        //Kills the object
        kill();
    }

    void OnCollisionEnter (Collision col){
        // if (col.gameObject.name == "prop_PowerCube"){
        //     Debug.Log("KlopKlop");
        // }
        Debug.Log("Collided Against Something");
        //audioData.Play();

    }

    public void kill()
    {
        Instantiate(egg, spawnpoint,transform.rotation);
        Destroy(gameObject);
    }
}

