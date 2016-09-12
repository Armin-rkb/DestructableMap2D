using UnityEngine;
using System.Collections;

public class GroundController : MonoBehaviour
{
    private SpriteRenderer sr;
    private float widthWorld, heigthWorld;
    private int widthPixel, heigthPixel;
    private Color transp;

    void Awake()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        // Load our original ground texture from the resources folder.
        Texture2D tex = (Texture2D)Resources.Load("ground");
        // Make a copy of our loaded texture.
        Texture2D tex_clone = (Texture2D)Instantiate(tex);
        sr.sprite = Sprite.Create(tex_clone,
                                  new Rect(0f, 0f, tex_clone.width, tex_clone.height),
                                  new Vector2(0.5f, 0.5f), 100f);

        transp = new Color(0f, 0f, 0f, 0f);
        InitSpriteDimension();
    }

    private void InitSpriteDimension()
    {
        widthWorld = sr.bounds.size.x;
        heigthWorld = sr.bounds.size.y;
        widthPixel = sr.sprite.texture.width;
        heigthPixel = sr.sprite.texture.height;
    }

    public void DestroyGround(CircleCollider2D cc)
    {
        print("Destroy ground!");
        V2int c = World2Pixel(cc.bounds.center.x , cc.bounds.center.y);
        int r = Mathf.RoundToInt((cc.bounds.size.x * widthPixel / widthWorld) / 2);

        int x, y, px, nx, py, ny, d;

        for (x = 0; x <= r; x++)
        {
            d = (int)Mathf.RoundToInt(Mathf.Sqrt(r * r - x * x));

            for (y = 0; y <= d; y++)
            {
                px = c.x + x;
                nx = c.x - x;
                py = c.y + y;
                ny = c.y - y;

                sr.sprite.texture.SetPixel(px, py, transp);
                sr.sprite.texture.SetPixel(nx, py, transp);
                sr.sprite.texture.SetPixel(px, ny, transp);
                sr.sprite.texture.SetPixel(nx, ny, transp);
            }
        }
        sr.sprite.texture.Apply();
        Destroy(GetComponent<PolygonCollider2D>());
        gameObject.AddComponent<PolygonCollider2D>();
    }

    private V2int World2Pixel(float x, float y)
    {
        V2int v = new V2int();

        float dx = x - transform.position.x;
        v.x = Mathf.RoundToInt(0.5f * widthPixel + dx * widthPixel / widthWorld);

        float dy = y - transform.position.y;
        v.y = Mathf.RoundToInt(0.5f * heigthPixel + dy * heigthPixel / heigthWorld);

        return v;
    }
}
