using UnityEngine;

public enum StatType
{
  Add,
  Multiple,
  Override
}

[CreateAssetMenu(fileName = "Stat", menuName = "Stat/new Stat")]
public class StatSO : ScriptableObject
{
  public StatType Type;
  public int MaxHP;
  public int MaxStamina;
  public int StaminaRegenAmount;

  [Header("Walk")]
  public float WalkSpeed;

  [Header("Jump")]
  public int JumpStaminaAmount;
  public float JumpPower;
  public int JumpNum;

  public StatSO DeepCopy()
  {
    return Instantiate(this);
  }

  public void Add(StatSO other)
  {
    this.MaxHP += other.MaxHP;
    this.MaxStamina += other.MaxStamina;
    this.StaminaRegenAmount += other.StaminaRegenAmount;
    this.JumpStaminaAmount += other.JumpStaminaAmount;
    this.WalkSpeed += other.WalkSpeed;
    this.JumpPower += other.JumpPower;
    this.JumpNum += other.JumpNum;
  }

  public void Multiply(StatSO other)
  {
    this.MaxHP *= other.MaxHP;
    this.MaxStamina *= other.MaxStamina;
    this.StaminaRegenAmount *= other.StaminaRegenAmount;
    this.JumpStaminaAmount *= other.JumpStaminaAmount;
    this.WalkSpeed *= other.WalkSpeed;
    this.JumpPower *= other.JumpPower;
    this.JumpNum *= other.JumpNum;
  }
}
