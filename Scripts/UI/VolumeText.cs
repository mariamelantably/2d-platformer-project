using UnityEngine;
using UnityEngine.UI;

public class VolumeText : MonoBehaviour
{
    [SerializeField] private string volumeName;
    [SerializeField] private string textIntro;
    private Text txt;
    private RectTransform rect;
    private float x;

    private void Awake()
    {
        txt = GetComponent<Text>();
        rect = GetComponent<RectTransform>();
        x = rect.position.x;
    }

    private void Update()
    {
        UpdateVolume();
    }

    private void UpdateVolume()
    {
        float volume = PlayerPrefs.GetFloat(volumeName) *100;
        txt.text = textIntro +volume.ToString();
        rect.position = new Vector3(x, rect.position.y, rect.position.z);
        
    }
}
