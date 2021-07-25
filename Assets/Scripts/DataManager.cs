using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class DataManager : MonoBehaviour
{
    //Хранитель перемен

    public static DataManager Instance;
    public ulong Clicks;
    public ulong[] ResourceArray;
    private string DataPath;
    private void DataSave()
    {
        Data data = new Data(Clicks);
        File.WriteAllText(DataPath, JsonUtility.ToJson(data));
    }

    private void DataLoad()
    {
        Data data = JsonUtility.FromJson<Data>(File.ReadAllText(DataPath));
        Clicks = data.clicks;
    }

    private void OnApplicationFocus(bool focus)
    {
        DataSave();     
    }

    private void OnApplicationQuit()
    {
        DataSave();  
    }

    private void Awake()
    {
        Instance = this;
        DataPath = Application.persistentDataPath + "/Data.json";
        ResourceArray = new ulong[10];
        DataLoad();
    }
    [System.Serializable]
    public class Data 
    {
        public ulong clicks;
        
        public Data(ulong Clicks)
        {
            clicks = Clicks;
        }
    }
}
