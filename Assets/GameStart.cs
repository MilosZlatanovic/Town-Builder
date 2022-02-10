using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    // Button OnClick() Load GamePlay Scene
    public void PlayGame() => SceneManager.LoadScene(1, LoadSceneMode.Single);
}
