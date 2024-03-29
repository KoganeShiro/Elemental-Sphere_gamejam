using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformSpwaner : MonoBehaviour
{
    public GameObject plateforms;
    public float spawner = 2;
    public float timer = 0;
     public float timer2 = 0;
    public float heightOfSpawn = 7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          timer2 += Time.deltaTime;
        if (timer2 > 10)
            spawner = 1.9F;
        if (timer2 > 20)
            spawner = 1.8F;
        if (timer2 > 30)
            spawner = 1.7F;
        if (timer2 > 40)
            spawner = 1.6F;
        if (timer2 > 50)
            spawner = 1.5F;
        if (timer2 > 60)
            spawner = 1.4F;
        if (timer2 > 70)
            spawner = 1.3F;
        if (timer2 > 80)
            spawner = 1.2F;
        if (timer2 > 90)
            spawner = 0.9F;
        if (timer2 > 100)
            spawner = 0.8F;
        if (timer >= spawner)
        {
            spawnPlateforme();
            timer = 0;
        }
        else
            timer += Time.deltaTime;
    }

void spawnPlateforme()
    {
        float lowestPoint = transform.position.y - heightOfSpawn;
        float highestPoint = transform.position.y + heightOfSpawn;

        // Sélection aléatoire d'un indice pour choisir une plateforme parmi les enfants
        int randomChildIndex = Random.Range(0, plateforms.transform.childCount);

        // Activer la plateforme sélectionnée aléatoirement et désactiver les autres
        for (int i = 0; i < plateforms.transform.childCount; i++)
        {
            if (i == randomChildIndex)
            {
                plateforms.transform.GetChild(i).gameObject.SetActive(true);
                // Appliquer une rotation aléatoire à la plateforme sélectionnée
                float randomRotationZ = Random.Range(0f, 360f);
                plateforms.transform.GetChild(i).rotation = Quaternion.Euler(0, 0, randomRotationZ);
            }
            else
            {
                plateforms.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        // Instancier la plateforme parent avec la position aléatoire
        Instantiate(plateforms, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}