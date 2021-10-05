using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    [SerializeField] float delay = 3f;
    Collider2D myCollider;
    Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        WinLevel();
    }

    private void WinLevel()
    {
        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            myAnimator.SetBool("Opening", true);
            StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(delay);
        Destroy(FindObjectOfType<ScenePersist>().gameObject);
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    


}
