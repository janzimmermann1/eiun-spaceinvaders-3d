using UnityEngine;

public class BoundaryUI : MonoBehaviour
{
    private BoundaryManager _boundaryManager;

    private bool _hasReachedBoundary = false;

    private void Start()
    {
        _boundaryManager = FindObjectOfType<BoundaryManager>();
        _boundaryManager.BoundaryReached += (sender, args) =>
        {
            _hasReachedBoundary = ((BoundaryManager.BoundaryReachedArgs)args).HasReached;
        };
        useGUILayout = true;
    }

    private void OnGUI()
    {
        if(!_hasReachedBoundary) return;
        
        GUIStyle style = new GUIStyle();

        style.fontSize = 48;
        style.font = (Font)Resources.Load("ThaleahFat_TTF");
        style.normal.textColor = Color.red;
        style.alignment = TextAnchor.MiddleCenter;
        
        GUILayout.BeginArea(new Rect(Screen.width / 2 - 250 , Screen.height / 2 - 150, 500, 300));
        GUILayout.Label("!!Boundary reached!!\nPlease turn around", style);
        GUILayout.EndArea();
    }
}