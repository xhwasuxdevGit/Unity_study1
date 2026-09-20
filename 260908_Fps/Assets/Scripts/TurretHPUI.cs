
using UnityEngine;
using UnityEngine.UI;

public class TurretHPUI : MonoBehaviour
{
   [SerializeField] private Image HPGauage;
   [SerializeField] private TurretController _turret;
   
   public void UpdateUI(int turretHp)
   {
      if (HPGauage != null)
      {
         HPGauage.fillAmount = (float)turretHp / _turret.MaxTurretHP;
      }
   }
}
