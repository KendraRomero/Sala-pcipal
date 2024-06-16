using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneloader : MonoBehaviour
{
    [SerializeField]
    private string SceneName = "SalaPcipal";

    private AsyncOperation LoadLevelOperation = null;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() !=null  && LoadLevelOperation == null)
        {
            LoadLevelOperation = SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);
        }
    }
}
 