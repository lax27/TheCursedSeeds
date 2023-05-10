using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotingTypesFunctions : MonoBehaviour
{
    public void BasicShoot(GameObject bullet, AudioClip sound, Animator animator, GameObject shells, CameraShake shake, GameObject gun, Transform canon, float timeShake, float magnitudeShake, float bulletDisspersion)
    {
        //feadBack
        shake.CameraShakeSettings(timeShake, magnitudeShake);

        animator.SetTrigger("Shoot");

        if(SoundController.instance == null)
        {
            FindObjectOfType<PlayerMovement>().gameObject.AddComponent<SoundController>();
        }

        SoundController.instance.PlaySound(sound);

        Instantiate(shells, gun.transform.position, Quaternion.identity);

        //gun logic
        BulletNormal dispersionBullet = bullet.GetComponent<BulletNormal>();
        dispersionBullet.dispersionAngle = bulletDisspersion;
        GameObject temp = Instantiate(bullet, canon.position, Quaternion.identity);
    }

    public void Shootgun(GameObject bullet, AudioClip sound, Animator animator, GameObject shells, CameraShake shake, GameObject gun, Transform canon, float timeShake, float magnitudeShake)
    {
        //feadBack
        shake.CameraShakeSettings(timeShake, magnitudeShake);

        animator.SetTrigger("Shoot");

        if (SoundController.instance == null)
        {
            FindObjectOfType<PlayerMovement>().gameObject.AddComponent<SoundController>();
        }

        SoundController.instance.PlaySound(sound);

        Instantiate(shells, gun.transform.position, Quaternion.identity);

        //gun logic
        GameObject temp = Instantiate(bullet, canon.position, Quaternion.identity);
        GameObject temp2 = Instantiate(bullet, canon.position, Quaternion.identity);
        GameObject temp3 = Instantiate(bullet, canon.position, Quaternion.identity);
        GameObject temp4 = Instantiate(bullet, canon.position, Quaternion.identity);
        GameObject temp5 = Instantiate(bullet, canon.position, Quaternion.identity);
        GameObject temp6 = Instantiate(bullet, canon.position, Quaternion.identity);
        GameObject temp7 = Instantiate(bullet, canon.position, Quaternion.identity);
        GameObject temp8 = Instantiate(bullet, canon.position, Quaternion.identity);
    }

    public void MachineGun(GameObject bullet, AudioClip sound, Animator animator, GameObject shells, CameraShake shake, GameObject gun, Transform canon, float timeShake, float magnitudeShake, int bulletCount)
    {
        //feadBack

        //gun logic
        BulletNormal dispersionBullet = bullet.GetComponent<BulletNormal>();
        if (bulletCount < 4)
        {
            dispersionBullet.dispersionAngle = 0f;
        }
        else if (bulletCount < 6)
        {
            dispersionBullet.dispersionAngle = 5f;
        }
        else if (bulletCount < 10)
        {
            dispersionBullet.dispersionAngle = 15f;
        }
        GameObject temp = Instantiate(bullet, canon.position, Quaternion.identity);
    }

    public void Rafaga(GameObject bullet, AudioClip sound, Animator animator, GameObject shells, CameraShake shake, GameObject gun, Transform canon, float timeShake, float magnitudeShake, float bulletDisspersion, PlayerMovement pM)
    {
        //feadBack
        shake.CameraShakeSettings(timeShake, magnitudeShake);

        //animator.SetBool("Shoot", true);


        Instantiate(shells, gun.transform.position, Quaternion.identity);

        //gun logic
        StartCoroutine(Burst(bullet, canon,pM, sound));   
    }

    IEnumerator Burst(GameObject bullet,Transform canon,PlayerMovement pM,AudioClip sound)
    {
        BulletStats statsBullet = bullet.GetComponent<BulletStats>();
        bullet.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
        statsBullet.damage = 1f;
        GameObject temp = Instantiate(bullet, canon.position, Quaternion.identity);
        SoundController.instance.PlaySound(sound);
        pM.rbPlayer.AddForce(pM.KnockBackDir * 65, ForceMode2D.Impulse);
        
        yield return new WaitForSeconds(0.07f);
       
        bullet.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
        statsBullet.damage = 1f;
        GameObject temp2 = Instantiate(bullet, canon.position, Quaternion.identity);
        SoundController.instance.PlaySound(sound);
        pM.rbPlayer.AddForce(pM.KnockBackDir * (65 * 2) , ForceMode2D.Impulse);
        
        yield return new WaitForSeconds(0.09f);

        bullet.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        statsBullet.damage = 3.5f;
        GameObject temp3 = Instantiate(bullet, canon.position, Quaternion.identity);
        SoundController.instance.PlaySound(sound);
        pM.rbPlayer.AddForce(pM.KnockBackDir * (65 * 3), ForceMode2D.Impulse);
        pM.isShooting = true;
    }
}
