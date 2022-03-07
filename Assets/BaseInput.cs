using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace UnityEngine.EventSystems
{
    public class BaseInput : UIBehaviour
    {
        public virtual string compositionString
        {
             get{
               return Input.compositionString;
             }
        }
        public virtual IMECompositionMode imeCompositionMode
        {
            get { return Input.imeCompositionMode; }
            set { Input.imeCompositionMode = value; }
        }
         public virtual Vector2 compositionCursorPos
        {
            get { return Input.compositionCursorPos; }
            set { Input.compositionCursorPos = value; }
        }
        public virtual bool mousePresent
        {
            get { return Input.mousePresent; }
        }
        public virtual bool GetMouseButtonDown(int button)
        {
            print("get mouse button down");
            return Input.GetMouseButtonDown(button);
        }
        public virtual bool GetMouseButtonUp(int button)
        {
             print("get mouse button up");
            return Input.GetMouseButtonUp(button);
        }
        public virtual bool GetMouseButton(int button)
        {
             print("get mouse button");
            return Input.GetMouseButton(button);
        }
      /*  public virtual Vector2 mousePosition
        {
            get { return MultipleDisplayUtilities.GetMousePositionRelativeToMainDisplayResolution(); }
        } */
        public virtual Vector2 mouseScrollDelta
        {
            get { return Input.mouseScrollDelta; }
        }

        /// <summary>
        /// Interface to Input.touchSupported. Can be overridden to provide custom input instead of using the Input class.
        /// </summary>
        public virtual bool touchSupported
        {
            get { return Input.touchSupported; }
        }

        /// <summary>
        /// Interface to Input.touchCount. Can be overridden to provide custom input instead of using the Input class.
        /// </summary>
        public virtual int touchCount
        {
            get { return Input.touchCount; }
        }

        /// <summary>
        /// Interface to Input.GetTouch. Can be overridden to provide custom input instead of using the Input class.
        /// </summary>
        /// <param name="index">Touch index to get</param>
        public virtual Touch GetTouch(int index)
        {
            return Input.GetTouch(index);
        }

        /// <summary>
        /// Interface to Input.GetAxisRaw. Can be overridden to provide custom input instead of using the Input class.
        /// </summary>
        /// <param name="axisName">Axis name to check</param>
        public virtual float GetAxisRaw(string axisName)
        {
            return Input.GetAxisRaw(axisName);
        }

        /// <summary>
        /// Interface to Input.GetButtonDown. Can be overridden to provide custom input instead of using the Input class.
        /// </summary>
        /// <param name="buttonName">Button name to get</param>
        public virtual bool GetButtonDown(string buttonName)
        {
            return Input.GetButtonDown(buttonName);
        }

    }
}
