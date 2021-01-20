using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colision : MonoBehaviour
{
    public float time;

    private void OnTriggerEnter(Collider coll)
    {

        Destroy(coll.gameObject , time);

    }
}
