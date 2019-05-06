using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float xMargin = 1f; // Distance in the x axis the player can move before the camera follows.
    public float yMargin = 1f; // Distance in the y axis the player can move before the camera follows.
    public float xSmooth = 8f; // How smoothly the camera catches up with it's target movement in the x axis.
    public float ySmooth = 8f; // How smoothly the camera catches up with it's target movement in the y axis.
    public Vector2 maxXAndY; // The maximum x and y coordinates the camera can have.
    public Vector2 minXAndY; // The minimum x and y coordinates the camera can have.

    [SerializeField] private float maxSize;
    [SerializeField] private float minSize;
    [SerializeField] private bool closeView;
    [SerializeField]private GameController controller;
    [SerializeField] private CameraParamsDB paramDB;
    private Camera cam;
    [SerializeField] private Transform m_Player; // Reference to the player's transform.

    void Start()
    {
        // set the desired aspect ratio (the values in this example are
        // hard-coded for 16:9, but you could make them into public
        // variables instead so you can set them at design time)
        float targetaspect = 16.0f / 9.0f;

        // determine the game window's current aspect ratio
        float windowaspect = (float)Screen.width / (float)Screen.height;

        // current viewport height should be scaled by this amount
        float scaleheight = windowaspect / targetaspect;

        // obtain camera component so we can modify its viewport
        Camera camera = GetComponent<Camera>();

        // if scaled height is less than current height, add letterbox
        /*if (scaleheight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;

            camera.rect = rect;
        }
        else // add pillarbox
        {
            float scalewidth = 1.0f / scaleheight;

            Rect rect = camera.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }*/
        CameraParams a = paramDB.GetParams();
        maxXAndY = new Vector2(a.maxOffsetX, a.maxOffsetY);
        minXAndY = new Vector2(-a.maxOffsetX, -a.maxOffsetY);
        maxSize = a.maxSize;
        maxSize = a.maxSize;

    }

    private void Awake()
    {
        // Use this for initialization
        cam = GetComponent<Camera>();
        controller.changedPlayer += ChangePlayer;
    }


    private bool CheckXMargin()
    {
        // Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
        return Mathf.Abs(transform.position.x - m_Player.position.x) > xMargin;
    }


    private bool CheckYMargin()
    {
        // Returns true if the distance between the camera and the player in the y axis is greater than the y margin.
        return Mathf.Abs(transform.position.y - m_Player.position.y) > yMargin;
    }

    private bool CheckXMarginZero()
    {
        // Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
        return Mathf.Abs(transform.position.x) > xMargin;
    }


    private bool CheckYMarginZero()
    {
        // Returns true if the distance between the camera and the player in the y axis is greater than the y margin.
        return Mathf.Abs(transform.position.y) > yMargin;
    }


    private bool CheckSize( float s)
    {
        if (cam.orthographicSize != s)
            return true;
        else
            return false;
    }

    public void ChangeMode()
    {
        closeView = !closeView;
    }

    private void Update()
    {
        if (closeView)
        {
            TrackPlayer();
        }
        else
        {
            TrackMap();
        }
    }


    private void TrackPlayer()
    {
        // By default the target x and y coordinates of the camera are it's current x and y coordinates.
        float targetX = transform.position.x;
        float targetY = transform.position.y;
        float currentSize = cam.orthographicSize;
        // If the player has moved beyond the x margin...
        if (CheckXMargin())
        {
            // ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
            targetX = Mathf.Lerp(transform.position.x, m_Player.position.x, xSmooth * Time.deltaTime);
        }

        // If the player has moved beyond the y margin...
        if (CheckYMargin())
        {
            // ... the target y coordinate should be a Lerp between the camera's current y position and the player's current y position.
            targetY = Mathf.Lerp(transform.position.y, m_Player.position.y, ySmooth * Time.deltaTime);
        }
        if (CheckSize(minSize))
        {
            // ... the target y coordinate should be a Lerp between the camera's current y position and the player's current y position.
            cam.orthographicSize = Mathf.Lerp( currentSize, minSize, ySmooth * Time.deltaTime);
        }
        
        // The target x and y coordinates should not be larger than the maximum or smaller than the minimum.
        targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
        targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

        // Set the camera's position to the target position with the same z component.
        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }

    private void TrackMap()
    {
        // By default the target x and y coordinates of the camera are it's current x and y coordinates.
        float targetX = transform.position.x;
        float targetY = transform.position.y;
        float currentSize = cam.orthographicSize;

        // If the player has moved beyond the x margin...
        if (CheckXMarginZero())
        {
            // ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
            targetX = Mathf.Lerp(transform.position.x, 0, xSmooth * Time.deltaTime);
        }

        // If the player has moved beyond the y margin...
        if (CheckYMarginZero())
        {
            // ... the target y coordinate should be a Lerp between the camera's current y position and the player's current y position.
            targetY = Mathf.Lerp(transform.position.y, 0, ySmooth * Time.deltaTime);
        }
        if (CheckSize(maxSize))
        {
            // ... the target y coordinate should be a Lerp between the camera's current y position and the player's current y position.
            cam.orthographicSize = Mathf.Lerp( currentSize,maxSize, xSmooth*4 * Time.deltaTime);
        }
        // The target x and y coordinates should not be larger than the maximum or smaller than the minimum.
        targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
        targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

        // Set the camera's position to the target position with the same z component.
        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }

    public void ChangePlayer(Transform t)
    {
        m_Player = t;
        closeView = true;
    }
}
