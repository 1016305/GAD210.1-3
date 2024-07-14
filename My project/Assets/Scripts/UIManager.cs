using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI displayStats;
    [SerializeField] GameObject playerRef;
    PlayerBehaviour playerBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        playerBehaviour = playerRef.GetComponent<PlayerBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        var jaja = playerBehaviour.DisplayStats();
        displayStats.text = jaja.Item1 + "\n" + jaja.Item2;
    }
}
