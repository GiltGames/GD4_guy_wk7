using UnityEngine;
using System.IO;
using UnityEngine.TestTools;

public class MainManager : MonoBehaviour
{

    public static MainManager Instance;
   public Color TeamCol;
    [SerializeField] string fileName = "/savefile.json";


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);

        }

        Instance = this;

        DontDestroyOnLoad(gameObject);

        LoadColor();


    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    [System.Serializable]
   public class SaveData
    {

        public Color TeamColour;

    }

    public void SaveColor()
    {

        SaveData data = new SaveData();
        data.TeamColour = TeamCol;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath +fileName,json);



    }

    public void LoadColor()
    {

        string path = Application.persistentDataPath +fileName;
        if(File.Exists(path))
        {


            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            TeamCol = data.TeamColour;


        }

    }

}
