using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Static y publico juntos significa que esta variable es única en todo el juego.
    public static GameManager instance;
    public static float speedObstacle = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        speedObstacle += Time.deltaTime;
    }
}
