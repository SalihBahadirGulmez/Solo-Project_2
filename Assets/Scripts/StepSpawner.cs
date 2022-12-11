using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSpawner : MonoBehaviour
{
    public GameObject step;
    public GameObject ground;

    private float spawnTime = 1.2f;
    private Vector2 speed = new Vector2(0, -1f);


    public float spawnRange = -2.63f;

    // Start is called before the first frame update
    void Start()
    {
        ground.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1f);
        Destroy(ground, 11);
        StartCoroutine(SpawnObject(spawnTime));
    }

    void Update()
    {

    }
    private void FixedUpdate()
    {
       /* if (ground)
        {
            ground.transform.Translate(speed * Time.deltaTime);

        }*/

    }
    public IEnumerator SpawnObject(float time)
    {
        while (true)
        {
            Instantiate(step, new Vector3(Random.Range(-spawnRange, spawnRange), 6, 0), Quaternion.identity);

            yield return new WaitForSeconds(time);

        }

    }
}
