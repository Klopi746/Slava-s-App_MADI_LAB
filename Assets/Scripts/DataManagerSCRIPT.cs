using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataManagerSCRIPT : MonoBehaviour
{
    public static DataManagerSCRIPT Instance;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public TMP_InputField[] inputFields;

    void Start ()
    {
        foreach(TMP_InputField field in inputFields)
        {
            var se = new TMP_InputField.SubmitEvent();
            se.AddListener(delegate {
                SubmitText(field.name, field.text);
            });
            field.onEndEdit = se;
        }
    }

    public void SubmitText(string prefKey, string prefVal)
    {
        Debug.Log("Saved " + prefVal + " to " + prefKey);
        PlayerPrefs.SetString(prefKey, prefVal);
        PlayerPrefs.Save();
    }
}