using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MapGenerator : MonoBehaviour
{
  [Range(0,100)]
  public int width;
  [Range(0,100)]
  public int height;

  public int smoothness;

  public string seed;
  public bool useRandomSeed;

  [Range(0,100)]
  public int randomFillPercent;

  public GameObject GroundPrefab;
  public GameObject GroundPrefabClone;
  public GameObject MapGen;
  private float RandValue;

  private bool smooth = false;

  int [,] map;

  void Start() {
    RandValue = UnityEngine.Random.Range(-214748364.0f, 214748364.0f);
    seed = RandValue.ToString();
    GenerateMap();
    }

  void GenerateMap() {
    map = new int[width,height];
    RandomFillMap();
    for (int i = 0; i < 5; i ++) {
      if (smooth == false) {
        SmoothMap();
        smooth = true;
        }
      }
    }

  void RandomFillMap() {
    if (useRandomSeed) {
      seed = Time.time.ToString();
    }

    System.Random pseudoRandom = new System.Random(seed.GetHashCode());

    for (int x = 0; x < width; x ++) {
      for (int y = 0; y < height; y ++) {
        if (x == 0 || x == width-1 || y == 0 || y == height-1) {
          map[x,y] = 1;
        }
          else {
        map[x,y] = (pseudoRandom.Next(0,100) < randomFillPercent)? 1: 0;
        }
      }
    }
  }

  void SmoothMap() {
    for (int x = 0; x < width; x ++) {
      for (int y = 0; y < height; y ++) {
        int neighbourWallTiles = GetSurroundingWallCount(x,y);

        if (neighbourWallTiles > smoothness)
          map[x,y] = 1;
          else if (neighbourWallTiles < smoothness)
            map[x,y] = 0;
      }
    }
            OnDrawMap();
  }
  int GetSurroundingWallCount(int gridX, int gridY) {
    int wallCount = 0;
    for (int neighbourX = gridX - 1; neighbourX <= gridX + 1; neighbourX ++) {
      for (int neighbourY = gridY - 1; neighbourY <= gridY + 1; neighbourY ++) {
        if (neighbourX >= 0 && neighbourX < width && neighbourY >= 0 && neighbourY < height) {
          if (neighbourX != gridX || neighbourY != gridY) {
            wallCount += map[neighbourX,neighbourY];
        }
      }
      else {
        wallCount ++;
      }
    }
  }
  return wallCount;
}
  void OnDrawMap() {
    if (map != null) {
      for (int x = 0; x < width; x ++) {
        for (int y = 0; y < height; y ++) {
          float posX = -width/2 + x + 0.5f;
          float posY = -height/2 + y + 0.5f;
          if (map[x,y] == 1) {
        	GameObject Ground = (GameObject)Instantiate(GroundPrefab, transform.position = new Vector2(posX, posY), Quaternion.identity);
          GroundPrefab.GetComponent<SpriteRenderer>().color = Color.black;
          }
        }
      }
    }
  }
  void setup(){
    RandValue = UnityEngine.Random.Range(-214748364.0f, 214748364.0f);
    seed = RandValue.ToString();
//    Debug.Log(RandValue);
  }
}
