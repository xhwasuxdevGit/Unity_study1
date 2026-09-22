using UnityEngine;

public class BulletShooter : MonoBehaviour  
{  
    private void Update()  
    {  
        ReadFireKey();  
    }

    private void ReadFireKey()  
    {  
        if (Input.GetKeyDown(KeyCode.Space))  
        {  
            Fire();  
        }  
    }

    private void Fire()  
    {  
        GameObject bullet = BulletPool.Instance.Take();

        if (bullet == null)  
        {  
            return;  
        }

        bullet.GetComponent<Bullet>().ResetState(transform.position);  
    }  
}

