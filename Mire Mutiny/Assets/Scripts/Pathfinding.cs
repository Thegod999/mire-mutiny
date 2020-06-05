using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour {

  public MapGenerator mapG;
  public List<Coord> allCoord = new List<Coord>();
	void Start() {
		CreateCoordMap();
    FindEachNeighbour();
	}

	public void GoFindPath(Vector2 startPos, Vector2 targetPos, Enemy c) {
		Coord startCoord = new Coord(0,0, mapG);
		Coord targetCoord = new Coord(0,0, mapG);
    List<Coord> openList = new List<Coord>();
		List<Coord> closedList = new List<Coord>();

    foreach (Coord coord in allCoord) {
      if (coord.mapPosX == Mathf.RoundToInt(startPos.x - 0.5f + -mapG.width/-2) && coord.mapPosY == Mathf.RoundToInt(startPos.y - 0.5f + -mapG.height/-2)) {
        startCoord = coord;
      }
    }
    foreach (Coord coord in allCoord) {
      if (coord.mapPosX == Mathf.RoundToInt(targetPos.x - 0.5f + -mapG.width/-2) && coord.mapPosY == Mathf.RoundToInt(targetPos.y - 0.5f + -mapG.height/-2)) {
        targetCoord = coord;
        targetCoord.isTarget = true;
      }
    }

    openList.Add(startCoord);
		while (openList.Count > 0) {
			Coord currentCoord = openList[0];
			for (int i = 1; i < openList.Count; i ++) {
				if (openList[i].fCost < currentCoord.fCost || openList[i].fCost == currentCoord.fCost) {
					if (openList[i].hCost < currentCoord.hCost)
						currentCoord = openList[i];
				}
			}

			openList.Remove(currentCoord);
			closedList.Add(currentCoord);

			if (currentCoord == targetCoord) {
				c.Path = ReversePath(startCoord, targetCoord);
				return;
			}

			foreach (Coord neighbour in currentCoord.neighbouringCoords) {
				if (closedList.Contains(neighbour)) {
					continue;
				}

				int newCostToNeighbour = currentCoord.gCost + GetDistance(currentCoord, neighbour);
				if (newCostToNeighbour < neighbour.gCost || !openList.Contains(neighbour)) {
					neighbour.gCost = newCostToNeighbour;
					neighbour.hCost = GetDistance(neighbour, targetCoord);
					neighbour.parent = currentCoord;

					if (!openList.Contains(neighbour))
						openList.Add(neighbour);
				}
			}
		}
	}

  public List<Coord> ReversePath (Coord startCoord, Coord targetCoord) {
    List<Coord> path = new List<Coord>();
		Coord currentCoord = targetCoord;

		while (currentCoord != startCoord) {
			path.Add(currentCoord);
			currentCoord = currentCoord.parent;
		}
		path.Reverse();
    return path;
  }

  public void CreateCoordMap() {
    for (int x = 0; x < mapG.width; x ++) {
      for (int y = 0; y < mapG.height; y++) {
        if (mapG.map[x,y] == 0) {
          Coord currentCoord = new Coord(x, y, mapG);
          allCoord.Add(currentCoord);
        }
      }
    }
  }
  public void FindEachNeighbour() {
    foreach (Coord coord in allCoord) {
      coord.neighbouringCoords = findNeighbours(coord);
    }
  }
  public List<Coord> findNeighbours(Coord coord) {
    List<Coord> coordsFound = new List<Coord>();
    for (int x = -1; x <= +1; x ++) {
      for (int y = -1; y <= +1; y ++) {
        int cX = coord.mapPosX + x;
        int cY = coord.mapPosY + y;

        if (x == 0 && y == 0) {
          continue;
        }
        for (int i = 0; i < allCoord.Count; i ++) {
          if (x != cX && y != cY) {
          if (allCoord[i].mapPosX == cX && allCoord[i].mapPosY == cY) {
            coordsFound.Add(allCoord[i]);
          }
        }
      }
    }
  }
    return coordsFound;
}

	int GetDistance(Coord CoordA, Coord CoordB) {
		int dstX = Mathf.Abs(CoordA.mapPosX - CoordB.mapPosX);
		int dstY = Mathf.Abs(CoordA.mapPosY - CoordB.mapPosY);

		if (dstX > dstY)
			return 14*dstY + 10* (dstX-dstY);
		  return 14*dstX + 10 * (dstY-dstX);
	}
}
﻿
