using UnityEngine;

public class Scorch : MonoBehaviour
{
    public float rampTime;
    public float decayDelay;
    public float decayTime;
    public GameObject destroyOnEnd;

    Renderer _renderer;
    MaterialPropertyBlock propertyBlock;

    private float fresnelPower = 0;
    private float _rampTime;
    private float _decayTime;
    private bool hasTriggered = false;

    private void Awake()
    {
        _renderer = gameObject.GetComponent<Renderer>();
        propertyBlock = new MaterialPropertyBlock();
        _decayTime = decayTime;
        _rampTime = rampTime;
    }

    void Update()
    {
        if (_rampTime > 0)
        {
            _rampTime -= Time.deltaTime;
            fresnelPower += Time.deltaTime / rampTime;
            SetRadiusProperty();
        }
        else if (decayDelay > 0)
        {
            decayDelay -= Time.deltaTime;
        }
        else if (_decayTime > 0)
        {
            _decayTime -= Time.deltaTime;
            fresnelPower -= decayTime * Time.deltaTime;
            SetRadiusProperty();
        }
        else if (hasTriggered == false)
        {
            hasTriggered = true;
            if (destroyOnEnd != null)
            {
                Destroy(destroyOnEnd);
            }
        }
    }

    void SetRadiusProperty()
    {
        _renderer.GetPropertyBlock(propertyBlock);
        propertyBlock.SetFloat("_Radius", fresnelPower);
        _renderer.SetPropertyBlock(propertyBlock);
    }
}
