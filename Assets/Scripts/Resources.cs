using UnityEngine.UI;
using UnityEngine;

public class Resources : MonoBehaviour {

    //lietotaja resursi
    public Text woodText;
    public Text seedText;
    public Text livesText;

    public static int wood;
    public static int seeds;
    public static int lives;
    public static int kills;

    public int startwood ;
    public int startseeds ;
    public int startlives ;

    void Start()
    {
        wood = startwood;
        seeds = startseeds;
        lives = startlives;
        kills = 0;
    }

    void Update()
    {
        woodText.text = wood.ToString();
        seedText.text = seeds.ToString();
        livesText.text = lives.ToString();
    }
}
