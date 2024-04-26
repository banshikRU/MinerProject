using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeSpawner : MonoBehaviour
{
    public GameObject snakePrefab; // Префаб змеи
    public Transform player; // Игрок, к которому будут двигаться змеи
    public float spawnInterval = 2f; // Интервал между спаунами змей
    public float spawnDistance = 10f; // Расстояние, на котором появляются змеи

    private float timer; // Таймер для отслеживания интервала спауна

    void Update()
    {
        timer += Time.deltaTime; // Увеличиваем таймер

        // Если таймер превысил интервал спауна, создаем змею
        if (timer >= spawnInterval)
        {
            SpawnSnake();
            timer = 0f; // Сбрасываем таймер
        }
    }

    void SpawnSnake()
    {
        // Выбираем случайную сторону экрана для спауна змеи
        Vector2 spawnDirection = Random.insideUnitCircle.normalized;
        Vector3 spawnPosition = (Vector3)spawnDirection * spawnDistance;

        // Создаем змею на выбранной стороне экрана
        GameObject snake = Instantiate(snakePrefab, spawnPosition, Quaternion.identity);

        // Находим компонент, управляющий движением змеи
        SnakeMovement snakeMovement = snake.GetComponent<SnakeMovement>();

        // Если нашли компонент, устанавливаем игрока в качестве цели
        if (snakeMovement != null)
        {
        }
    }
}
