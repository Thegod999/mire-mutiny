using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public MapGenerator mapData;
    private List<int> SpawnX = new List<int>();
    private List<int> SpawnY = new List<int>();
    public int SpawnPointX;
    public int SpawnPointY;
    public GameObject Spawns;
    public GameObject SpawnPrefab;

    void Start()
    {
    for(int x = 0; x <= mapData.width; x++) {
        for(int y = 0; y <= mapData.height; y++) {
          if (mapData.map[x,y] == 0) {
        SpawnX.Add(x);
        SpawnY.Add(y);
      }
    }
  }
    Debug.Log(SpawnX.Count);
    int i = Random.Range (0, SpawnX.Count);
    float posX = -mapData.width/2 + SpawnX[i] + 0.5f;
    float posY = -mapData.height/2 + SpawnY[i] + 0.5f;
    Debug.Log(posX + " " + posY);
    GameObject Spawn = (GameObject)Instantiate(SpawnPrefab, transform.position = new Vector2(posX, posY), Quaternion.identity);
    Spawn.GetComponent<SpriteRenderer>().color = Color.green;
    SpawnPointX = SpawnX[i];
    SpawnPointY = SpawnY[i];

  }
}
