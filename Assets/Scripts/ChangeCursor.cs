using UnityEngine;
using System.Collections;

public class ChangeCursor : MonoBehaviour
{
    [SerializeField]
    private Sprite cursorSprite;

    void Start()
    {
        Cursor.SetCursor(cursorSprite.texture, Vector2.zero, CursorMode.Auto);
    }

}
