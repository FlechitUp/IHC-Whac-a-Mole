using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject enemy;
    List<GameObject> healthPackClones = new List<GameObject>();
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnLeastWait;
    public float spawnMostWait;
    public int startWait;
    public int randmEnemy;
    public bool stop;

    int randEnemy;


	// Use this for initialization
	void Start () {
        StartCoroutine(waitSpawner());
        //StartCoroutine(DesaparecerObjs());

    }
	
	// Update is called once per frame
	void Update () {
        //spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
        moveMole();

    }

    void moveMole()
    {
        spawnWait = Random.Range(2, 5); //tiempo aleatorio
        randmEnemy = Random.Range(0, 4);  // enemigo aleatorio para desaparecer

        //Debug.Log("spawnWait "+spawnWait);
        Debug.Log("My randmEnemy " + randmEnemy);
        //DesaparecerObjs();
        if (healthPackClones[randEnemy].transform.position.y < 10f)
        {
            subir(randEnemy);
            Debug.Log("Pos" + healthPackClones[randEnemy].transform.position.y);
        }
        else { 
            bajar(randEnemy);
        }   

    }

    void subir(int posEnemy)
    {
        Vector3 mypos = healthPackClones[posEnemy].transform.position;

        healthPackClones[posEnemy].transform.Translate(0,0.5f, 0);///(Vector3.forward * Time.deltaTime);
        //yield return new WaitForSeconds(10);
        //healthPackClones[posEnemy].transform.Translate(Vector3.up * Time.deltaTime, Space.World);//(mypos);
    }

    void bajar(int posEnemy)
    {
        healthPackClones[posEnemy].transform.Translate(0,-0.5F, 0, Space.World);
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        for(int i = 0; i < 5; i++)
        {
            Vector3 spawnPosition = new Vector3(-spawnValues.x+2.0f+i, 1, -spawnValues.z);
            healthPackClones.Add(Instantiate(enemy, spawnPosition + transform.TransformPoint(0, 0, 0),gameObject.transform.rotation));     
        }

       
        // yield return new WaitForSeconds(startWait+5);
        // healthPackClones[0].SetActive(false);

        /*while (!stop)
        {
           // randEnemy = Random.Range(0, 2);
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), -1, Random.Range(-spawnValues.z, spawnValues.z));
            Instantiate(enemy, spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

            yield return new WaitForSeconds(spawnWait);
            Destroy(enemy,5.0f);
        }*/

    }

    IEnumerator DesaparecerObjs()
    {
        yield return new WaitForSeconds(spawnWait);
        healthPackClones[randmEnemy].SetActive(false);
    }
    
}
