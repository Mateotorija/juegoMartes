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

    private StackTF<Wave> waveStack = new StackTF<Wave>();

    private void Start()
    {
        FillWaveStack();
    }

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
    private void FillWaveStack()
    {
        foreach (Wave wave in waves)
        {
            waveStack.Stack(wave);
        }
    }

    IEnumerator SpawnWave()
    {
        if (waveStack.EmptyStack())
        {
            Debug.Log("LEVEL COMPLETE!");
            this.enabled = false;
            yield break;
        }

        Wave wave = waveStack.Top();
        waveStack.Unstack();

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
    }

    // Spawnea los prefabs del target en el punto inicial
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}