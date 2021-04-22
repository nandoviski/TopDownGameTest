using System;
using UnityEngine;

public class PlayerRangeCombat : MonoBehaviour
{
    [SerializeField] GameObject ArrowPrefab;

    PlayerController playerController;

    AudioManager AudioManager => audioManager ??= FindObjectOfType<AudioManager>();
    AudioManager audioManager;

	void Start()
	{
        playerController = GetComponent<PlayerController>();
    }

	void Update()
    {
        if (Input.GetMouseButtonDown(0)) // && attackDelay == 0f
        {
            var angle = Util.AngleTowardsMouse(transform.position);
            var rot = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));
            Instantiate(ArrowPrefab, transform.position, rot);
            ArrowPrefab.GetComponent<Arrow>().ArrowDamage = playerController.AttackPower;

            PlayAudio();
        }
    }

    Action<GameObject> Coco()
    {
        Debug.Log("Hit " + gameObject.name);
        return null;
    }

    void PlayAudio()
    {
        AudioManager.Play("PlayerRangeShot");
    }
}
