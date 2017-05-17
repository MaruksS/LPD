using UnityEngine;

public class Buildings : MonoBehaviour {
    //2 buvju tipi,ko lietotajs var uzbuvet
    public Costs ballista;
    public Costs seed;
    //reference uz build manager
    BuildManager buildManager;
    bool pot;
    void Start()
        //tiek defeineta reference, lai pieklutu klases metodem
    {
        buildManager = BuildManager.instance;
    }

    //tiek izvelets tornis
    public void select_ballista()
    {
        pot = false;
        buildManager.select(ballista,pot);
    }

    //tiek izveleta sekla
    public void select_seed()
    {
        pot = true;
        buildManager.select(seed,pot);
    }
}
