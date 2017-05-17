using UnityEngine;

public class BuildManager : MonoBehaviour
{

    //satur noradi pats uz sevi, lai butu sasniedzams no jebkuras citas klases
    public static BuildManager instance;
    //tonja veids
    private Costs objectToCreate;
    //standarta tornis
    public GameObject BallistaTower;
    public GameObject pot;
    bool seed;
    void Awake()
    {
        //parbauda vai nav tuksha instance
        if (instance != null) return;
        instance = this;
    }

    //metode, kas parbauda, vai uz konkreta node ir iespejams uzbuvet kaut ko
    public bool CanBuild { get { return objectToCreate != null; } }


    public void Place(Node node)
    {
        //tiek parbaudits vai tas ir tornis vai sekla
        if (seed == true)
        {
            //vai uz ta buvniecibu pietiek materialu
            if (Resources.seeds < objectToCreate.cost)
            {
                return;
            }
            //ja pietiek atnem lietotajam resursus
            Resources.seeds -= objectToCreate.cost;
        }
        else
        {
            if (Resources.wood < objectToCreate.cost)
            {
                return;
            }
            Resources.wood -= objectToCreate.cost;
        }

        //izsauc konkretu objektu
        GameObject building = Instantiate(objectToCreate.obj, node.GetPos(), Quaternion.identity);
    }

    //funkcija, kas tiek izsaukta no buildings klases, lai uzbuvet kaut ko
    public void select (Costs tower, bool pot)
    {
        if (pot == true)
        {
            seed = true;
        }
        else
        {
            seed = false;
        }
        objectToCreate = tower;
    }
}

