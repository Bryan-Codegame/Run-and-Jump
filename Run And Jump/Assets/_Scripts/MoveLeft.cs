using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10;
    private PlayerController _playerController;

    void Start()
    {
        //Encuentra al player en la escena y obtiene su componente en este caso su código y del código se pueden extraer todas las variables que son públicas.
        _playerController = GameObject.Find("Player")
            .GetComponent<PlayerController>();

        
    }

    // Update is called once per frame
    void Update()
    {
        //Increment Speed 
        speed += Time.deltaTime/5;
        
        if (!_playerController.GameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
