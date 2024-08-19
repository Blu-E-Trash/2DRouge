using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class DataSaver : MonoBehaviour
{
    static GameObject _DataSaver;
    static GameObject Container
    {
        get
        {
            return _DataSaver;
        }
    }
    static DataSaver _instance;
    public static DataSaver Instance
    {
        get
        {
            if (!_instance)
            {
                _DataSaver = new GameObject();
                _DataSaver.name = "DataSaver";
                _instance = _DataSaver.AddComponent(typeof(DataSaver)) as DataSaver;
                DontDestroyOnLoad(_DataSaver);
            }
            return _instance;
        }
    }

    public string GameDataFileName = ".json";

    public GameData _gameData;
    public GameData gameData
    {
        get
        {
            if(_gameData == null)
            {
                LoadGameData();
                SaveGameData();
            }
            return _gameData;
        }
    }
    public void LoadGameData()
    {
        string filePath = Application.persistentDataPath + GameDataFileName;

        if(File.Exists(filePath))
        {
            Debug.Log("�ҷ����� ����");
            string FromJsonData = File.ReadAllText(filePath);
            _gameData = JsonUtility.FromJson<GameData>(FromJsonData);
        }
        else
        {
            Debug.Log("�� ���� ����");

            _gameData = new GameData();
        }
    }
    public void SaveGameData()
    {
        string ToJasonData = JsonUtility.ToJson(gameData);
        string filePath = Application.persistentDataPath + GameDataFileName;
        File.WriteAllText(filePath, ToJasonData);
        Debug.Log("�������� ���� �Ϸ�");
    }
    private void OnApplicationQuit()
    {
        SaveGameData() ;
    }

}
