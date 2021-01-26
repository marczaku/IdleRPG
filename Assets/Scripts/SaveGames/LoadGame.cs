using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour {
    const string defaultScene = "Blue";
    public void Load() {
        SwitchScene(PlayerPrefs.GetString("SavedScene", defaultScene));
    }

    public void SwitchScene(string scene) {
        SceneManager.LoadScene(scene);
    }
}
