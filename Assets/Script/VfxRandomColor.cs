using UnityEngine;
using UnityEngine.Experimental.VFX;

namespace Rcam
{
    sealed class VfxRandomColor : MonoBehaviour
    {
        [SerializeField] Color _defaultColor = Color.white;
        [SerializeField] Color _baseColor = Color.red;
        [SerializeField] float _hueWidth = 1;

        public void ResetToDefault()
        {
            _target.SetVector4(_id, _defaultColor);
        }

        public void Randomize()
        {
            float h, s, v;
            Color.RGBToHSV(_baseColor, out h, out s, out v);
            h = (h + (Random.value - 0.5f) * _hueWidth + 1) % 1.0f;
            Debug.Log(h + "/" + s + "/" + v);
            _target.SetVector4(_id, Color.HSVToRGB(h, s, v, true));
        }

        VisualEffect _target;
        int _id;

        void Start()
        {
            _target = transform.parent.GetComponent<VisualEffect>();
            _id = Shader.PropertyToID(gameObject.name);
        }
    }
}