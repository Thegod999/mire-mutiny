using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
  public enemyManager eM;
  public bool IsStray = false;

  public GameObject Enemy;
  public GameObject EnemyPrefab;
  public GameObject CampModerator;
  public GameObject CampModeratorPrefab;

  public int minCampSize;
  public int maxCampSize;
  public int CampSize;

    void Start()
    {
      if (IsStray == true) {
        StraySpawn();
      }
      else {
        CampSpawn();
      }
    }


    public void StraySpawn() {
      GameObject Enemy = (GameObject)Instantiate(EnemyPrefab, transform.position = new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);

    }

    public void CampSpawn() {
      CampSize = UnityEngine.Random.Range(minCampSize, maxCampSize);
      GameObject CampModerator = (GameObject)Instantiate(CampModeratorPrefab, transform.position = new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);

      for (int i = 0; i < CampSize; i ++) {
        GameObject Enemy = (GameObject)Instantiate(EnemyPrefab, transform.position = new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);

      }
    }
}
