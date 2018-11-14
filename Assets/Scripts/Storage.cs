using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Storage : MonoBehaviour
{

    public static Storage instance;

    public static string GetStoreFilePath()
    {
        return Application.persistentDataPath + "/store.dat";
    }

    public void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Storage.Load();
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        Load();
    }

    public static void Load()
    {
        if (File.Exists(GetStoreFilePath()))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(GetStoreFilePath(), FileMode.Open, FileAccess.Read);
            GameData data = (GameData)bf.Deserialize(fs);
            fs.Close();

            Debug.Log("load score: " + data.score);
            Scores.SetScore(Math.Max(Scores.GetScore(), data.score));
            instance.ResetLocation(data);
        }
    }

    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Open(GetStoreFilePath(), FileMode.OpenOrCreate);

        GameObject player = GameObject.Find("FirstPersonPlayer");
        GameObject playerCamera = GameObject.Find("FirstPersonCharacter");
        GameData data = new GameData
        {
            score = Scores.GetScore(),
            position = new Vector3Serializer(player.transform.position),
            rotation = new QuaternionSerializer(player.transform.localRotation),
            cameraRotation = new QuaternionSerializer(playerCamera.transform.localRotation)
        };

        Debug.Log("save score: " + Scores.GetScore());

        bf.Serialize(fs, data);
        fs.Close();
    }

    void ResetLocation(GameData data)
    {
        Debug.Log(" ResetLocation ");
        GameObject player = GameObject.Find("FirstPersonPlayer");
        if (player != null)
        {
            GameObject playerCamera = GameObject.Find("FirstPersonCharacter");
            player.transform.position = data.position.V3;
            player.transform.localRotation = data.rotation.Q;
            playerCamera.transform.localRotation = data.cameraRotation.Q;

            player.GetComponent<FirstPersonController>().ResetSetView();
        }
    }
}

[Serializable]
class GameData
{
    public int score;
    public Vector3Serializer position;
    public QuaternionSerializer rotation;
    public QuaternionSerializer cameraRotation;
};

[Serializable]
public struct Vector3Serializer
{
    public float x;
    public float y;
    public float z;

    public Vector3Serializer(Vector3 v3)
    {
        x = v3.x;
        y = v3.y;
        z = v3.z;
    }

    public Vector3 V3
    { get { return new Vector3(x, y, z); } }
}

[Serializable]
public struct QuaternionSerializer
{
    public float x;
    public float y;
    public float z;
    public float w;

    public QuaternionSerializer(Quaternion q)
    {
        x = q.x;
        y = q.y;
        z = q.z;
        w = q.w;
    }

    public Quaternion Q
    { get { return new Quaternion(x, y, z, w); } }
}
