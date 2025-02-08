using UnityEngine;

public class DataManagerSCRIPT : MonoBehaviour
{
    public static DataManagerSCRIPT Instance;
    private void Awake()
    {
        Instance = this;
    }
}