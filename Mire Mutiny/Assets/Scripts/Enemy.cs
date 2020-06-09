using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int enemyLevel;
    public bool test = false;
    public Vector2 startSpot;
    public Vector2 moveSpot;
    public float maxMoveX;
    public float maxMoveY;
    public bool move = false;

    public MapGenerator mapG;
    public GameObject player;
    public Pathfinding p;

    public List<Coord> Path = new List<Coord>();
    public Vector2 ShootSpot;

    public GameObject Bullet;
    public GameObject BulletPrefab;

    public float secondsBetweenActions;
    public float currentBetween;
    public bool betweenAction = true;
    public bool isMove = false;
    public bool isShoot = false;
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
      int i = DetermineAction();
      if (i == 0) {
      FindMoveSpot();
      }
      if (i == 1) {
      FindShootSpot();
      }
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
    Debug.Log("Moving");
    Vector2 move = new Vector2(Random.Range(transform.position.x-maxMoveX, transform.position.x+maxMoveX+1), Random.Range(transform.position.y-maxMoveY, transform.position.y+maxMoveY+1));
    while (mapG.map[Mathf.RoundToInt(move.x - 0.5f + -mapG.width/-2), Mathf.RoundToInt(move.y - 0.5f + -mapG.height/-2)] == 1) {
      move = new Vector2(Random.Range(transform.position.x-maxMoveX, transform.position.x+maxMoveX+1), Random.Range(transform.position.y-maxMoveY, transform.position.y+maxMoveY+1));
    }
    if (test == true) {
      move = new Vector2(player.transform.position.x, player.transform.position.y);
    }
    p.GoFindPath(this.transform.position, move, this.GetComponent<Enemy>());
  }
  public void FindShootSpot() {
    Debug.Log("Shooting");
    Player pl = player.GetComponent<Player>();
    Vector3 offset = new Vector3(0,0,0);
    Vector3 dir = new Vector3(0,0,0);

    if (enemyLevel == 0) {
    offset = new Vector3 (player.transform.position.x, player.transform.position.y, 0);
    dir = offset - this.transform.position;
    }

    if (enemyLevel == 1) {
    offset = new Vector3 (player.transform.position.x + pl.moveLoc.x, player.transform.position.y + pl.moveLoc.y);
    dir = offset - this.transform.position;
    }

    ShootSpot = offset;
    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
    GameObject Bullet = (GameObject)Instantiate(BulletPrefab, new Vector2 (this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, angle));
    currentBetween = secondsBetweenActions;
    isShoot = false;
    isMove = false;
  }
  public void OnTriggerEnter2D(Collider col) {
    if (col.gameObject.name == "Player") {
      test = true;
      Path = new List<Coord>();
      Debug.Log("FoundCharacter");
      }
    }
  public void OnTriggerExit2D(Collider col) {
    if (col.gameObject.name == "Player") {
      test = false;
    }
  }

  public int DetermineAction() {
    int i = 0;
    if (test == true) {
      i = (Mathf.RoundToInt(Random.Range(0, 2)) < 1)? 0 : 1;
    }
    return i;
  }
}
