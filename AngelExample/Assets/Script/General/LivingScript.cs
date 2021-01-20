using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingScript : MonoBehaviour
{

    public GameObject father;
    private float childrenX;
    private float childrenZ;
    public float time;

    public void Birth(bool crearNino , GameObject thisGameObject)
    {

            if (crearNino)
            {
                childrenX = father.transform.position.x * 2;
                childrenZ = father.transform.position.z * 2;

                Instantiate(father, new Vector3(childrenX, father.transform.position.y, childrenZ), Quaternion.identity);

            }

    }

    public void Death(GameObject thisGameObject)
    {

        if (thisGameObject.transform.position.y <= -120)
        {
            Destroy(thisGameObject.gameObject , time);
        }

        //Debug.Log("Boludo");
    }


}
