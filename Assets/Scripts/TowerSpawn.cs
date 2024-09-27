using UnityEngine;

public class TowerSpawn : MonoBehaviour
{
    [SerializeField] GameObject pfTowerLv1;
    [SerializeField] GameObject pfTowerLv2;
    [SerializeField] GameObject pfTowerLv3;
    [SerializeField] GameObject pfTowerLv4;

    Renderer rend;

    GameObject GameObjectT1;
    GameObject GameObjectT2;
    GameObject GameObjectT3;
    GameObject GameObjectT4;

    bool checkT1 = false;
    bool checkT2 = false;
    bool checkT3 = false;
    bool checkT4 = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    void OnTriggerStay()
    {
        if (Input.GetKeyDown(KeyCode.E))
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
