using UnityEngine;

public class WindManager : MonoBehaviour
{

    [SerializeField] private GameObject windZone;

    private void Awake()
    {
        windZone.SetActive(true);
    }
}
