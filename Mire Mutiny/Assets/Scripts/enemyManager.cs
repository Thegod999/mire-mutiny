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
  [Range(0,50)]
  public int minCampSpawn;
  [Range(0,50)]
  public int maxCampSpawn;

  public int TotalEnemyCampCount;
  public int TotalStrayEnemyCount;
  public int EnemyCampCount = 0;
  public int StrayEnemyCount = 0;
  public GameObject Enemy;
  public GameObject EnemyPrefab;
  public GameObject EnemySpawns;
  public GameObject EnemySpawnsPrefab;

  public List<int> EnemyX = new List<int>();
  private List<int> EnemyY = new List<int>();

  public List<int[,]> EnemyCampLoc = new List<int[,]>();
  public List<int[,]> EnemyStrayLoc = new List<int[,]>();


    void Start() {
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
    Debug.Log(EnemyX.Count);
  }
  void Update() {
    if (StrayEnemyCount < TotalStrayEnemyCount) {
    MakeStrays();
  }
  if (EnemyCampCount < TotalEnemyCampCount) {
    MakeCamps();
  }
    if (EnemyCampCount >= TotalEnemyCampCount && StrayEnemyCount >= TotalStrayEnemyCount) {
    this.gameObject.SetActive(false);
    }
  }
  public void MakeStrays() {
    Debug.Log("Making Enemies");
      int i = UnityEngine.Random.Range (0, EnemyX.Count);
      float posX = -mapData.width/2 + EnemyX[i] + 0.5f;
      float posY = -mapData.height/2 + EnemyY[i] + 0.5f;
      GameObject Enemy = (GameObject)Instantiate(EnemyPrefab, transform.position = new Vector2(posX, posY), Quaternion.identity);
      EnemySpawns.GetComponent<Enemy>().isStray = true;
    }
  public void MakeCamps() {
    Debug.Log("Making Camps");
      int ECi = UnityEngine.Random.Range (0, EnemyX.Count);
      float ECX = -mapData.width/2 + EnemyX[ECi] + 0.5f;
      float ECY = -mapData.height/2 + EnemyY[ECi] + 0.5f;
      GameObject EnemySpawns = (GameObject)Instantiate(EnemySpawnsPrefab, transform.position = new Vector2(ECX, ECY), Quaternion.identity);
      EnemySpawns.GetComponent<SpriteRenderer>().color = Color.blue;
      EnemySpawns.GetComponent<enemySpawn>().CampSize = Random.Range(minCampSpawn, maxCampSpawn + 1);
  }
}
