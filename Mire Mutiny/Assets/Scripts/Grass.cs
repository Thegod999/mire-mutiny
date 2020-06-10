using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
  public bool isVisible = true;
  public GameObject firstLayer;

  public void Start() {
    Active();
  }
  public void Active() {
    firstLayer.SetActive(isVisible);
  }

  public void OnTriggerEnter2D (Collider2D col) {
    if(col.gameObject.name == "Player") {
      isVisible = false;
      Active();
    }
  }
  public void OnTriggerExit2D (Collider2D col) {
    if(col.gameObject.name == "Player") {
      isVisible = true;
      Active();
    }
  }
}
