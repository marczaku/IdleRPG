using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGame : MonoBehaviour
{
    public void Save() {
        PlayerPrefs.SetString("SavedScene", SceneManager.GetActiveScene().name);
    }
}

public class SaveGameManager : ScriptableObject {
    public event System.Action SaveGameRequested;
    public event System.Action<int> SaveGameInSlotRequested;
    public event System.Action LoadGameRequested;
    public event System.Action<int> LoadGameFromSlotRequested;
    public event System.Action<WholeGameSaveGame> WholeSaveGameRequested;

    public void SaveGame_WholeGameEdition() {
        var saveGame = new WholeGameSaveGame();
        this.WholeSaveGameRequested?.Invoke(saveGame);
        PlayerPrefs.SetString("saveGame", JsonUtility.ToJson(saveGame));
    }

}

public class PlayerSaveGame {
    
}

public class EnemiesSaveGame {
    
}

public class EnvironmentSaveGame {
    
}

public class InventorySaveGame {
    
}

public class WholeGameSaveGame {
    public PlayerSaveGame player;
    public EnemiesSaveGame enemies;
    public EnvironmentSaveGame environment;
    public InventorySaveGame inventory;
}

public class Player : MonoBehaviour {
    public SaveGameManager manager;

    void Start() {
        this.manager.SaveGameRequested += ManagerOnSaveGame;
        this.manager.SaveGameInSlotRequested += ManagerOnSaveGameInSlot;
        this.manager.WholeSaveGameRequested += ManagerOnWholeSaveGameRequested;
    }

    void ManagerOnWholeSaveGameRequested(WholeGameSaveGame saveGame) {
        saveGame.player = new PlayerSaveGame();
        // EditorPrefKey
        // PlayerPrefKey-NamingConvention:
        // Team5.IdleRPG.SaveGame.Player
        // Team5.IdleRPG.SaveGame.Enemies
    }

    void ManagerOnSaveGameInSlot(int slot) {
        PlayerPrefs.SetString($"PlayerPosition{slot}", "");
    }

    void ManagerOnSaveGame() {
        PlayerPrefs.SetString("PlayerPosition", "");
    }
}
