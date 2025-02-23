using UnityEngine;
using UnityEngine.UI;

public class ScrollItems : MonoBehaviour
{
    //thie script main task is to CENTER the chosen item in shop; 
    //and also control scroll arrow work;
    [SerializeField] private HorizontalLayoutGroup _horizontalLayoutGroup;
    [SerializeField] private RectTransform _contentRectTransform;
    [SerializeField] private RectTransform _contentItemSample;

    private ScrollRect _scrollRect;
    private int _currItemIndex;
    private float _snapSpeed = 13f, _destPosX;
    private bool _arrowSwithcPressed = false;

    private void Start()
    {
        _scrollRect = GetComponent<ScrollRect>();
    }

    private void Update()
    {
        _currItemIndex = Mathf.RoundToInt(0 - _contentRectTransform.localPosition.x / (_contentItemSample.rect.width + _horizontalLayoutGroup.spacing));

        if (Input.touchCount == 0)
        {
            if(_arrowSwithcPressed) // arrow work
            {
                _arrowSwithcPressed = !CenterItem();
            }
            else // control if selected item in shop is centered
            {
                if (_scrollRect.velocity.magnitude < 200 && _scrollRect.velocity.magnitude > 0)
                {
                    _scrollRect.velocity = Vector3.zero;
                    _destPosX = 0 - (_currItemIndex * (_contentItemSample.rect.width + _horizontalLayoutGroup.spacing));
                }
                if (_contentRectTransform.localPosition.x != _destPosX && _scrollRect.velocity.magnitude == 0)
                {
                    CenterItem();
                }
            }
            
        }
        else // if user scroll items himself, nothing other should work (that works only on smartphone, dosen't work in editor)
        {
            _arrowSwithcPressed = false;
        }
    }

    private bool CenterItem()
    {
        if(_contentRectTransform.localPosition.x == _destPosX) return true;

        _contentRectTransform.localPosition = new Vector3(Mathf.MoveTowards
                    (_contentRectTransform.localPosition.x, _destPosX, _snapSpeed),
                    _contentRectTransform.localPosition.y,
                    _contentRectTransform.localPosition.z);
        return false;
    }

    public void SwithToNextItem()
    {
        if (_currItemIndex < 2) // leter 2 must replace with weapon.Count or sth like that 
        {
            _destPosX = 0 - ((_currItemIndex + 1) * (_contentItemSample.rect.width + _horizontalLayoutGroup.spacing));
            _arrowSwithcPressed = true;
        }
    }

    public void SwithToPrevItem()
    {
        if (_currItemIndex > 0)
        {
            _destPosX = 0 - ((_currItemIndex - 1) * (_contentItemSample.rect.width + _horizontalLayoutGroup.spacing));
            _arrowSwithcPressed = true;
        }
    }
}
