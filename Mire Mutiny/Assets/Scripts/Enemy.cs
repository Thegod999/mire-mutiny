using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy : MonoBehaviour
{
    public float speed;
    public bool test = false;
    public Vector2 startSpot;
    public Vector2 moveSpot;
    public float maxMoveX;
    public float maxMoveY;
    public bool move = false;
    public MapGenerator mapG;
    public Pathfinding p;
    public List<Coord> Path = new List<Coord>();
    public float secondsBetweenActions;
    public float currentBetween;
    void Start() {


    }

  public void Update() {
    if (Path.Count == 0) {
      currentBetween -= Time.deltaTime * 1 / secondsBetweenActions;
    }
    else {
      currentBetween = secondsBetweenActions;
    }

    if (currentBetween <= 0) {
      FindMoveSpot();
    }
    if (Path.Count != 0) {
      float step = speed * Time.deltaTime;
      transform.position = Vector2.MoveTowards(transform.position, Path[0].currentSpot, step);
      if (transform.position == Path[0].currentSpot){
        Path.Remove(Path[0]);
      }
    }
  }
  public void FindMoveSpot() {
    Vector2 move = new Vector2(Random.Range(transform.position.x-maxMoveX, transform.position.x+maxMoveX+1), Random.Range(transform.position.y-maxMoveY, transform.position.y+maxMoveY+1));
    while (mapG.map[Mathf.RoundToInt(move.x - 0.5f + -mapG.width/-2), Mathf.RoundToInt(move.y - 0.5f + -mapG.height/-2)] == 1) {
      move = new Vector2(Random.Range(transform.position.x-maxMoveX, transform.position.x+maxMoveX+1), Random.Range(transform.position.y-maxMoveY, transform.position.y+maxMoveY+1));
    }
    p.GoFindPath(this.transform.position, move, this.GetComponent<Enemy>());
  }

  public void OnTriggerEnter2D(Collider col) {
    if (col.gameObject.name == "Player") {
      test = true;
      Path = new List<Coord>();
      Debug.Log("FoundCharacter");
      p.GoFindPath(this.transform.position, col.gameObject.transform.position, this.GetComponent<Enemy>());
    }
  }
}
