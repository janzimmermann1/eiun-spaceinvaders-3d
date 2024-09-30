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
        
        GUIStyle myStyle = new GUIStyle();

        myStyle.fontSize = 48;
        myStyle.font = (Font)Resources.Load("ThaleahFat_TTF");
        myStyle.normal.textColor = Color.red;
        myStyle.alignment = TextAnchor.MiddleCenter;
        
        GUILayout.BeginArea(new Rect(Screen.width/2 - 250 , Screen.height/2 - 150, 500, 300));
        GUILayout.Label("!!Boundary reached!!\nPlease turn around", myStyle);
        GUILayout.EndArea();
    }
}