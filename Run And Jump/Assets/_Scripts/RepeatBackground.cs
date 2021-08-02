using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos; 
    private float reapeatSize;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;

        //Se divide entre dos porque la imagen esta duplicada para que nunca exista un espacio en blanco y al repetirse dar ese efecto de que el background es infinito.
        reapeatSize = GetComponent<BoxCollider>().size.x/2;


    }

    // Update is called once per frame
    void Update()
    {       
        if (startPos.x - transform.position.x >= reapeatSize)
        {
            transform.position = startPos;
        }       
    }
}
