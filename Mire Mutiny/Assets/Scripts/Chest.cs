using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public int ChestType = 1;
    public Animator anim;
    public bool playerInRange = false;
    public bool opened = false;
    public List<GameObject> possibleSpawns;
    void Start() {
      anim.SetInteger("ChestType", ChestType);
    }

    void Update() {
      if (Input.GetKey(KeyCode.E) && opened == false && playerInRange == true) {
        anim.SetTrigger("Open");
        OpenChest();
        opened = true;
      }
    }
    void OpenChest() {
      Debug.Log("ChestOpened");
      int i = Mathf.RoundToInt(Random.Range(0, possibleSpawns.Count+1));

    }
    public void OnTriggerEnter2D (Collider2D col) {
      if (col.gameObject.tag == "playerCharacter") {
        playerInRange = true;
        }
      }
}
