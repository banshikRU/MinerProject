using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SnakeMovement : MonoBehaviour
{
    public Transform player; // ������ �� ������
    public float rotationSpeed = 5f; // �������� �������� ����

    private void Update()
    {

          RaycastHit2D a = Physics2D.Raycast(transform.position,new Vector2(-1,0));
            Debug.Log(a.transform.gameObject.name);
      
    }
}

