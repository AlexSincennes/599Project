// Copyright 2015 Google Inc.

using UnityEngine;
using UnityEngine.UI;

namespace Google.Cast.RemoteDisplay.UI {
  /**
   * The button in a CastListDialog for selecting a Cast device.
   */
  public class CastListButton : MonoBehaviour {
    /**
     * The clickable button used to select a Cast device.
     */
    public Button button;
    /**
     * The label with the Cast device name.
     */
    public Text nameLabel;
    /**
     * The label with the Cast device status information.
     */
    public Text statusLabel;
    /**
     * The icon displayed by the button.
     */
    public RawImage icon;
  }
}
