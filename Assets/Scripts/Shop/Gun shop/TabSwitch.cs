using UnityEngine;
using UnityEngine.UI;

public class TabSwitch : MonoBehaviour
{
    // switch tabs in weapon shop (gun-player-...)
    [SerializeField] GameObject[] _tabs;
    [SerializeField] RectTransform[] _tabButtRecTranforms;
    [SerializeField] Button[] _tabButtons;

    private Vector2 _activeButtSize = new Vector2(165, 85), _inActiveButtSize = new Vector2(145, 75);
    private int _currentTabIndex = 0;
    public void SwitchTab(int index)
    {
        _tabs[_currentTabIndex].SetActive(false);
        _tabButtRecTranforms[_currentTabIndex].sizeDelta = _inActiveButtSize;

        _tabs[index].SetActive(true);
        _tabButtRecTranforms[index].sizeDelta = _activeButtSize;

        _currentTabIndex = index;
    }
}
