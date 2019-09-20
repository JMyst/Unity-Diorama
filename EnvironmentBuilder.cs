using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentBuilder : MonoBehaviour
{
    public GameObject[] models;
    public int modelCount;
    public int gridSize = 30;
    bool[,] gridZones;

    void Start()
    {
        gridZones = new bool[gridSize, gridSize];
        modelCount = Random.Range(10, 21);

        for(int i = 0; i < modelCount; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                int width = Random.Range(0, gridSize);
                int depth = Random.Range(0, gridSize);
                int modelToUse = Random.Range(0, models.Length);
                GameObject curModel = Instantiate(models[modelToUse]);
                if (gridZones[width, depth] == false) //if grid zone is unoccupied, instantiate there, else restart the loop
                {
                    curModel.transform.position = new Vector3((width * 15 - 1000), (Random.Range(-10, 11) * 10), (depth * 15 - 1000)); //x15 is the padding between the grid, -1000 is to center the grid
                    Vector3 yRotation = transform.eulerAngles;
                    yRotation.y = Random.Range(0f, 360f);
                    curModel.transform.eulerAngles = yRotation;
                    gridZones[width, depth] = true;
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
