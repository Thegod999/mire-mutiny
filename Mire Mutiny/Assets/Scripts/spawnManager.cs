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
    public int EndPointX;
    public int EndPointY;
    public int Dis;
    public GameObject Spawn;
    public GameObject SpawnPrefab;
    public GameObject End;
    public GameObject EndPrefab;

    void Start() {
      FindAvailablePoints();
      for(int i = 0; i <= SpawnX.Count; i ++) {
      MeetsExpectations(SpawnX[i],SpawnY[i]);
      }
    }
    void Update() {
      int i = Random.Range(0,SpawnX.Count+1);
      float posX = -mapData.width/2 + SpawnX[i] + 0.5f;
      float posY = -mapData.height/2 + SpawnY[i] + 0.5f;
      GameObject Spawn = (GameObject)Instantiate(SpawnPrefab, transform.position = new Vector2(posX, posY), Quaternion.identity);
      SpawnPointX = SpawnX[i];
      SpawnPointY = SpawnY[i];

      int e = Random.Range(0,SpawnX.Count+1);
      EndPointX = SpawnX[e];
      EndPointY = SpawnY[e];
      Dis = GetDistance(SpawnPointX, SpawnPointY, SpawnX[e], SpawnY[e]);
      while(Dis <= mapData.endFromSpawnDis) {
        e = Random.Range(0,SpawnX.Count+1);
        Dis = GetDistance(SpawnPointX, SpawnPointY, SpawnX[e], SpawnY[e]);
      }
      float eposX = -mapData.width/2 + SpawnX[e] + 0.5f;
      float eposY = -mapData.height/2 + SpawnY[e] + 0.5f;
      GameObject End = (GameObject)Instantiate(EndPrefab, transform.position = new Vector2(eposX, eposY), Quaternion.identity);
      EndPointX = SpawnX[e];
      EndPointY = SpawnY[e];

      GameObject player = GameObject.FindGameObjectWithTag("playerCharacter");
      player.transform.position = Spawn.transform.position;

      this.gameObject.SetActive(false);
    }

    int GetDistance(int spawnX, int spawnY, int endX, int endY) {
      int dstX = Mathf.Abs(spawnX - endX);
      int dstY = Mathf.Abs(spawnY - endY);

      if (dstX > dstY)
        return 14*dstY + 10* (dstX-dstY);
        return 14*dstX + 10 * (dstY-dstX);
    }

    void FindAvailablePoints(){
      for (int x = 0; x < mapData.width; x ++) {
        for (int y = 0; y < mapData.height; y ++) {
          if (mapData.map[x,y] == 0) {
            SpawnX.Add(x);
            SpawnY.Add(y);
        }
      }
    }
  }
  void MeetsExpectations(int x, int y) {
    int i = 0;
    for(int sX = x-mapData.spawnDis; sX < mapData.spawnDis; sX++) {
      for(int sY = y-mapData.spawnDis; sY < mapData.spawnDis; sY++) {
      if (mapData.map[sX,sY] == 1) {
        i ++;
        }
      }
    }
    if (i != 0) {
      SpawnX.Remove(x);
      SpawnY.Remove(y);
    }
    Debug.Log("Tested");
  }
}
