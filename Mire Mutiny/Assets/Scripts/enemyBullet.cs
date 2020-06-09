using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    public float speed;
    public float lifeSeconds;
    public int randomValue;
    public GameObject BulletPrefab;

    // Update is called once per frame
    void Update()
    {
        randomValue = Random.Range(1, 4);
//        Debug.Log(randomValue);
        if (gameObject.name.Contains("(Clone)")) {
            lifeSeconds -= Time.deltaTime;
        }

        transform.Translate(Vector2.up * speed * .001f);
        if (lifeSeconds <= 0 && gameObject.name.Contains("(Clone)")) {
            Destroy(gameObject);

        }
    }
}
