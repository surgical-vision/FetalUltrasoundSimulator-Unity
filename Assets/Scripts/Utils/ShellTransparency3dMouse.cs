using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

namespace UnityVolumeRendering
{
    public class ShellTransparency3dMouse : MonoBehaviour
    {
        PlayerControls controls;

        public Material[] material;
        private int materialIndex = 0;
        Renderer rend;

        void Start()
        {
            rend = GetComponent<Renderer>();
            rend.enabled = true;
            rend.sharedMaterial = material[materialIndex];
        }

        void Awake()
        {
            controls = new PlayerControls();

            controls.Gameplay_3dmouse.ChangeMaterial.performed += ctx => ApplyNewMaterial();

        }

        void ApplyNewMaterial()
        {
            materialIndex = (materialIndex +1) % material.Length ;
            rend.sharedMaterial = material[materialIndex];
        }

        void OnEnable()
        {
            controls.Gameplay_3dmouse.Enable();
        }

        void OnDisable()
        {
            controls.Gameplay_3dmouse.Disable();
        }
    }
}