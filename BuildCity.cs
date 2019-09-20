using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCity : MonoBehaviour
{
    public GameObject[] buildings;
    public GameObject xStreets;
    public GameObject zStreets;
    public GameObject crossRoad;
    public GameObject settlement;
    public GameObject platform;
    public int mapWidth = 20;
    public int mapHeight = 20;
    int[,] mapGrid;
    int buildingFootprint = 3;
    bool modelUsed;

    void Start()
    {
        GenerateCity();
    }

    public void GenerateCity()
    {
        mapGrid = new int[mapWidth, mapHeight];

        float seed = Random.Range(0, 10000);
        //generate map data
        for (int h = 0; h < mapHeight; h++)
        {
            for (int w = 0; w < mapWidth; w++)
            {
                mapGrid[w, h] = (int)(Mathf.PerlinNoise(w / 10.0f + seed, h / 10.0f + seed) * 10);
            }
        }

        //build streets
        int x = 0;
        for (int n = 0; n < 50; n++)
        {
            for (int h = 0; h < mapHeight; h++)
            {
                mapGrid[x, h] = -1;
            }
            x += Random.Range(3, 3);
            if (x >= mapWidth) break;
        }

        int z = 0;
        for (int n = 0; n < 10; n++)
        {
            for (int w = 0; w < mapWidth; w++)
            {
                if (mapGrid[w, z] == -1) //put in a cross road
                    mapGrid[w, z] = -3;
                else
                    mapGrid[w, z] = -2;
            }
            z += Random.Range(5, 20);
            if (z >= mapHeight) break;
        }

        //generate city
        for (int h = 0; h < mapHeight; h++)
        {
            for (int w = 0; w < mapWidth; w++)
            {
                int result = mapGrid[w, h];

                Vector3 pos = new Vector3(w * buildingFootprint, 0, h * buildingFootprint) + platform.transform.position + new Vector3(-30f, 4f, -28f);

                if (result < -2) //crossroad
                {
                    GameObject obj = Instantiate(crossRoad, pos, crossRoad.transform.rotation);
                    obj.transform.parent = settlement.transform;
                }
                else if (result < -1) //Streets x-plane
                {
                    GameObject obj = Instantiate(xStreets, pos, xStreets.transform.rotation);
                    obj.transform.parent = settlement.transform;
                }
                else if (result < 0) //Streets z-plane
                {
                    GameObject obj = Instantiate(zStreets, pos, zStreets.transform.rotation);
                    obj.transform.parent = settlement.transform;
                }
                else if (result < 2) //building 1
                {
                    GameObject obj = Instantiate(buildings[0], pos, buildings[0].transform.rotation);
                    obj.transform.parent = settlement.transform;
                }
                else if (result < 3) //building 2
                {
                    GameObject obj = Instantiate(buildings[1], pos, buildings[1].transform.rotation);
                    obj.transform.parent = settlement.transform;
                }
                else if (result < 5) //building 3
                {
                    GameObject obj = Instantiate(buildings[2], pos, buildings[2].transform.rotation);
                    obj.transform.parent = settlement.transform;
                }
                else if (result < 6) //building 4
                {
                    GameObject obj = Instantiate(buildings[3], pos, buildings[3].transform.rotation);
                    obj.transform.parent = settlement.transform;
                }
                else if (result < 7) //grass
                {
                    GameObject obj = Instantiate(buildings[4], pos, buildings[4].transform.rotation);
                    obj.transform.parent = settlement.transform;
                    obj.GetComponent<TreeGenerator>().GenerateTrees(); //call the grass object's GenerateTrees method
                }
                else if (result < 10)
                {
                    if (modelUsed == false)
                    {
                        GameObject obj = Instantiate(buildings[5], pos, buildings[5].transform.rotation);
                        obj.transform.parent = settlement.transform;
                        modelUsed = true;
                    }
                    else
                    {
                        GameObject obj = Instantiate(buildings[4], pos, buildings[4].transform.rotation);
                        obj.transform.parent = settlement.transform;
                    }
                }
            }
        }
    }

    public void ClearCities()
    {
        GameObject[] prefabs = GameObject.FindGameObjectsWithTag("prefabObj"); //get all prefab objects in the scene
        foreach (GameObject g in prefabs)
            GameObject.DestroyImmediate(g);
    }
}
