using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{

    private Button ButtonA ;
    private Text TextA ;
    private Image ImageA ;
    private GameObject m_RootUI;


    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        ShowInfo();
    }

    public  void Initialize()
    {
        m_RootUI = UITool.FindUIGameObject("PanelA");

        // 顯示的訊息
        // 兵營名稱
        TextA = UITool.GetUIComponent<Text>(m_RootUI, "TextA");
        ImageA = UITool.GetUIComponent<Image>(m_RootUI, "ImageA");
        ButtonA = UITool.GetUIComponent<Button>(m_RootUI, "Button");
    }

    public void ShowInfo()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            TextA.text = "A";

        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            TextA.text = "B";

        }
    }
}
