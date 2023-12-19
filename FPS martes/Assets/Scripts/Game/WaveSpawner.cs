using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    // interger que tiene en cuenta la cantidad de enemigos vivos
    [SerializeField] public static int EnemiesAlive = 0;

    //array para guardar la cantidad de waves y dentro de ella es puede asignar el tipo de enmigo cantidad y su velocidad y vida
    public Wave[] waves;

    // inicio de spawn
    public Transform spawnPoint;

    [SerializeField] public float timeBetweenWaves = 5f;
    [SerializeField] public float countdown = 2f;

    private StackTF<Wave> waveStack = new StackTF<Wave>(); //creamos el stack
    //private ABBHighScore _abbHighscore;
    //public PruebaGrafo pruebaGrafo;

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
            StartCoroutine(SpawnWaveOnPath());
            //StartCoroutine(SpawnWaveOnPath(pruebaGrafo.ruta));
            countdown = timeBetweenWaves;
            return;
        }
        // se cuenta para tras
        countdown -= Time.deltaTime;
    }
    public void FillWaveStack() //Llenamos el stack de enemigos
    {
        foreach (Wave wave in waves)
        {
            waveStack.Stack(wave);
        }
    }

    public IEnumerator SpawnWaveOnPath(/*List<int> path*/)
    {
        if (waveStack.EmptyStack())
        {
            Debug.Log("LEVEL COMPLETE!");
            this.enabled = false;
            //_abbHighscore.MostrarPuntajes();
            yield break;
        }

        Wave wave = waveStack.Top();
        waveStack.Unstack();

        //foreach (int nodeIndex in path)
        //{
        //    GameObject randomEnemy = wave.enemies[Random.Range(0, wave.enemies.Count)];
        //    SpawnEnemy(randomEnemy, nodeIndex);
        //    yield return new WaitForSeconds(1f / wave.rate);
        //}
        for (int i = 0; i < wave.count; i++)
        {
            GameObject randomEnemy = wave.enemies[Random.Range(0, wave.enemies.Count)];
            SpawnEnemy(randomEnemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
    }

    void SpawnEnemy(GameObject enemy/*, int nodeIndex*/)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        //Vector3 spawnPosition = new Vector3(pruebaGrafo.nodosCoords[nodeIndex].x, 0.5f, pruebaGrafo.nodosCoords[nodeIndex].z);
        //Instantiate(enemy, spawnPosition, spawnPoint.rotation);
        EnemiesAlive++;
    }
}