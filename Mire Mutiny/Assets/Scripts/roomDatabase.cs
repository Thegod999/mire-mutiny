using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomDatabase : MonoBehaviour{
  public GameObject[] bottomRooms;
  public GameObject[] topRooms;
  public GameObject[] leftRooms;
  public GameObject[] rightRooms;
  public GameObject closedRooms;
  public List<GameObject> rooms;
  public float waitTime = 3f;
  private bool spawnedBoss;
  public GameObject boss;
  void Update(){
    if(waitTime <= 0 && spawnedBoss == false){
      for(int i = 0; i < rooms.Count; i++){
        if(i == rooms.Count-1){
          Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
          spawnedBoss = true;
        }
      }
    }
    else {
      waitTime -= Time.deltaTime;
    }
  }
}
