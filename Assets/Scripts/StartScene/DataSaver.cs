using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class DataSaver : MonoBehaviour
{
    [SerializeField]
    private GameObject SystemMassage;
    [SerializeField]
    private Text SystemMassageText;

    static GameObject _DataSaver;
    private void Start()
    {
        SystemMassage.SetActive(false);
    }
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
            SystemMassage.SetActive(true);
            SystemMassageText.text = "�ҷ����� ����!";
            string FromJsonData = File.ReadAllText(filePath);
            _gameData = JsonUtility.FromJson<GameData>(FromJsonData);
            Invoke("Out", 2f);
        }
        else
        {
            Debug.Log("�� ���� ����");
            SystemMassage.SetActive(true);
            SystemMassageText.text = "����� �����Ͱ� �����ϴ�.";
            _gameData = new GameData();
            Invoke("Out", 2f);
        }
    }
    public void SaveGameData()
    {
        string ToJasonData = JsonUtility.ToJson(gameData);
        string filePath = Application.persistentDataPath + GameDataFileName;
        File.WriteAllText(filePath, ToJasonData);
        Debug.Log("�������� ���� �Ϸ�");
        SystemMassage.SetActive(true);
        SystemMassageText.text = "���� ����!";
        Invoke("Out", 2f);
    }
    private void OnApplicationQuit()
    {
        SaveGameData() ;
    }
    private void Out()
    {
        SystemMassage.SetActive(false);
    }
}
