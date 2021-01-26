using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 fallbackPosition;
    public SomeClass some;

    public void Update() {
        if (Input.GetKeyDown(KeyCode.W)) {
            this.transform.Translate(Vector3.forward);
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            this.transform.Translate(Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            this.transform.Translate(Vector3.back);
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            this.transform.Translate(Vector3.right);
        }
    }

    [Serializable]
    public class SomeClass {
        public AnotherClass another;
        public DifferentClass different;
        public bool serializedBool = true;
        public int[] numbers;
    }
    
    [Serializable]
    public class AnotherClass {
        public int x = 5;
        int y = 3;
    }
    
    public class DifferentClass {
        public int z = 1;
    }

    public int[] numbers;

    public void SaveGame() {
        var instance = new SomeClass();
        instance.numbers = this.numbers;
        var serializedInstance = JsonUtility.ToJson(instance);
        var loadedInstance = JsonUtility.FromJson<SomeClass>(serializedInstance);
        Debug.Log(serializedInstance);
        Debug.Log($"Positon ToString(): {this.transform.position.ToString()}");
        Debug.Log($"Positon ToJson(): {JsonUtility.ToJson(this.transform.position)}");

        Debug.Log(JsonUtility.ToJson(true));
        PlayerPrefs.SetString("SomeBool", JsonUtility.ToJson(true));
        var value = JsonUtility.FromJson<bool>(PlayerPrefs.GetString("SomeBool"));
        Debug.Log(value);
        
        // Save a whole class to a file:
        File.WriteAllText(Path.Combine(Application.persistentDataPath, "SaveGame.txt"), JsonUtility.ToJson(new SomeClass()));
    }

    public void LoadGame() {
        // Save position
        PlayerPrefs.SetString("Position", JsonUtility.ToJson(this.transform.position));
        // Load positions
        this.transform.position = JsonUtility.FromJson<Vector3>(PlayerPrefs.GetString("Position", ""));
        
        FailSaveLogic();
    }

    void FailSaveLogic() {
        if (this.transform.position.y < 0f) {
            this.transform.position = fallbackPosition;
        }
    }
}
