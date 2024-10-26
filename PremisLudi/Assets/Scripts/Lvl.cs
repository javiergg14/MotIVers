using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public string sceneToLoad; // Nombre de la escena a cargar

    void Start()
    {
        Button btn = GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(ChangeScene);
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}