using UnityEngine;

public class GameManager : MonoBehaviour {
    private bool ended = false;

    // Update is called once per frame
    void Update () {
        //parbauda vai lietotajs nav zaudejis
        if (ended == true) return;
        if (Resources.lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        ended = true;
        Time.timeScale = 0f;
    }
}
