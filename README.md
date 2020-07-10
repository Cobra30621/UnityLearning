# UnityLearning

## 0623 UIManager
- 文章：[製作 UGUI 的 UI 流程管理機制](https://godstamps.blogspot.com/2015/06/unity-ugui-ui.html)
- 資料夾：UIProceedManager
- 功用：可以製作UI的流程管理

## 0625 UILearning
- UItool
  - 功能詳情[設計模式與遊戲開發的完美結合](https://hackmd.io/@uspdtu0FT9eHVAsX5kZKeg/B1mRVedfL/%2FexljTljoS4-dHdQ7k-dFkw)
 
## 0710 FruitCard
- 翻牌遊戲
- [Unity 小遊戲 2D 教學 記憶翻牌 水果配對](https://www.youtube.com/watch?v=8w_T0LXeg2Q)

### 有意思：Enum轉List
    void SetUpCardsToBEPutIn() // Enum轉List
    {
        Array array = Enum.GetValues(typeof(CardPatten)); 
        for (int i = 0; i < 2; i++)
        {
            foreach (var item in array)
            {
                cardsToBePutIn.Add((CardPatten)item);
            }
        }
        cardsToBePutIn.RemoveAt(9); // 把None刪掉
        cardsToBePutIn.RemoveAt(0); // 把None刪掉

    }
