using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coord {
  public Coord parent;
  public List<Coord> neighbouringCoords = new List<Coord>();
  public int fCost; // Total of igCost and ihCost
  public int gCost; // Distance between Current and Parent Coord
  public int hCost; // Distance between current and end Coord
  public int mapPosX;
  public int mapPosY;
  public bool isTarget = false;
  public Vector3 currentSpot;

  //define
  public Coord(int mapPosX, int mapPosY, MapGenerator mapG) {
    this.mapPosX = mapPosX; //public variable for X axis on universal grid
    this.mapPosY = mapPosY; //public variable for Y axis on universal grid
    this.currentSpot = new Vector2(-mapG.width/2 + mapPosX + 0.5f, -mapG.height/2 + mapPosY + 0.5f);

    }
  }
