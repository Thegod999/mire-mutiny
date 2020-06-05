using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallData : MonoBehaviour
{
    public MapGenerator mapData;
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
      for (int x = -1; x <= +1; x++) {
        for (int y = -1; y <= +1; y++) {
          if (mapData.map[mapX+x,mapY+y] == 0) {
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
      if (TL == true) {
        GetComponent<SpriteRenderer>().sprite = sprites[0];
      }
      if (TR == true) {
        GetComponent<SpriteRenderer>().sprite = sprites[2];
      }
      if (BL == true) {
        GetComponent<SpriteRenderer>().sprite = sprites[5];
      }
      if (BR == true) {
        GetComponent<SpriteRenderer>().sprite = sprites[7];
      }
      if (TM == true) {
        GetComponent<SpriteRenderer>().sprite = sprites[1];
      }
      if (ML == true) {
        GetComponent<SpriteRenderer>().sprite = sprites[3];
      }
      if (MR == true) {
        GetComponent<SpriteRenderer>().sprite = sprites[4];
      }
      if (BM == true) {
        GetComponent<SpriteRenderer>().sprite = sprites[6];
      }
      if (TM == true && ML == true) {
        GetComponent<SpriteRenderer>().sprite = sprites[8];
      }
      if (ML == true && BM == true) {
        GetComponent<SpriteRenderer>().sprite = sprites[9];
      }
      if (BM == true && MR == true) {
        GetComponent<SpriteRenderer>().sprite = sprites[10];
      }
      if (MR == true && TM == true) {
        GetComponent<SpriteRenderer>().sprite = sprites[11];
      }
      if (TM == true && BM == true) {
        GetComponent<SpriteRenderer>().sprite = sprites[12];
      }
      if (ML == true && MR == true) {
        GetComponent<SpriteRenderer>().sprite = sprites[13];
      }
      if (ML == true && TM == true && MR == true) {
        GetComponent<SpriteRenderer>().sprite = sprites[14];
      }
      if (BM == true && ML == true && TM == true) {
        GetComponent<SpriteRenderer>().sprite = sprites[15];
      }
      if (MR == true && BM == true && ML == true) {
        GetComponent<SpriteRenderer>().sprite = sprites[16];
      }
      if (TM == true && MR == true && BM == true) {
        GetComponent<SpriteRenderer>().sprite = sprites[17];
      }
      if (TM == true && MR == true && BM == true && ML == true) {
        GetComponent<SpriteRenderer>().sprite = sprites[18];
      }
      }
}
