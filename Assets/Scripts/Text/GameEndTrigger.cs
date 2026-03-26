using UnityEngine;

public class GameEndTrigger : MonoBehaviour
{
    public GameObject blackScreen;
    public GameObject endText;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EndGame();
        }
    }

    void EndGame()
    {
        blackScreen.SetActive(true);
        endText.SetActive(true);

        Time.timeScale = 0f;

        Debug.Log("Player Escaped!");
    }
}