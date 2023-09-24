using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    // interger que tiene en cuenta la cantidad de enemigos vivos
    public static int EnemiesAlive = 0;

    //array para guardar la cantidad de waves y dentro de ella es puede asignar el tipo de enmigo cantidad y su velocidad y vida
    public Wave[] waves;

    // inicio de spawn
    public Transform spawnPoint;

    [SerializeField] public float timeBetweenWaves = 5f;
    [SerializeField] private float countdown = 2f;

    private int waveIndex = 0;

    private void Update()
    {

        // el codigo no sigue si hay enemigos vivos
        if (EnemiesAlive > 0)
        {
            return;
        }

        // cuando pasa cierta cantidad de tiempo se activa el spawn de los enemigos
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        // se cuenta para tras
        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        // el numero de wave aplicado
        Wave wave = waves[waveIndex];

        for (int i = 0; i < wave.count; i++)
        {
            // spawea los enemigos de a uno y no todos juntos
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveIndex++;

        if (waveIndex == waves.Length)
        {
            // si se llega a la cantidad de waves del total de waves asignados se gana pero como es un shooting gallery es una sola wave larga
            Debug.Log("LEVEL WON!");
            this.enabled = false;
        }
    }


    // Spawnea los prefabs del target en el punto inicial
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }

}
