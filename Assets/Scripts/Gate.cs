using System;
using System.Collections.Generic;
using BirdTools;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class Gate : Collidable
{
    public List<StringVariable> sceneList = new List<StringVariable>();
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            LoadDungeon();
        }
    }

    private void LoadDungeon()
    {
        String randomScene = sceneList[Random.Range(0, sceneList.Count)].Value;
        SceneManager.LoadScene(randomScene);
    }
}