using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject wallPrefab;
    public float interval = 3.0f;
    public float range = 2.0f;

    /// <summary>
    /// コルーチンを使って、壁をinterval秒ことに生成する。
    /// </summary>
    /// <returns></returns>
    IEnumerator Start()
    {
        while (!BirdControl.isGameOver)
        {
            transform.position = new Vector2(transform.position.x, Random.Range(-range, range));
            Instantiate(wallPrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(interval);
        }
    }
}
