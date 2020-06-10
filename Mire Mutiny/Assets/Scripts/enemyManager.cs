using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
  public MapGenerator mapData;
  public spawnManager player;
  public int playerSafe;
  [Range(0,50)]
  public int minTotalStrayEnemyCount;
  [Range(0,50)]
  public int maxTotalStrayEnemyCount;
  [Range(0,50)]
  public int minTotalEnemyCampCount;
  [Range(0,50)]
  public int maxTotalEnemyCampCount;
  [Range(0,50)]
  public float minSpawnDistance;
  [Range(0,50)]
  public float maxSpawnDistance;

  public int TotalEnemyCampCount;
  public int TotalStrayEnemyCount;
  public GameObject Enemy;
  public GameObject EnemyPrefab;
  public GameObject EnemySpawns;
  public GameObject EnemySpawnsPrefab;

  private List<int> EnemyX = new List<int>();
  private List<int> EnemyY = new List<int>();

  public List<int[,]> EnemyCampLoc = new List<int[,]>();
  public List<int[,]> EnemyStrayLoc = new List<int[,]>();


    void Awake() {
      TotalEnemyCampCount = Random.Range(minTotalEnemyCampCount, maxTotalEnemyCampCount + 1);
      TotalStrayEnemyCount = Random.Range(minTotalStrayEnemyCount, maxTotalStrayEnemyCount + 1);

    for (int x = 0; x < mapData.width; x ++) {
      for (int y = 0; y < mapData.height; y ++) {
        if (mapData.map[x,y] == 0) {
          EnemyX.Add(x);
          EnemyY.Add(y);
        }
      }
    }
  }
  void Start() {
    MakeStrays();
    MakeCamps();
  }
  public void MakeStrays() {
    Debug.Log("Making Enemies");
    int StrayCount = 0;
    while(StrayCount < TotalStrayEnemyCount) {
      int i = UnityEngine.Random.Range (0, EnemyX.Count);
      float posX = -mapData.width/2 + EnemyX[i] + 0.5f;
      float posY = -mapData.height/2 + EnemyY[i] + 0.5f;
      GameObject Enemy = (GameObject)Instantiate(EnemyPrefab, transform.position = new Vector2(posX, posY), Quaternion.identity);
      EnemySpawns.GetComponent<Enemy>().isStray = true;
      StrayCount += 1;
      }
    }
  public void MakeCamps() {
    Debug.Log("Making Camps");
    int GetCampCount = 0;
    while (GetCampCount < TotalEnemyCampCount) {
      int ECi = UnityEngine.Random.Range (0, EnemyX.Count);
      float ECX = -mapData.width/2 + EnemyX[ECi] + 0.5f;
      float ECY = -mapData.height/2 + EnemyY[ECi] + 0.5f;
      GameObject EnemySpawns = (GameObject)Instantiate(EnemySpawnsPrefab, transform.position = new Vector2(ECX, ECY), Quaternion.identity);
      EnemySpawns.GetComponent<SpriteRenderer>().color = Color.blue;
        for (int i = 0; i < EnemySpawns.GetComponent<enemySpawn>().CampSize; i++) {
          float posX = Random.Range(minSpawnDistance, maxSpawnDistance + 1);
          float posY = Random.Range(minSpawnDistance, maxSpawnDistance + 1);
          GameObject Enemy = (GameObject)Instantiate(EnemyPrefab, transform.position = new Vector2(EnemySpawns.transform.position.x, EnemySpawns.transform.position.y), Quaternion.identity);
          Enemy.GetComponent<Enemy>().inCamp = true;
          Enemy.GetComponent<Enemy>().campMod = EnemySpawns;
        }
    }
  }
}
