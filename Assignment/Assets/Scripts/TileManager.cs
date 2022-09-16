using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    /*the script manages the tiles that are going to appear after the player 
    reaches certain position, it randomly chooses a tile prefab*/


    //Creates an array for the tiles
    public GameObject[] Rooms;

    //creates variable for player position
    private Transform playerTransform;

    //Distance between the spawning point and the end of the last enabled tile
    public float spawnPoint = 10f;

    //Lenght of each tile that is going to be placed in the scene
    public float tileLength = 10f;

    //Number of tiles ahead the player
    public int amnTilesOnScreen = 3;


    //Start event
    private void Start()
    {
        //defines the position of the player
        playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;

        //Creates 3 tiles in front of the starting tile
        for (int i = 0; i < amnTilesOnScreen; i++)
        {
            //Executes the SpawnTile event
            SpawnTile ();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        //Checks if the player has passed the spawning position (certain distance before the end of the last tile created in scene)
        if (playerTransform.position.z > (spawnPoint - amnTilesOnScreen * tileLength))
        {
            //Executes the SpawnTile event
            SpawnTile ();
        }
    }

    //SpawnTile event (defines what will happen once it is called)
    private void SpawnTile(int prefabIndex = -1)
    {
        //Creates gameObject variable
        GameObject go;
        //Randomly chooses and creates a tile from the "rooms" array 
        go = Instantiate (Rooms [Random.Range(0, 1)]) as GameObject;
        //sets this gameobject as parent
        go.transform.SetParent (transform);
        //moves the tile forward, to the spawning position (next to the last tile)
        go.transform.position = Vector3.forward * spawnPoint;
        //changes the spawning position so it moves forward and keeps being position the player has to reach
        spawnPoint += tileLength;
    }
}
