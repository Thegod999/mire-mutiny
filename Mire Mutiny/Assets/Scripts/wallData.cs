using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallData : MonoBehaviour
{
    public MapGenerator mapData;
    public int mapX;
    public int mapY;
    public int surroundingWallCount = 8;
    void Start()
    {
      CheckSurroundingWallCount();
      if (surroundingWallCount < 8) {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
      }
    }

    void CheckSurroundingWallCount() {
      for (int x = mapX-1; x <= mapX+1; x++) {
        for (int y = mapY-1; y <= mapY+1; y++) {
          if (mapData.map[x,y] == 0) {
            surroundingWallCount --;
          }
        }
      }
    }
}
