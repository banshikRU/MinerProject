using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMover playerMover;
    private bool isPlayerLeft;
    private void Start()
    {
        isPlayerLeft = false;
    }
    private void Update()
    {
        TakeInput();
    }
    private void TakeInput()
    {
        if (Input.GetKeyDown(KeyCode.W) && playerMover._isMoving == false && playerMover._isFly == false)
        {
            playerMover.AttemptMove<IAmBlock>(0, 4);
        }
        if (Input.GetKeyDown(KeyCode.A) && playerMover._isMoving == false && playerMover._isFly == false)
        {
            if (isPlayerLeft == false)
            {
                isPlayerLeft = true;
                transform.localScale = new Vector3(-1, 1);
            }
            playerMover.AttemptMove<IAmBlock>(-1, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (playerMover._isFly == false && playerMover._isMoving == false)
            {
                playerMover.AttemptMove<IAmBlock>(0, -1);
            }
        }
        if (Input.GetKeyDown(KeyCode.D) && playerMover._isMoving == false && playerMover._isFly == false)
        {
            if (isPlayerLeft == true)
            {
                isPlayerLeft = false;
                transform.localScale = new Vector3(1, 1);
            }
            playerMover.AttemptMove<IAmBlock>(1, 0);
        }
    }
    public void Up()
    {
        if ( playerMover._isMoving == false && playerMover._isFly == false)
        {
            playerMover.AttemptMove<IAmBlock>(0, 4);
        }
    }
    public void Down()
    {
        if (playerMover._isFly == false && playerMover._isMoving == false)
        {
            playerMover.AttemptMove<IAmBlock>(0, -1);
        }
    }
    public void Left()
    {
        if (isPlayerLeft == false)
        {
            isPlayerLeft = true;
            transform.localScale = new Vector3(-1, 1);
        }
        if (playerMover._isMoving == false && playerMover._isFly == false)
        {
            playerMover.AttemptMove<IAmBlock>(-1, 0);
        }
    }
    public void Rigth()
    {
        if (isPlayerLeft == true)
        {
            isPlayerLeft = false;
            transform.localScale = new Vector3(1, 1);
        }
        if (playerMover._isMoving == false && playerMover._isFly == false)
        {
            playerMover.AttemptMove<IAmBlock>(1, 0);
        }
    }
}
