using UnityEngine;

public class PlayerRangeCombat : MonoBehaviour
{
    [SerializeField] GameObject ArrowPrefab;

    AudioManager AudioManager => audioManager ??= FindObjectOfType<AudioManager>();
    AudioManager audioManager;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // && attackDelay == 0f
        {
            var angle = Util.AngleTowardsMouse(transform.position);
            var rot = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));

            PlayAudio();

            Instantiate(ArrowPrefab, transform.position, rot);
        }
    }

    void PlayAudio()
    {
        AudioManager.Play("PlayerRangeShot");
    }
}
