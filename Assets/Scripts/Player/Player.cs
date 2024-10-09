using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
        [Header ("Roguelike")]
        [SerializeField]
        public Canvas m_Canvas;
        bool m_SeeCanvas;

        
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        void Update()
        {
            if (Input.GetButtonDown("tab"))
            {
                if (m_Canvas)
                {
                    m_SeeCanvas = false;
                    m_Canvas.gameObject.SetActive(m_SeeCanvas);
                }
            }
        }
}
