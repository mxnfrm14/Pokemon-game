using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Combat : MonoBehaviour
{


    public GameObject fireball;


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Instantiate(fireball, transform.position, transform.rotation);
    }
}
