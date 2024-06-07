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

  [Header("Dash")]
  public int DashStaminaAmount;
  public float DashDuration;
  public float DashDistance;

  [Header("Climb")]
  public float ClimbSpeed;

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

    this.DashStaminaAmount += other.DashStaminaAmount;
    this.DashDuration += other.DashDuration;
    this.DashDistance += other.DashDistance;

    this.ClimbSpeed += other.ClimbSpeed;
  }

  public void Subtract(StatSO other)
  {
    this.MaxHP -= other.MaxHP;
    this.MaxStamina -= other.MaxStamina;
    this.StaminaRegenAmount -= other.StaminaRegenAmount;
    this.JumpStaminaAmount -= other.JumpStaminaAmount;
    this.WalkSpeed -= other.WalkSpeed;
    this.JumpPower -= other.JumpPower;
    this.JumpNum -= other.JumpNum;

    this.DashStaminaAmount -= other.DashStaminaAmount;
    this.DashDuration -= other.DashDuration;
    this.DashDistance -= other.DashDistance;

    this.ClimbSpeed -= other.ClimbSpeed;
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

    this.DashStaminaAmount *= other.DashStaminaAmount;
    this.DashDuration *= other.DashDuration;
    this.DashDistance *= other.DashDistance;

    this.ClimbSpeed *= other.ClimbSpeed;
  }
}
