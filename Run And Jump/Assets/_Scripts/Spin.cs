using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float speedRotate = -200;

    //En el caso del barril que rota lo asifnamos como hijo de un game object para separar las fisicas , es decir, el barril sólo rota y el game object es el que se translada a la izquierda.
     
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up*speedRotate*Time.deltaTime);
    }
}
