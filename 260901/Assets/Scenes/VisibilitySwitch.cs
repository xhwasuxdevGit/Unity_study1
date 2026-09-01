using UnityEngine;

public class VisibilitySwitch : MonoBehaviour
{
    private const string TAG_FAR = "FarTarget";

    [SerializeField] private Renderer _childRenderer;

    //[SerializeField] private bool _showSelf = true;
    [SerializeField] private bool _showChild = true;
    [SerializeField] private bool _showFar = true;

    [field: SerializeField] public bool ShowSelf { get; private set; }

    private Renderer _selfRenderer;
    private Renderer _farRenderer;

    private void Awake()
    {
        _selfRenderer = GetComponent<Renderer>();

        GameObject farObject = GameObject.FindWithTag(TAG_FAR);
        _farRenderer = farObject.GetComponent<Renderer>();
        
        Debug.Log($"VisivilitySwitch: 자신은 {_selfRenderer.name}입니다.");
        Debug.Log($"VisivilitySwitch: 연결된 자식은 {_childRenderer.name}입니다.");
        Debug.Log($"VisivilitySwitch: 태그로 찾은 것은 {_farRenderer.name}입니다.");
        
    }

    private void Start()
    {
        _selfRenderer.enabled = ShowSelf;
        _childRenderer.enabled = _showChild;
        _farRenderer.enabled = _showFar;
    }
    
    
}
