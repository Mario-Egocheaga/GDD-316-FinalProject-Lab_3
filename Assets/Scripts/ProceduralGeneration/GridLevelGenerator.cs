using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridLevelGenerator : MonoBehaviour
{
    public Transform parent;

    public GameObject[] props;  // Array of prefabs for props to be placed in the level
    public int gridWidth = 10;  // Width of the grid
    public int gridHeight = 10;  // Height of the grid
    public float cellSize = 1f;  // Size of each grid cell
    public float propDensity = 0.5f;  // Density of props in the grid
    public int numLayers = 3;  // Number of layers of props to generate

    public float minPropDistance = 2f;  // Minimum distance between props

    //Number of Walls Needed
    public int numWalls = 4;

    public LayerMask spawnObjectLayer;

    bool canPlace;

    void Start()
    {
        parent = this.transform;
        GenerateLevel();
        spawnInfrastructure();
        ChangeTransform();
    }

    void GenerateLevel()
    {
        // Loop through each cell in the grid
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Vector3 PosPicked = new Vector3((x - gridWidth / 2f + .5f) * cellSize, 0 * cellSize, (y - gridHeight / 2f + .5f) * cellSize);

                // Ends of the level of the Width of the grid
                if (PosPicked.x == 12 || PosPicked.x == -12)
                {
                    if (Random.value > .5)
                    {
                        GameObject endProp = props[Random.Range(0, 2)];
                        Vector3 pos = new Vector3((x - gridWidth / 2f + .5f) * cellSize, 0 * cellSize, (y - gridHeight / 2f + 0.5f) * cellSize);

                        bool isOverlap = CheckOverLap(pos);

                        if (!isOverlap)
                        {
                            // Instantiate the prop at the calculated position
                            GameObject propPlaced = Instantiate(endProp, pos, Quaternion.identity);
                            propPlaced.transform.parent = parent.transform;
                            propPlaced.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + Random.Range(0f, 360f), transform.rotation.z);
                        }
                    }

                }

                // Ends of the level of Length of the grid
                if (PosPicked.z == 12 || PosPicked.z == -12)
                {
                    if (Random.value > .5)
                    {
                        GameObject endProp = props[Random.Range(0, 2)];
                        Vector3 pos = new Vector3((x - gridWidth / 2f + .5f) * cellSize, 0 * cellSize, (y - gridHeight / 2f + 0.5f) * cellSize);


                        bool isOverlap = CheckOverLap(pos);

                        if (!isOverlap)
                        {
                            // Instantiate the prop at the calculated position
                            GameObject propPlaced = Instantiate(endProp, pos, Quaternion.identity);
                            propPlaced.transform.parent = parent.transform;
                            propPlaced.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + Random.Range(0f, 360f), transform.rotation.z);
                        }
                    }
                }

                if ((PosPicked.x < 10 || PosPicked.x > -10) && (PosPicked.z < 10 || PosPicked.z > -10))
                {
                    if (Random.value > .5)
                    {
                        GameObject endProp = props[Random.Range(2, props.Length - 1)];
                        Vector3 pos = new Vector3((x - gridWidth / 2f + .5f) * cellSize, 0 * cellSize, (y - gridHeight / 2f + 0.5f) * cellSize);

                        bool isOverlap = CheckOverLap(pos);

                        if (!isOverlap)
                        {
                            // Instantiate the prop at the calculated position
                            GameObject propPlaced = Instantiate(endProp, pos, Quaternion.identity);
                            propPlaced.transform.parent = parent.transform;
                            propPlaced.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + Random.Range(0f, 360f), transform.rotation.z);
                        }
                    }
                }

                // Loop through each layer of props
                for (int layer = 0; layer < numLayers; layer++)
                {

                    /*
                    // Choose whether to place a prop in this cell and layer based on the prop density
                    if (Random.value < propDensity)
                    {
                        // Choose a random prop from the array
                        GameObject prop = props[Random.Range(0, props.Length - 1)];
                        
                        // Calculate the position of the prop within the cell and layer
                        Vector3 position = new Vector3((x - gridWidth / 2f + 0.5f) * cellSize, layer * cellSize, (y - gridHeight / 2f + 0.5f) * cellSize);

                        // Instantiate the prop at the calculated position
                        GameObject propPlaced = Instantiate(prop, position, Quaternion.identity);
                        propPlaced.transform.parent = parent.transform;
                        propPlaced.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + Random.Range(0f, 360f), transform.rotation.z);


                        Debug.Log(propPlaced.transform);
                    }
                    */
                }
            }
        }
    }

    void spawnInfrastructure()
    {
        spawnCircle();
    }

    void spawnSquare()
    {
        GameObject wall = wall = props[7];

        Vector3 center = new Vector3(transform.position.x + Random.Range(-8f, 8f), 0, transform.position.z + Random.Range(-8f, 8f));

        for (int i = 0; i < numWalls - 1; i++)
        { 
           // Vector3 objectPos = Vector3.Lerp()
        }
    }

    void spawnCircle()
    {

        GameObject wall = wall = props[props.Length - 1];

        float radius = 5;

        Vector3 center = new Vector3(transform.position.x + Random.Range(-8f, 8f), 0, transform.position.z + Random.Range(-8f, 8f));

        for (int i = 0; i < numWalls; i++)
        {
            Vector3 pos = RanCircle(center, 5.0f);
            Quaternion rot = Quaternion.FromToRotation(Vector3.right, center - pos);

            bool isOverlap = CheckOverLap(pos);

            if (!isOverlap)
            {
                GameObject wallPlaced = Instantiate(wall, pos, rot);
                wallPlaced.transform.parent = parent.transform;
            }
        }
    }

    Vector3 RanCircle(Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y;
        pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;
    }


    void ChangeTransform()
    {
        parent.transform.position = new Vector3(this.transform.position.x - 2 , 0, this.transform.position.z - 2);
    }

    private bool CheckOverLap(Vector3 spawnPos)
    {
        Collider[] colliders = Physics.OverlapSphere(spawnPos, 1f);

        foreach (var collider in colliders)
        {
            if (collider.gameObject.CompareTag("Prop"))
            {
                return true;
            }
        }

        return false;
    }
}