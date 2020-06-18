using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
  public bool IsStray = false;

  public List<GameObject> enemiesInCamp = new List<GameObject>();
  public enemyManager em;
  public float EnemyRange;

  public int CampSize;

  void Start() {
    em.EnemyCampCount += 1;
    while (enemiesInCamp.Count < CampSize) {
      int i = UnityEngine.Random.Range (0, em.EnemyX.Count);
      float posX = this.transform.position.x + Random.Range(-EnemyRange, EnemyRange + 1f);
      float posY = this.transform.position.y + Random.Range(-EnemyRange, EnemyRange + 1f);
      GameObject Enemy = (GameObject)Instantiate(em.EnemyPrefab, transform.position = new Vector2(posX, posY), Quaternion.identity);
      Enemy.GetComponent<Enemy>().isStray = false;
      Enemy.GetComponent<Enemy>().campMod = this.gameObject;
      enemiesInCamp.Add(Enemy);
    }
  }
}
