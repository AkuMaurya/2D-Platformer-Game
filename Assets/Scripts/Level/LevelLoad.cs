using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelLoad : MonoBehaviour
{
    private Button button;
    public string LevelName;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick(){
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
        switch(levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("Can't playthis level till U unlock it");
                break;

            case LevelStatus.Unlocked:
                SceneManager.LoadScene(LevelName);
                break;

            case LevelStatus.Completed:
                SceneManager.LoadScene(LevelName);
                break;


        }
        // SceneManager.LoadScene(LevelName);
    }
}
