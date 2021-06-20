using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BackgroundParallax : MonoBehaviour
{
    private float length, startpos;

    [SerializeField]
    private Transform cameraTransform;
    [SerializeField][Range(0,1)]
    private float paralaxEffect;

    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float temp = (cameraTransform.transform.position.x * (1 - paralaxEffect));
        float dist = (cameraTransform.transform.position.x * paralaxEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
    }
}
