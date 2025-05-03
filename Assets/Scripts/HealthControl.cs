using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private float _maxHealth = 100;
    private float _currentHealth;
    [SerializeField] private Image _healthBarFill;
    [SerializeField] private PlayerControl _playerController;
    [SerializeField] private float _dameAmount;
    [SerializeField] private float _regenRate = 5f;

    private float Push = 5;

    private Rigidbody2D rb;

    Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            rb.AddForce(Vector2.up * Push, ForceMode2D.Impulse);
            TakeDamage(_dameAmount);
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
          if (collision.CompareTag("Heal"))
        {
            HealPoshin();
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Statue"))
        {
            RegenerateHealth();
        }
        
    }
    private void TakeDamage(float amount)
    {
        _currentHealth -= amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);

        if (_currentHealth == 0)
        {
            _playerController.Die();
            _currentHealth = _maxHealth;
        }
        UpdateHealthBar();
    }
    private void UpdateHealthBar()
    {
        _healthBarFill.fillAmount = _currentHealth / _maxHealth;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        
    }

    

    private void Update()
    {
        
    }
    public void HealPoshin()
    {
        _currentHealth += 100;

        UpdateHealthBar();
    }

    private void RegenerateHealth()
    {
        if (_currentHealth < _maxHealth)
        {
            _currentHealth += _regenRate * Time.deltaTime;
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
            UpdateHealthBar();
        }
    }
}
