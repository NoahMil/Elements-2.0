using UnityEngine;

public class FloatingTarget : MonoBehaviour
{
    public float floatAmplitude = 0.5f; // Amplitude du mouvement de lévitation
    public float floatSpeed = 1.0f; // Vitesse de lévitation
    [SerializeField] private Target _target;
    
    [SerializeField] private AudioSource audioSource;

    private Vector3 startPosition;
    
    public delegate void ArcheryEvents();

    public static event ArcheryEvents OnCheckArchery;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float floatOffset = Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.position = startPosition + Vector3.up * floatOffset;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetHit();
        }
    }
    
    public void GetHit()
    {
        _target.hp--;
        if(_target.hp <= 0)
        {
            _target.targetCompleted = true;
            OnCheckArchery?.Invoke();
        }
    }
    
}
public interface IHittable
{
    void GetHit();
}