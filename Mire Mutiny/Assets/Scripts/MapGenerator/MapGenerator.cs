using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MapGenerator : MonoBehaviour
{
  [Range(0,100)]
  public int minWidth;
  [Range(0,100)]
  public int maxWidth;
  [Range(0,100)]
  public int minHeight;
  [Range(0,100)]
  public int maxHeight;

  public int width;
  public int height;

  public int spawnDis;
  public int endFromSpawnDis;

  public int smoothness;
  public int extrudeFromEdge;
  [Range(1,100)]
  public int roomThresholdSize;
  [Range(1,100)]
  public int wallThresholdSize;
  [Range(1,100)]
  public int pathThickness;

  public string seed;
  public bool useRandomSeed;

  [Range(0,100)]
  public int randomFillPercent;

  public GameObject GroundPrefab;
  public GameObject GroundPrefabClone;
  public GameObject MapGen;
  private float RandValue;

  private bool smooth = false;

  public int [,] map;
  public int currentLV;



  void Start() {
    currentLV = PlayerPrefs.GetInt("currentLevel", 0) + 1;
    PlayerPrefs.SetInt("currentLevel", currentLV);
    width = UnityEngine.Random.Range(minWidth, maxWidth);
    height = UnityEngine.Random.Range(minHeight, maxHeight);
    RandValue = UnityEngine.Random.Range(-214748364.0f, 214748364.0f);
    seed = RandValue.ToString();
    GenerateMap();
    OnDrawMap();
    }


  void GenerateMap() {
    map = new int[width,height];
    RandomFillMap();
    for (int i = 0; i < smoothness + 1; i ++) {
      if (smooth == false) {
        SmoothMap();
        smooth = true;
        }
      }
    ProcessMap();
    }

    void ProcessMap() {
		List<List<Coord>> wallRegions = GetRegions (1);


		foreach (List<Coord> wallRegion in wallRegions) {
			if (wallRegion.Count < wallThresholdSize) {
				foreach (Coord tile in wallRegion) {
					map[tile.tileX,tile.tileY] = 2;
				}
			}
		}

		List<List<Coord>> roomRegions = GetRegions (0);

    List<Room> survivingRooms = new List<Room>();

		foreach (List<Coord> roomRegion in roomRegions) {
			if (roomRegion.Count < roomThresholdSize) {
				foreach (Coord tile in roomRegion) {
					map[tile.tileX,tile.tileY] = 1;
				}
			}
      else {
      survivingRooms.Add(new Room(roomRegion, map));
      }
		}
          survivingRooms.Sort ();
          survivingRooms[0].isMainRoom = true;
          survivingRooms[0].isAccessibleFromMainRoom = true;
          ConnectClosestRooms (survivingRooms);
	}

  void ConnectClosestRooms(List<Room> allRooms, bool forceAccessibilityFromMainRoom = false) {

      List<Room> roomListA = new List<Room> ();
      List<Room> roomListB = new List<Room> ();

      if (forceAccessibilityFromMainRoom){
        foreach (Room room in allRooms) {
          if (room.isAccessibleFromMainRoom) {
            roomListB.Add(room);
          }
          else {
            roomListA.Add(room);
          }
        }
      }
          else {
              roomListA = allRooms;
              roomListB = allRooms;
      }

  		int bestDistance = 0;
  		Coord bestTileA = new Coord ();
  		Coord bestTileB = new Coord ();
  		Room bestRoomA = new Room ();
  		Room bestRoomB = new Room ();
  		bool possibleConnectionFound = false;

  		foreach (Room roomA in roomListA) {
        if (!forceAccessibilityFromMainRoom) {
          possibleConnectionFound = false;
          if (roomA.connectedRooms.Count > 0) {
            continue;
          }
        }
  			foreach (Room roomB in roomListB) {
  				if (roomA == roomB || roomA.IsConnected(roomB)) {
  					continue;
  				}
  				for (int tileIndexA = 0; tileIndexA < roomA.edgeTiles.Count; tileIndexA ++) {
  					for (int tileIndexB = 0; tileIndexB < roomB.edgeTiles.Count; tileIndexB ++) {
  						Coord tileA = roomA.edgeTiles[tileIndexA];
  						Coord tileB = roomB.edgeTiles[tileIndexB];
  						int distanceBetweenRooms = (int)(Mathf.Pow (tileA.tileX-tileB.tileX,2) + Mathf.Pow (tileA.tileY-tileB.tileY,2));

  						if (distanceBetweenRooms < bestDistance || !possibleConnectionFound) {
  							bestDistance = distanceBetweenRooms;
  							possibleConnectionFound = true;
  							bestTileA = tileA;
  							bestTileB = tileB;
  							bestRoomA = roomA;
  							bestRoomB = roomB;
  						}
  					}
  				}
  			}
      if (!possibleConnectionFound) {
        break;
      }
  		if (possibleConnectionFound && !forceAccessibilityFromMainRoom) {
  			CreatePassage(bestRoomA, bestRoomB, bestTileA, bestTileB);
        ConnectClosestRooms(allRooms, true);
  		}
  	}
      if (possibleConnectionFound && !forceAccessibilityFromMainRoom) {
        CreatePassage(bestRoomA, bestRoomB, bestTileA, bestTileB);
        ConnectClosestRooms(allRooms, true);
      }

      if(!forceAccessibilityFromMainRoom) {
        ConnectClosestRooms(allRooms, true);
      }
  	}
    void CreatePassage(Room roomA, Room roomB, Coord tileA, Coord tileB) {
  		Room.ConnectRooms (roomA, roomB);
  		Debug.DrawLine (CoordToWorldPoint (tileA), CoordToWorldPoint (tileB), Color.green, 100);

  		List<Coord> line = GetLine (tileA, tileB);
  		foreach (Coord c in line) {
  			DrawCircle(c,pathThickness);
  		}
  	}

  	void DrawCircle(Coord c, int r) {
  		for (int x = -r; x <= r; x++) {
  			for (int y = -r; y <= r; y++) {
  				if (x*x + y*y <= r*r) {
  					int drawX = c.tileX + x;
  					int drawY = c.tileY + y;
  					if (IsInMapRange(drawX, drawY)) {
  						map[drawX,drawY] = 0;
            }
  		    }
  	    }
      }
    }


    List<Coord> GetLine(Coord from, Coord to) {
  		List<Coord> line = new List<Coord> ();

  		int x = from.tileX;
  		int y = from.tileY;

  		int dx = to.tileX - from.tileX;
  		int dy = to.tileY - from.tileY;

  		bool inverted = false;
  		int step = Math.Sign (dx);
  		int gradientStep = Math.Sign (dy);

  		int longest = Mathf.Abs (dx);
  		int shortest = Mathf.Abs (dy);

  		if (longest < shortest) {
  			inverted = true;
  			longest = Mathf.Abs(dy);
  			shortest = Mathf.Abs(dx);

  			step = Math.Sign (dy);
  			gradientStep = Math.Sign (dx);
  		}

  		int gradientAccumulation = longest / 2;
  		for (int i =0; i < longest; i ++) {
  			line.Add(new Coord(x,y));

  			if (inverted) {
  				y += step;
  			}
  			else {
  				x += step;
  			}

  			gradientAccumulation += shortest;
  			if (gradientAccumulation >= longest) {
  				if (inverted) {
  					x += gradientStep;
  				}
  				else {
  					y += gradientStep;
  				}
  				gradientAccumulation -= longest;
  			}
  		}

  		return line;
  	}

  Vector2 CoordToWorldPoint(Coord tile) {
    return new Vector2(-width/2 + 0.5f + tile.tileX, -height/2 + 0.5f + tile.tileY);
  }
	List<List<Coord>> GetRegions(int tileType) {
		List<List<Coord>> regions = new List<List<Coord>> ();
		int[,] mapFlags = new int[width,height];

		for (int x = 0; x < width; x ++) {
			for (int y = 0; y < height; y ++) {
				if (mapFlags[x,y] == 0 && map[x,y] == tileType) {
					List<Coord> newRegion = GetRegionTiles(x,y);
					regions.Add(newRegion);

					foreach (Coord tile in newRegion) {
						mapFlags[tile.tileX, tile.tileY] = 1;
					}
				}
			}
		}

		return regions;
	}

	List<Coord> GetRegionTiles(int startX, int startY) {
		List<Coord> tiles = new List<Coord> ();
		int[,] mapFlags = new int[width,height];
		int tileType = map [startX, startY];

		Queue<Coord> queue = new Queue<Coord> ();
		queue.Enqueue (new Coord (startX, startY));
		mapFlags [startX, startY] = 1;

		while (queue.Count > 0) {
			Coord tile = queue.Dequeue();
			tiles.Add(tile);

			for (int x = tile.tileX - 1; x <= tile.tileX + 1; x++) {
				for (int y = tile.tileY - 1; y <= tile.tileY + 1; y++) {
					if (IsInMapRange(x,y) && (y == tile.tileY || x == tile.tileX)) {
						if (mapFlags[x,y] == 0 && map[x,y] == tileType) {
							mapFlags[x,y] = 1;
							queue.Enqueue(new Coord(x,y));
						}
					}
				}
			}
		}

		return tiles;
	}

	bool IsInMapRange(int x, int y) {
		return x > 0 && x < width && y > 0 && y < height;
	}


	void RandomFillMap() {
		if (useRandomSeed) {
			seed = Time.time.ToString();
		}

		System.Random pseudoRandom = new System.Random(seed.GetHashCode());

		for (int x = 0; x < width; x ++) {
			for (int y = 0; y < height; y ++) {
				if (x == 0 || x == width-1 || y == 0 || y == height -1 || x < 0 || x > width || y < 0 || y > height) {
					map[x,y] = 1;
				}
        if (x < extrudeFromEdge || x > width - extrudeFromEdge || y < extrudeFromEdge || y > height - extrudeFromEdge) {
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
	}

	int GetSurroundingWallCount(int gridX, int gridY) {
		int wallCount = 0;
		for (int neighbourX = gridX - 1; neighbourX <= gridX + 1; neighbourX ++) {
			for (int neighbourY = gridY - 1; neighbourY <= gridY + 1; neighbourY ++) {
				if (IsInMapRange(neighbourX,neighbourY)) {
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

	struct Coord {
		public int tileX;
		public int tileY;

		public Coord(int x, int y) {
			tileX = x;
			tileY = y;
		}
	}

  class Room :IComparable<Room> {
		public List<Coord> tiles;
		public List<Coord> edgeTiles;
		public List<Room> connectedRooms;
		public int roomSize;
    public bool isAccessibleFromMainRoom;
    public bool isMainRoom;

		public Room() {
		}

		public Room(List<Coord> roomTiles, int[,] map) {
			tiles = roomTiles;
			roomSize = tiles.Count;
			connectedRooms = new List<Room>();
			edgeTiles = new List<Coord>();
			foreach (Coord tile in tiles) {
				for (int x = tile.tileX-1; x <= tile.tileX+1; x++) {
					for (int y = tile.tileY-1; y <= tile.tileY+1; y++) {
						if (x == tile.tileX || y == tile.tileY) {
							if (map[x,y] == 1) {
								edgeTiles.Add(tile);
							}
						}
					}
				}
			}
		}

    public void SetAccesibleFromMainRoom() {
      if (!isAccessibleFromMainRoom) {
        isAccessibleFromMainRoom = true;
        foreach (Room connectedRoom in connectedRooms) {
          connectedRoom.SetAccesibleFromMainRoom();
        }
      }
    }
		public static void ConnectRooms(Room roomA, Room roomB) {
      if (roomA.isAccessibleFromMainRoom) {
        roomB.SetAccesibleFromMainRoom();
      }
      else if (roomB.isAccessibleFromMainRoom) {
        roomA.SetAccesibleFromMainRoom();
      }
			roomA.connectedRooms.Add (roomB);
			roomB.connectedRooms.Add (roomA);
		}

		public bool IsConnected(Room otherRoom) {
			return connectedRooms.Contains(otherRoom);
		}
    public int CompareTo(Room otherRoom) {
      return otherRoom.roomSize.CompareTo (roomSize);
    }
  }

  void OnDrawMap() {
    if (map != null) {
      for (int x = 0; x < width; x ++) {
        for (int y = 0; y < height; y ++) {
          float posX = -width/2 + x + 0.5f;
          float posY = -height/2 + y + 0.5f;
          if (map[x,y] != 0 && map[x,y] != 2) {
            GameObject Ground = (GameObject)Instantiate(GroundPrefab, transform.position = new Vector2(posX, posY), Quaternion.identity);
            Ground.GetComponent<wallData>().mapX = x;
            Ground.GetComponent<wallData>().mapY = y;

          }
          else {
            map[x,y] = 0;
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
