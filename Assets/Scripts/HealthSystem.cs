using UnityEngine;

public class HealthSystem
{
    public HealthSystem(int initialLife) 
    {
        lifes = initialLife;
        currentLife = initialLife;
    }

    private int lifes = 3; // Max Lifes
    private int currentLife = 0; // Real Time Lifes
    public int Health => currentLife;
    public bool IsDead => currentLife > 0 ? false : true;

    /// <summary>
    /// Metodo que setea el valor actual de la vida
    /// </summary>
    /// <param name="life">valor a guardar en current life</param>
    private void SetHealth(int life)
    {
        currentLife = life;
        UIController.Instance?.SetHealthUI(currentLife);
    }

    public void SubstractHealth()
    {
        currentLife--;
        currentLife = Mathf.Clamp(currentLife, 0, lifes);
        SetHealth(currentLife);
    }

    public void ResetHealth() 
    {
        SetHealth(lifes);
    }
}
