using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Transform StartPosition;
    [SerializeField] GameObject PlayerPrefab;
    private GameObject PlayerCharacter;
    public int PlayerNumber;
    public PlayerInput Input { get; private set; }
    // Start is called before the first frame update
    private void Awake()
    {
        Application.runInBackground = true;

        Input = GetComponent<PlayerInput>();
    }

    private void Start()
    {
    }

    public void GameStart()
    {
        PlayerCharacter = Instantiate(PlayerPrefab, StartPosition);
        PlayerCharacter.tag = "Player" + PlayerNumber;
        PlayerCharacter.GetComponent<UnityStandardAssets._2D.Player2UserControls>().SetPlayer(this);
        FindObjectOfType<hatThrow>().SetPlayer(PlayerCharacter, PlayerNumber);
        //PlayerCharacter.GetComponent<hatThrow>().SetPlayer(this);
    }

    // Update is called once per frame
    void Update()
    {
       // Input.Horizontal
    }
}
