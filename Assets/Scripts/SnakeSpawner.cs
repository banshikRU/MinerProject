using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeSpawner : MonoBehaviour
{
    public GameObject snakePrefab; // ������ ����
    public Transform player; // �����, � �������� ����� ��������� ����
    public float spawnInterval = 2f; // �������� ����� �������� ����
    public float spawnDistance = 10f; // ����������, �� ������� ���������� ����

    private float timer; // ������ ��� ������������ ��������� ������

    void Update()
    {
        timer += Time.deltaTime; // ����������� ������

        // ���� ������ �������� �������� ������, ������� ����
        if (timer >= spawnInterval)
        {
            SpawnSnake();
            timer = 0f; // ���������� ������
        }
    }

    void SpawnSnake()
    {
        // �������� ��������� ������� ������ ��� ������ ����
        Vector2 spawnDirection = Random.insideUnitCircle.normalized;
        Vector3 spawnPosition = (Vector3)spawnDirection * spawnDistance;

        // ������� ���� �� ��������� ������� ������
        GameObject snake = Instantiate(snakePrefab, spawnPosition, Quaternion.identity);

        // ������� ���������, ����������� ��������� ����
        SnakeMovement snakeMovement = snake.GetComponent<SnakeMovement>();

        // ���� ����� ���������, ������������� ������ � �������� ����
        if (snakeMovement != null)
        {
        }
    }
}
