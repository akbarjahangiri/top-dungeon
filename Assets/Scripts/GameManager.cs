using System;
using System.Collections;
using System.Collections.Generic;
using BirdTools;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        SceneManager.sceneLoaded += LoadState;
        instance = this;
    }

    // Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    // References
    public Player player;

    public FloatingTextManager floatingTextManager;
    // public Weapon weapon

    // Logic
    public IntVariable experience;
    public IntVariable gold;
    public IntVariable playerLevel;
    public IntVariable weaponLevel;

    /*
     * Save State
     *  Int preferSkin
     *  Int gold
     *  Int Experience
     *  Int weaponLevel
     */
    public void SaveState()
    {
        string data = "";
        // Player level
        data += "0" + "|";
        // Player gold
        data += gold.Value.ToString() + "|";
        // Player experience
        data += experience.Value.ToString() + "|";
        // Weapon level
        data += "0";

        PlayerPrefs.SetString("SaveGame", data);
    }

    public void LoadState(Scene scene, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveGame"))
            return;
        string savedData = PlayerPrefs.GetString("SaveGame");
        string[] data = savedData.Split('|');
        gold.Value = Int32.Parse(data[1]);
        experience.Value = Int32.Parse(data[2]);

        Debug.Log("scene loaded: " + SceneManager.GetActiveScene().name);
    }

    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }
}