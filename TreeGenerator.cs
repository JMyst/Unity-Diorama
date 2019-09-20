using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerator : MonoBehaviour
{
    public GameObject grass;
    public GameObject[] trees;
    public int gridSize = 3;
    public int modelCount;
    bool[,] gridZones;

    public void GenerateTrees()
    {
        gridZones = new bool[gridSize, gridSize];
        modelCount = Random.Range(0, 4);

        for (int i = 0; i < modelCount; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                int modelToUse = Random.Range(0, trees.Length);
                float width = Random.Range(0, gridSize);
                float depth = Random.Range(0, gridSize);
                if (gridZones[(int)width, (int)depth] == false) //if grid zone is unoccupied, instantiate there, else restart the loop
                {
                    GameObject curModel = Instantiate(trees[modelToUse]);
                    curModel.transform.position = grass.transform.position;      
                    curModel.transform.parent = grass.transform;
                    curModel.transform.position = curModel.transform.position + new Vector3((width - 0.9f), 0.2f, (depth - 0.9f)); //x15 is the padding between the grid, -1000 is to center the grid
                    gridZones[(int)width, (int)depth] = true;
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
