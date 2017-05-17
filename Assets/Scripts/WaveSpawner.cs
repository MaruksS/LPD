using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    //tiek izvelets creeps un sakuma pozicija
    public Transform creepPrefab;
    public Transform spawnPoint;


    //laiks starp vilniem un vilnja ID
    public float timer = 5f;
    private float cd = 2f;

    public Text CD_text;
    private float waittime = 0.5f;
    private int waveID = 1;


    private void Update()
    {
        /*kad beidzas uzgaides laiks
        tiek izsaukta korutina, kas izsauc jaunu vilni */
        if (cd <= 0f)
        {
            StartCoroutine(SpawnWave());
            cd = timer;
        }
        cd -= Time.deltaTime;

        //CD_text.text = Mathf.Round(cd).ToString();
    }
    //korutina, kas izsauc creepu un tad nopauze darbibu uz konkretu laiku, lai izsauktu nakosho creepu
    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waveID; i++)
        {
            SpawnCreep();
            yield return new WaitForSeconds(waittime);
        }
        seed.waves++;
        waveID++;
        Debug.Log(waveID.ToString());
    }
    //tiek izsaukts 1 creep
    void SpawnCreep()
    {
        Instantiate(creepPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}
