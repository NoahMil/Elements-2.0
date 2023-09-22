using UnityEngine;

public class FloatingTarget : MonoBehaviour, IHittable
{
    private Rigidbody rb;
    private bool stopped = false;
    public ScoreArchery _scoreArchery;
    public ParticleSystem explosionPrefab;
    [SerializeField] public AudioSource explosionSE;
    
    [SerializeField] private Target _target;
    [SerializeField] private AudioSource audioSource;

    private Vector3 startPosition;

    public static event ArcheryEvents OnCheckArchery;
    public delegate void ArcheryEvents();

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        _target.HP = _target.hpMax;
        _target.targetDestroyed = false;
    }

    void Update()
    {
        /*if (!stopped)
        {
            float floatOffset = Mathf.Sin(Time.time * _target.speed) * _target.amplitude;
            transform.position = startPosition + Vector3.up * floatOffset;
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((rb.isKinematic || collision.gameObject.CompareTag("Arrow")) == false)
        {
            audioSource.Play();
        }
    }

    public void GetHit()
    {
        _target.HP--;
        if (_target.HP <= 0)
        {
            AudioSource.PlayClipAtPoint(explosionSE.clip, transform.position);
            Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity); 
            stopped = true;
            _target.targetDestroyed = true;
            OnCheckArchery?.Invoke();
            Destroy(gameObject);
        }

    }
}
public interface IHittable
{
    void GetHit();
}
