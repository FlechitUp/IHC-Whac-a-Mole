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
    public float moveY;
    public float posAlpha;
    public int startWait;
    public int randmEnemy;
    public bool stop;

    int randEnemy;


	// Use this for initialization
	void Start () {      
        moveY = 0;
        posAlpha = 3.0f;
        StartCoroutine(waitSpawner());
        //StartCoroutine(DesaparecerObjs());

    }
	
	// Update is called once per frame
	void Update () {
        //spawnWait = Random.Range(spawnLeastWait, spawnMostWait);       
        spawnWait = Random.Range(2, 5); //tiempo aleatorio
        randmEnemy = Random.Range(0, 4);  // enemigo aleatorio para desaparecer

        moveMole();

    }

    void moveMole()
    {        
        Debug.Log("randmEnemy " + randmEnemy);
        //DesaparecerObjs();
       // Debug.Log("moveY "+ moveY);
        if (posAlpha >=3)//healthPackClones[randEnemy].transform.position.y < 2.0f)
        {
            Debug.Log("bajar "+ moveY);
            bajar(randEnemy);
            //Debug.Log("Pos" + healthPackClones[randEnemy].transform.position.y);
        }
        else {
            if (posAlpha <= -3) 
            {
                Debug.Log("subir " + moveY);
                subir(randEnemy);
            }
        }
        posAlpha += moveY;

    }

    void subir(int posEnemy)
    {        
        moveY = 0.5f;
        healthPackClones[posEnemy].transform.Translate(0,moveY, 0);///(Vector3.forward * Time.deltaTime);   
        Debug.Log("Pos" + healthPackClones[posEnemy].transform.position.y);
        //yield return new WaitForSeconds(10);        
    }

    void bajar(int posEnemy)
    {
        moveY = -0.5f;
        healthPackClones[posEnemy].transform.Translate(0,moveY, 0);
        Debug.Log("Pos" + healthPackClones[posEnemy].transform.position.y);
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
