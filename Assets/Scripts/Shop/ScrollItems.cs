using UnityEngine;
using UnityEngine.UI;

public class ScrollItems : MonoBehaviour
{
    //thie script main task is to CENTER the chosen item in shop; 
    [SerializeField] private HorizontalLayoutGroup _horizontalLayoutGroup;
    [SerializeField] private RectTransform _contentRectTransform;
    [SerializeField] private RectTransform _contentItemSample;

    private ScrollRect _scrollRect;
    private int _currItemIndex;
    private float _snapSpeed, _destPosX;
    
    private void Start()
    {
        _scrollRect = GetComponent<ScrollRect>();
        _snapSpeed = 200 * Time.deltaTime;
    }

    private void Update()
    {
        _currItemIndex = Mathf.RoundToInt(0 - _contentRectTransform.localPosition.x / (_contentItemSample.rect.width + _horizontalLayoutGroup.spacing));

        if(Input.touchCount == 0 && _scrollRect.velocity.magnitude < 200)
        {
            _scrollRect.velocity = Vector3.zero;
            _destPosX = 0 - (_currItemIndex * (_contentItemSample.rect.width + _horizontalLayoutGroup.spacing));
        }
        if (Input.touchCount == 0 && _contentRectTransform.localPosition.x != _destPosX && _scrollRect.velocity.magnitude == 0)
        {
            _contentRectTransform.localPosition = new Vector3(Mathf.MoveTowards
               (_contentRectTransform.localPosition.x, _destPosX, _snapSpeed),
               _contentRectTransform.localPosition.y,
               _contentRectTransform.localPosition.z);
        }
    }
}
