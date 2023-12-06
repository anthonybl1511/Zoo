using UnityEngine;
using UnityEngine.UI;

public class Hotbar : MonoBehaviour
{
    [SerializeField] private Image[] toolIcons;
    private int currentToolIndex = 0;
    public static string currentTool;

    private void Start()
    {
        currentToolIndex = 0;
        currentTool = toolIcons[currentToolIndex].name;
        
        UpdateUI();
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            ChangeTool(scroll > 0 ? 1 : -1);
        }
    }

    void ChangeTool(int direction)
    {
        currentToolIndex += direction;
        if (currentToolIndex < 0)
        {
            currentToolIndex = toolIcons.Length - 1;
        }
        else if (currentToolIndex >= toolIcons.Length)
        {
            currentToolIndex = 0;
        }

        currentTool = toolIcons[currentToolIndex].name;
        UpdateUI();
    }

    void UpdateUI()
    {
        for (int i = 0; i < toolIcons.Length; i++)
        {
            toolIcons[i].color = i == currentToolIndex ? Color.yellow : Color.white;
        }
    }
}
