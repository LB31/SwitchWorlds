using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class WorldManager : MonoBehaviour
{
    public static WorldManager Instance;

    private GameObject world;

    public TextMeshProUGUI TestText;

    public RectTransform JoyStick;
    public RectTransform JumpButton;

    private DeviceOrientation oldOrientation;

    public delegate void WorldSpin();
    public WorldSpin WorldWasSpinned;

    private bool spinnedWorld;

    private EnemyController ec;

    private AudioSource audio;
    // 0 = real world; 1 = fantasy world
    public AudioClip[] audioClips;

    public float speed = 0.1F;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Debug.Log("startomat");
        audio = GetComponent<AudioSource>();
        audio.clip = audioClips[0];
        audio.Play();
        Screen.orientation = ScreenOrientation.Portrait;
        world = gameObject;

        oldOrientation = DeviceOrientation.Unknown;

    }

    // Update is called once per frame
    string text;
    void Update()
    {


        if (Input.deviceOrientation == DeviceOrientation.Portrait && Input.deviceOrientation != oldOrientation) {
            text = "portrait";

            if(oldOrientation != DeviceOrientation.Unknown)
            SpinWorld();

            oldOrientation = Input.deviceOrientation;
        } else if (Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown && Input.deviceOrientation != oldOrientation) {
            text = "upside down";
            SpinWorld();   
            oldOrientation = Input.deviceOrientation;
        }

        TestText.text = text;
    }


    public void SpinWorld() {
        HealthManager.Instance.KindOfDamage = !HealthManager.Instance.KindOfDamage;
        //StartCoroutine(SpinWorldOverTime());
        spinnedWorld = !spinnedWorld;
        WorldWasSpinned();
        SpinSticks();
        SpinAudio();
    }

    private void SpinAudio() {
        audio.clip = spinnedWorld ? audioClips[1] : audioClips[0];
        audio.Play();
    }

    private void SpinSticks() {
        //JoyStick.Rotate(new Vector3(0, 0, 180));
        // Top left anchro
        if(JoyStick.anchorMin.Equals(new Vector2(0, 1)) && JoyStick.anchorMax.Equals(new Vector2(0, 1))) {
            // To bottom right
            JoyStick.anchorMin = new Vector2(1, 0);
            JoyStick.anchorMax = new Vector2(1, 0);
            JoyStick.anchoredPosition = new Vector3(-170, 170, 0);

            JumpButton.anchorMin = new Vector2(0, 0);
            JumpButton.anchorMax = new Vector2(0, 0);
            JumpButton.anchoredPosition = new Vector3(170, 170, 0);

    
        } else {
            // To top left
            JoyStick.anchorMin = new Vector2(0, 1);
            JoyStick.anchorMax = new Vector2(0, 1);
            JoyStick.anchoredPosition = new Vector3(170, -170, 0);

            JumpButton.anchorMin = new Vector2(1, 1);
            JumpButton.anchorMax = new Vector2(1, 1);
            JumpButton.anchoredPosition = new Vector3(-170, -170, 0);

        }

    }

    // TODO
    private IEnumerator SpinWorldOverTime() {
        float spinDegree = 0;
        while(spinDegree <= 180) {

        }
        world.transform.Rotate(new Vector3(0, 0, 180));
        yield return null;
    }


}
