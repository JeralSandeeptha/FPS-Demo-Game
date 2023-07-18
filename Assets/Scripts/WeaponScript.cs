using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private float _shootRange = 300f;
    [SerializeField] private ParticleSystem _muzzleFlashFX;
    [SerializeField] private GameObject _hitImpactFX;
    [SerializeField] private AudioClip _shootSound;
    [SerializeField] private Camera _fpCamera;

    private AudioSource _audioSource;

    private float _normalFOV = 60f;
    private float _zoomFOV = 20f;

    private bool _isZoomedIn = false;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    //if we hit RMB we shoulf zoom in weapon

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            PlayerShoot();
            _muzzleFlashFX.Play();

            if (!_audioSource.isPlaying)
            {
                _audioSource.PlayOneShot(_shootSound);
            }
        }
        else {
            _muzzleFlashFX.Stop();
            _audioSource.Stop();
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (_isZoomedIn == false)
            {
                _fpCamera.fieldOfView = _zoomFOV;
                _isZoomedIn = true;
            }
            else {
                _fpCamera.fieldOfView = _normalFOV;
                _isZoomedIn = false;
            }
        }
    }

    private void PlayerShoot() 
    {
        RaycastHit _hitinfo;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out _hitinfo, _shootRange))//this is a bool
        {
            //create hit impact
            CreateHitImpact(_hitinfo);
        }
        else {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hitinfo)
    {
        //instantiate partical system
        GameObject _hitImpactClone = Instantiate(_hitImpactFX, hitinfo.point, Quaternion.LookRotation(hitinfo.normal));
        //destroy that partical system
        Destroy(_hitImpactClone, 1f);
    }
}
