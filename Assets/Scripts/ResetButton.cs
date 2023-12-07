using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
    public void Reset()
    {
        File.Delete(Application.persistentDataPath + "/data.save");
        SceneManager.LoadScene(0);
    }
}
