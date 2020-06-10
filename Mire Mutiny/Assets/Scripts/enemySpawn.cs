using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
  public enemyManager eM;
  public bool IsStray = false;

  public List<GameObject> enemiesInCamp = new List<GameObject>();
  public int minCampSize;
  public int maxCampSize;
  public int CampSize;

}
