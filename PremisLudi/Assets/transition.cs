using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transition : MonoBehaviour
{

    private Animator _transicionAnim;
    // Start is called before the first frame update
    void Start()
    {
        _transicionAnim = GetComponent<Animator>();
    }
    public void LoadScene(string scene)
    {
        StartCoroutine(Transiciona(scene));
    }
    IEnumerator Transiciona(string scene)
    {
        _transicionAnim.SetTrigger("Salida");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);
    }
}
