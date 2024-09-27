using UnityEngine;

public class TowerSpawn : MonoBehaviour
{
    [SerializeField] GameObject pfTowerLv1;
    [SerializeField] GameObject pfTowerLv2;
    [SerializeField] GameObject pfTowerLv3;
    [SerializeField] GameObject pfTowerLv4;

    private Renderer rend;

    private GameObject GameObjectT1;
    private GameObject GameObjectT2;
    private GameObject GameObjectT3;
    private GameObject GameObjectT4;

    private bool checkT1 = false;
    private bool checkT2 = false;
    private bool checkT3 = false;
    private bool checkT4 = false;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void OnTriggerStay()
    {
        if (Input.GetKeyDown("e"))
        {
            if (!checkT1)
            {
                GameObjectT1 = Instantiate(pfTowerLv1, transform.position, Quaternion.identity);
                rend.enabled = false;
                checkT1 = true;
            }

            else if (checkT1 && !checkT2)
            {
                Destroy(GameObjectT1);
                GameObjectT2 = Instantiate(pfTowerLv2, transform.position, Quaternion.identity);
                checkT2 = true;
            }

            else if (checkT2 && !checkT3)
            {
                Destroy(GameObjectT2);
                GameObjectT3 = Instantiate(pfTowerLv3, transform.position, Quaternion.identity);
                checkT3 = true;
            }

            else if (checkT3 && !checkT4)
            {
                Destroy(GameObjectT3);
                GameObjectT4 = Instantiate(pfTowerLv4, transform.position, Quaternion.identity);
                checkT4 = true;
            }
        }
    }
}
