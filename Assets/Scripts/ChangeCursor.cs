using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    [SerializeField]
    private Texture2D cursorSprite;

    void Start()
    {
        Cursor.SetCursor(cursorSprite, Vector2.zero, CursorMode.Auto);
    }

}
