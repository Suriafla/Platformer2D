using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour, IPointerDownHandler
{

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Restart();
    }
}
