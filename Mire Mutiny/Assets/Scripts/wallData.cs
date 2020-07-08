using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallData : MonoBehaviour
{
    public MapGenerator mapData;
    public bool visual = false;
    public int mapX;
    public int mapY;
    public int surroundingWallCount = 8;
    public List<Sprite> sprites;
    public bool TL = false;
    public bool TM = false;
    public bool TR = false;
    public bool ML = false;
    public bool MR = false;
    public bool BL = false;
    public bool BM = false;
    public bool BR = false;

    void Start()
    {
      if (visual == false) {
      for (int x = -1; x <= 1; x++) {
        for (int y = -1; y <= 1; y++) {
          int ix = mapX + x;
          int iy = mapY + y;
          if (mapData.map[ix,iy] == 0 || mapData.map[ix,iy] == 2) {
            surroundingWallCount --;
            mapData.map[ix, iy] = 2;
            if (x == -1 && y == -1) {
              BL = true;
            }
            if (x == 0 && y == -1) {
              BM = true;
            }
            if (x == 1 && y == -1) {
              BR = true;
            }
            if (x == -1 && y == 0) {
              ML = true;
            }
            if (x == 1 && y == 0) {
              MR = true;
            }
            if (x == -1 && y == 1) {
              TL = true;
            }
            if (x == 0 && y == 1) {
              TM = true;
            }
            if (x == 1 && y == 1) {
              TR = true;
            }
          }
        }
      }
      if (mapX == 0) {
        if (mapData.map[mapX+1, mapY] == 0) {
        MR = true;
        }
      }
      else {
      }
      if (mapX == mapData.width) {
        if (mapData.map[mapX-1, mapY] == 0) {
        ML = true;
        }
      }
      if (mapY == 0) {
        if (mapData.map[mapX, mapY+1] == 0) {
        TM = true;
        }
      }
      if (mapY == mapData.height) {
        if (mapData.map[mapX, mapY-1] == 0) {
        BM = true;
        }
      }
      if(surroundingWallCount == 8) {
        Destroy(this.gameObject);
      }
      if (BM == true) {
        float posX = this.transform.position.x;
        float posY = this.transform.position.y - 1f;
        GameObject Ground = (GameObject)Instantiate(mapData.GroundPrefab, transform.position = new Vector2(posX, posY), Quaternion.identity);
        Ground.GetComponent<wallData>().visual = true;
        this.gameObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1f,0);
      }
      if (TL == true) {
        this.GetComponent<SpriteRenderer>().sprite = sprites[0];
      }
      if (TR == true) {
        this.GetComponent<SpriteRenderer>().sprite = sprites[1];
      }
      if (BL == true) {
        this.GetComponent<SpriteRenderer>().sprite = sprites[2];
      }
      if (BR == true) {
        this.GetComponent<SpriteRenderer>().sprite = sprites[3];
      }
      if (TM == true) {
        this.GetComponent<SpriteRenderer>().sprite = sprites[4];
      }
      if (ML == true) {
        this.GetComponent<SpriteRenderer>().sprite = sprites[5];
      }
      if (MR == true) {
        this.GetComponent<SpriteRenderer>().sprite = sprites[6];
      }
      if (BM == true) {
        this.GetComponent<SpriteRenderer>().sprite = sprites[7];
      }
      if (TM == true && ML == true) {
        this.GetComponent<SpriteRenderer>().sprite = sprites[8];
      }
      if (ML == true && BM == true) {
        this.GetComponent<SpriteRenderer>().sprite = sprites[9];
      }
      if (BM == true && MR == true) {
        this.GetComponent<SpriteRenderer>().sprite = sprites[10];
      }
      if (MR == true && TM == true) {
        this.GetComponent<SpriteRenderer>().sprite = sprites[11];
      }
      if (TM == true && BM == true) {
        this.GetComponent<SpriteRenderer>().sprite = sprites[12];
      }
      if (ML == true && MR == true) {
        this.GetComponent<SpriteRenderer>().sprite = sprites[13];
      }
      if (ML == true && TM == true && MR == true) {
        this.GetComponent<SpriteRenderer>().sprite = sprites[14];
      }
      if (BM == true && ML == true && TM == true) {
        this.GetComponent<SpriteRenderer>().sprite = sprites[15];
      }
      if (MR == true && BM == true && ML == true) {
        this.GetComponent<SpriteRenderer>().sprite = sprites[16];
      }
      if (TM == true && MR == true && BM == true) {
        this.GetComponent<SpriteRenderer>().sprite = sprites[17];
      }
      if (TM == true && MR == true && BM == true && ML == true) {
        this.GetComponent<SpriteRenderer>().sprite = sprites[18];
      }
    }
    else {
      this.GetComponent<SpriteRenderer>().sprite = sprites[19];
      this.GetComponent<BoxCollider2D>().enabled = false;
    }
  }
}
