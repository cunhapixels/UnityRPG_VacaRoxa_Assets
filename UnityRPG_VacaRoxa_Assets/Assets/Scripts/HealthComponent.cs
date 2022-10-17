using Interfaces;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class HealthComponent : MonoBehaviour, IDamageable<float>, IKillable, IShieldable<float>, ICurable<float>
{
    // Fields
    [Header("Health Setup")]
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float currentHealth;

    [Header("Shield Setup")] 
    [SerializeField] private float maxShield;
    [SerializeField] private float currentShield;

    // UI Elements
    private IComunicable<float> uiComunicableElement;

    // Properties
    private bool IsAlive { set; get; }
    private float CurrentHealth { set => currentHealth = value; get => currentHealth; }
    private float CurrentShield { set => currentShield = value; get => currentShield; }


    private void Start()
    {
        // initial setup
        CurrentHealth = maxHealth;
        //CurrentShield = maxShield;
        IsAlive = true;
    }

    
    // virtual method IDamageable to take damage
    public virtual void ApplyDamage(float damageTaken)
    {
        // check entity is alive
        if (!CheckIsAlive())
        {
            // kill it!
            Kill();
            
            // then return
            return;
        }

        // check if have a shield
        if (CurrentShield > 0)
        {
            // check if shield amount is greater than damage amount
            if (CurrentShield < damageTaken)
            {
                // temp damage amount var before shield tank
                var tempDamage = damageTaken - CurrentShield;
                
                // Remove shield as well
                RemoveShield(damageTaken);
                
                // Apply the rest of damage
                CurrentHealth = CurrentHealth - tempDamage;
            }
            else
            {
                // just remove shield in case of damage amount is smaller than shield amount
                RemoveShield(damageTaken);
            }
            
        }
        else
        {
            // if is alive, apply damage
            CurrentHealth = Mathf.Max(CurrentHealth - damageTaken, 0);
        }

        UpdateHealthBar();
        
        // double check if entity persists alive, if not kill it inside CheckIsAlive method
        CheckIsAlive();
        
        // debug to test 
        Debug.Log(gameObject.name + " vida atual: " + CurrentHealth);
    }

    
    private void UpdateHealthBar()
    {
        var uiHealthbar = gameObject.GetComponentInChildren<IComunicable<float>>();
        
        if (uiHealthbar != null) uiHealthbar.UpdateUIHealthText(CurrentHealth);
    }


    // virtual method IDamageable to check IsAlive and destroy if not 
    public virtual bool CheckIsAlive()
    {
        // check amount of temporary health
        if (CurrentHealth <= 0)
        {
            // if current health is under the zero kill it
            Kill();
            
            // and return IsAlive false 
            return IsAlive;
        }
        else return IsAlive; // if not then return IsAlive true
    }
    
    // virtual method IKillable to kill and destroy entity
    public virtual void Kill()
    {
        // flag it
        IsAlive = false;
        
        // destroy gameObject that is hold this component
        Destroy(gameObject);
        
        // debug to test
        Debug.Log("Morri!");
    }
    
    
    // virtual method IShieldable to remove shield
    public virtual void RemoveShield(float shieldAmount)
    {
        // Remove from current shiled the amount pass by parameter 
        CurrentShield = Mathf.Max(CurrentShield - shieldAmount, 0);
        
        // debug to test 
        Debug.Log(gameObject.name + " escudo atual: " + CurrentShield);
    }
    
    
    // virtual method IShieldable to add some shield
    public void AddShield(float shieldAmount)
    {
        // Add to current shiled the amount pass by parameter
        CurrentShield = Mathf.Min(CurrentShield + shieldAmount, maxShield);
        
        // debug to test 
        Debug.Log(gameObject.name + " escudo atual: " + CurrentShield);
    }
    
    
    // virtual method ICurable to add some health
    public void ApplyCure(float cureTaken)
    {
        // Add to current health the amount pass by parameter
        CurrentHealth = Mathf.Min(CurrentHealth + cureTaken, maxHealth);
        
        UpdateHealthBar();
        
        // debug to test 
        Debug.Log(gameObject.name + " vida atual: " + CurrentHealth);
    }

    public bool CheckHealthIsFull()
    {
        if (CurrentHealth == maxHealth) return true;
        else return false;
    }
    
}
