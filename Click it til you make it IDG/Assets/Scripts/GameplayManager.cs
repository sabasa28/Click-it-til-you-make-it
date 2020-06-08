using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public float petsPerClick = 1;
    float maxPetsReached = 0;
    float currentPets = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateMaxPets(int currentPetAmmount)
    {
        if (currentPetAmmount>maxPetsReached) maxPetsReached = currentPetAmmount;
    }

    void OnClickAddPets()
    {
        currentPets += petsPerClick;
    }

}
