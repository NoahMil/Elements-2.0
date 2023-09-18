using UnityEngine;

public class FloatingTarget : MonoBehaviour, IHittable
{
    private Rigidbody rb;
    private bool stopped = false;
    public ScoreArchery _scoreArchery;

    public float floatAmplitude = 0.5f;
    public float floatSpeed = 1.0f;

    [SerializeField] private Target _target;
    [SerializeField] private AudioSource audioSource;

    private Vector3 startPosition;

    public static event ArcheryEvents OnCheckArchery;
    public delegate void ArcheryEvents();

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    void Update()
    {
        if (!stopped)
        {
            float floatOffset = Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
            transform.position = startPosition + Vector3.up * floatOffset;
        }
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
        _target.hp--;
        if (_target.hp <= 0)
        {
            Destroy(gameObject);
            stopped = true;
            _scoreArchery.score++;
            _target.targetCompleted = true;
            OnCheckArchery?.Invoke();
        }
    }
}
