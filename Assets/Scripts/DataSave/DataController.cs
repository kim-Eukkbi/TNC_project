using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataController : MonoBehaviour
{
    // 싱글톤 
    static GameObject _container;
    static GameObject Container
    {
        get
        {
            return _container;
        }
    }

    static DataController _instance;
    public static DataController Instance
    {
        get
        {
            if (!_instance)
            {
                _container = new GameObject();
                _container.name = "DataController";
                _instance = _container.AddComponent(typeof(DataController)) as DataController;
                DontDestroyOnLoad(_container);
            }
            return _instance;
        }
    }

    // 게임 데이터 파일이름 설정 
    public string GameDataFileName = "StarfishData.json"; // "원하는 이름(영문).json"

    public GameData _gameData;
    public GameData gameData
    {
        get
        {
            // 게임 시작시 자동 실행
            if (_gameData == null)
            {
                LoadGameData();
                SaveGameData();
            }
            return _gameData;
        }
    }

    private void Start()
    {
        LoadGameData();
        SaveGameData();
    }

    public void LoadGameData()
    {
        string filePath = Application.persistentDataPath + GameDataFileName;

        // 저장된 게임 , 불러오기 
        if(File.Exists(filePath))
        {
            string FromjsonData = File.ReadAllText(filePath);
            _gameData = JsonUtility.FromJson<GameData>(FromjsonData);
        }
        // 저장된 게임 없다면 
        else
        {
            _gameData = new GameData();
        }
    }

    public void SaveGameData()
    {
        string ToJsonData = JsonUtility.ToJson(gameData);
        string filePath = Application.persistentDataPath + GameDataFileName;
        // 덮어쓰기 
        File.WriteAllText(filePath, ToJsonData);

        // 올바르게 저장 확인 (변형
        print("저장완료");
        print("2는 " + gameData.isClear2);
        print("3는 " + gameData.isClear3);
        print("4는 " + gameData.isClear4);
        print("5는 " + gameData.isClear5);
       
    }
    // 종료시 자동저장 
    private void OnApplicationQuit()
    {
        SaveGameData();
    }
}
