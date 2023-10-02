using UnityEngine;

public class FloatingTarget : MonoBehaviour, IHittable
{
    [SerializeField] public Target _target;
    [SerializeField] private ParticleSystem explosionPrefab;
    [SerializeField] public AudioSource explosionSE;
    [SerializeField] private Material redLightMaterial;
    private Renderer _renderer;
    
    public static event ArcheryEvents OnCheckArchery;
    public delegate void ArcheryEvents();

    void Start()
    {
        _target.hp = _target.hpMax;
        _target.targetDestroyed = false;
        _target.targetCounted = false;
        _renderer = GetComponent<Renderer>();
    }
    

    public void GetHit()
    {
        _target.hp--;
        if (_target.hp <= 0)
        {
            AudioSource.PlayClipAtPoint(explosionSE.clip, transform.position);
            Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity); 
            _target.targetDestroyed = true;
            OnCheckArchery?.Invoke();
            Destroy(gameObject);
        }
        
        else if (_target.hp == 1) 
        {
            var materials = _renderer.materials;
            materials[1] = redLightMaterial;
            _renderer.materials = materials;
        }
    }
}
public interface IHittable
{
    void GetHit();
}
