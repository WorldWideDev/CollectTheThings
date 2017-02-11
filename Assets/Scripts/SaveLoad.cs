using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using MySerializables;

[Serializable]
class PlayerData
{
    public int score;
    public int level;
    public SerializableVector3 position;
    public List<SerializableVector3> rCollectables;

    public PlayerData()
    {
        rCollectables = new List<SerializableVector3>();
    }
}

public class SaveLoad : MonoBehaviour {
    
    public static GameObject Collectable;
    public static Transform player;
    public static SerializableVector3 playerPos;
    public static GameObject[] collectables;


    public static void Init()
    {
        Collectable = GameObject.FindGameObjectWithTag("Collectable");
        player = GameObject.FindGameObjectWithTag("Player").transform;
        collectables = GameObject.FindGameObjectsWithTag("Collectable");

    }

    public static void Save()
    {
        Debug.Log("Saving...");
        Init();
        
        Debug.Log(collectables.Length);
        playerPos = new SerializableVector3(player.position.x, player.position.y, player.position.z);

        FileStream file;
        string path = Application.persistentDataPath + "/playerInfo.gd";
        BinaryFormatter bf = new BinaryFormatter();


        if (File.Exists(path))
        {
            file = File.Open(path, FileMode.Open);
        }
        else
        {
            Debug.Log("no path here");
            file = File.Create(path);
        }


        PlayerData data = new PlayerData();
        data.score = gameManager.Instance.score;
        data.level = gameManager.Instance.level;
        data.position = playerPos;
        foreach (GameObject c in collectables)
        {
            SerializableVector3 cPos = new SerializableVector3(c.transform.position.x, c.transform.position.y, c.transform.position.z);
            data.rCollectables.Add(cPos);
        }

        bf.Serialize(file, data);
        file.Close();
    }

    public static void Load()
    {
        Debug.Log("Loading...");
        Init();
        string path = Application.persistentDataPath + "/playerInfo.gd";
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            PlayerData data = bf.Deserialize(file) as PlayerData;
            file.Close();

            gameManager.Instance.score = data.score;
            gameManager.Instance.level = data.level;
            player.position = new Vector3(data.position.x, data.position.y, data.position.z);
            foreach (GameObject c in collectables)
            {
                Destroy(c);
            }
            foreach (SerializableVector3 d in data.rCollectables)
            {
                Debug.Log(new Vector3(d.x, d.y, d.z));
                Instantiate<GameObject>(Collectable, new Vector3(d.x, d.y, d.z), Quaternion.identity);
            }
        }
    }

}
