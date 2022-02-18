using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static float numberCouloir;
    protected static float timeSpawn = 6;
    public static List<Couloir> couloirs = new List<Couloir>();
    private int lastSpawner;
    public static bool endGame = false;

    protected void CreateMap()
    {
        float indexCouloir = 20 / numberCouloir;
        float startPos = -10;
        for (int i = 0; i < numberCouloir; i++)
        {
            couloirs.Add(new Couloir() { posStart = startPos, posEnd = startPos + indexCouloir, num = i });
            startPos += indexCouloir;
        }
    }

    public void SpawnHoop(Rigidbody2D rb)
    {
        Debug.Log(endGame);
        if (!endGame)
        {
            int spawner = Random.Range(0, (int)numberCouloir);
            while (spawner == lastSpawner)
            {
                spawner = Random.Range(0, (int)numberCouloir);
            }
            lastSpawner = spawner;
            Couloir newCouloir = MapManager.couloirs.Find(x => x.num == spawner);
            rb.transform.position = new Vector3((newCouloir.posStart + newCouloir.posEnd) / 2,
                rb.transform.position.y, rb.transform.position.z);
        }
        
    }

    public void ChoiceDifficulty(float difficulty)
    {
        numberCouloir = difficulty;
        if (difficulty == 7)
        {
            numberCouloir = 5;
        }
        timeSpawn /= difficulty;
        
        SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        endGame = false;
        numberCouloir = 0;
        timeSpawn = 6;
        couloirs.Clear();
        SceneManager.LoadScene(1);
    }
}
