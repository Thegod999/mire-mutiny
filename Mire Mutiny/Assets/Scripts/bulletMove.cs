using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMove : MonoBehaviour
{
    public float speed;
    public float life;
    public int randomValue;
    public GameObject BulletPrefab;
    public GameObject splatterPrefab1;
    public GameObject splatterPrefab2;
    public GameObject splatterPrefab3;
//    private Vector3 itemLocation;
    // Start is called before the first frame update
    void Start()
    {
      speed = PlayerPrefs.GetFloat("Shot_Quickness", 120);
      life = PlayerPrefs.GetFloat("Shot_Life", 120);
    }

    // Update is called once per frame
    void Update()
    {
        randomValue = Random.Range(1, 4);
//        Debug.Log(randomValue);
        if (gameObject.name.Contains("(Clone)")) {
            life--;
        }
        speed = PlayerPrefs.GetFloat("Shot_Quickness", 120);
        transform.Translate(Vector2.up * speed * .001f);
        if (life <= 0 && gameObject.name.Contains("(Clone)")) {
//          itemLocation = gameObject.GetComponent<Transform>();
          if (randomValue == 1) {
            Instantiate(splatterPrefab1, transform.position, Quaternion.identity);
            Destroy(gameObject);
          }
          if (randomValue == 2) {
            Instantiate(splatterPrefab2, transform.position, Quaternion.identity);
            Destroy(gameObject);
          }
          if (randomValue == 3) {
            Instantiate(splatterPrefab3, transform.position, Quaternion.identity);
            Destroy(gameObject);
          }

        }
    }
}
