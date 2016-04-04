using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Gun))]
public class GunScriptEditor : Editor
{


    public override void OnInspectorGUI()
    {
        Gun myGunScript = (Gun)target;
        myGunScript.fireType = (FireType)EditorGUILayout.EnumPopup("Fire Type", myGunScript.fireType);
        switch (myGunScript.fireType)
        {
            case FireType.Automatic:
                myGunScript.roundsPerMinute = EditorGUILayout.FloatField("Rounds per Minute", myGunScript.roundsPerMinute);
                break;
            case FireType.SemiAutomatic:
                myGunScript.semiFireRate = EditorGUILayout.FloatField("Time between shots", myGunScript.semiFireRate);
                break;
            case FireType.BoltOrPumpAction:
                //myGunScript.pumpTime = EditorGUILayout.FloatField("Pump Time", myGunScript.pumpTime);
                break;
            case FireType.BurstFire:
                myGunScript.burstAmount = EditorGUILayout.IntField("Burst Shot Amount", myGunScript.burstAmount);
                myGunScript.timeBetweenBurst = EditorGUILayout.FloatField("Burst Shot Delay", myGunScript.timeBetweenBurst);
                myGunScript.burstSpeed = EditorGUILayout.FloatField("Burst Rate of fire", myGunScript.burstSpeed);
                break;


        }
        myGunScript.ammoInClip = EditorGUILayout.IntField("Current Amount of Bullets", myGunScript.ammoInClip);
        myGunScript.fullAmmoInClip = EditorGUILayout.IntField("Max Amount of Bullets", myGunScript.fullAmmoInClip);
        myGunScript.looseAmmo = EditorGUILayout.IntField("Ammo Carrying Around", myGunScript.looseAmmo);

        //myGunScript.reloadSpeed = EditorGUILayout.FloatField("Time spent Reloading", myGunScript.reloadSpeed);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("EmptySound");
        myGunScript.emptySound = (AudioClip)EditorGUILayout.ObjectField(myGunScript.emptySound, typeof(AudioClip), true);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("ShotSound");
        myGunScript.shot = (AudioClip)EditorGUILayout.ObjectField(myGunScript.shot, typeof(AudioClip), true);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("CockSound");
        myGunScript.pumpSound = (AudioClip)EditorGUILayout.ObjectField(myGunScript.pumpSound, typeof(AudioClip), true);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("ReloadSound");
        myGunScript.reloadSound = (AudioClip)EditorGUILayout.ObjectField(myGunScript.reloadSound, typeof(AudioClip), true);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("Clip And Loose");
        myGunScript.clip = (Text)EditorGUILayout.ObjectField(myGunScript.clip, typeof(Text), true);
        myGunScript.loose = (Text)EditorGUILayout.ObjectField(myGunScript.loose, typeof(Text), true);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("Mag, firepoint, bullet");
        myGunScript.clipObj = (GameObject)EditorGUILayout.ObjectField(myGunScript.clipObj, typeof(GameObject), true);
        myGunScript.firePoint = (Transform)EditorGUILayout.ObjectField(myGunScript.firePoint, typeof(Transform), true);
        myGunScript.bullet = (GameObject)EditorGUILayout.ObjectField(myGunScript.bullet, typeof(GameObject), true);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("Aim and Normal Spots");
        myGunScript.aimSpot = (Transform)EditorGUILayout.ObjectField(myGunScript.aimSpot, typeof(Transform), true);
        myGunScript.normalSpot = (Transform)EditorGUILayout.ObjectField(myGunScript.normalSpot, typeof(Transform), true);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("Recoil Script");
        myGunScript.recoil = (Recoil)EditorGUILayout.ObjectField(myGunScript.recoil, typeof(Recoil), true);
        EditorGUILayout.EndHorizontal();
        myGunScript.recoilAmount = EditorGUILayout.FloatField("Recoil Amount", myGunScript.recoilAmount);
        myGunScript.recoilLength = EditorGUILayout.FloatField("Recoil Length", myGunScript.recoilLength);

    }
}
