using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonigoteController : MonoBehaviour
{
    private Animator _animator;

    private const string MOVE_HAND = "Is Move Hands"; 
    private const string MOVE_X = "Move_X";
    private const string MOVE_Y = "Move_Y";
    private const string MOVING = "Is Moving";

    private bool isMovingHand = false;
    private bool isMoving = false;

    private float moveX;
    private float moveY;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool(MOVE_HAND, isMovingHand);
        _animator.SetBool(MOVING, isMoving);

        _animator.SetFloat(MOVE_X, moveX);
        _animator.SetFloat(MOVE_Y, moveY);
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        if (Mathf.Sqrt(moveX*moveX + moveY*moveY) > 0.01) 
        {
            isMoving = true;
            _animator.SetFloat(MOVE_X, moveX);
            _animator.SetFloat(MOVE_Y, moveY);
            _animator.SetBool(MOVING, isMoving);
        }else 
        {
            isMoving = false;
            _animator.SetBool(MOVING, isMoving);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMovingHand = !isMovingHand;
            _animator.SetBool(MOVE_HAND, isMovingHand);
        }
    }
}
