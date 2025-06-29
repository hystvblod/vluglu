# Vluglu Unity Project

This repository serves as the starting point for a Unity game. The repo does not
include any actual project files yet, but you can create or import a Unity
project in this directory.

## Folder Structure
The project uses a standard Unity layout under the `Assets/` directory:

- `Scripts/` – C# game logic and ad wrappers.
- `Prefabs/` – reusable prefabs such as UI elements or grid pieces.
- `Scenes/` – Unity scenes for your game levels.
- You can add more folders (for example `Art/` or `Audio/`) as needed.

## Opening in Unity
1. Install **Unity Hub** and a recent version of the Unity editor (2020 or newer is recommended).
2. Clone this repository to a location on your computer.
3. In Unity Hub, click **Add**, navigate to the cloned folder, and select it.
4. Open the project from Unity Hub. Unity will generate the necessary project
   files if they do not already exist.

## Running the Game
1. After the project opens in Unity, press the **Play** button in the top middle
   of the editor. Unity will enter Play mode and run the game scene currently
   loaded.
2. When you are done, press **Play** again to exit Play mode.

## Building for Android
1. In Unity Hub, ensure you have installed the **Android Build Support** module
   (including the SDK, NDK, and OpenJDK options).
2. Open the project in Unity and go to **File → Build Settings**.
3. Select **Android** in the platform list and click **Switch Platform** if it is
   not already active.
4. Set your package name (for example `com.yourcompany.vluglu`) in
   **Project Settings → Player** under **Other Settings**.
5. Click **Build** or **Build and Run** to generate the Android APK/AAB.

## Building for iOS
1. In Unity Hub, install **iOS Build Support**.
2. Open the project and choose **File → Build Settings**.
3. Select **iOS** in the platform list and click **Switch Platform**.
4. Configure your bundle identifier in **Project Settings → Player**.
5. Click **Build** to export an Xcode project. Open that project in Xcode and
   build or archive it for deployment to an iOS device or the App Store.

## Integrating Ad SDKs for Production
1. Choose an ad provider such as **Unity Ads**, **Google AdMob**, or another
   network that supports Unity.
2. Use the Unity Package Manager or the provider's official Unity package to
   install the SDK.
3. Follow the provider's setup instructions to initialize the SDK with your
   unique app/game IDs.
4. Replace any placeholder ad calls with actual implementation from the SDK.
   Typically this involves loading and showing banners, interstitials, or
   rewarded ads via the SDK's API.
5. Always test ads using the provider's test mode or test IDs before releasing
   to production.
6. When preparing a production build, make sure your ad placements are properly
   configured in the provider's dashboard and that you use your real ad unit
   identifiers in the Unity project.

## Setting Up the GameManager
1. Create an empty **GameObject** in your scene and name it `GameManager`.
2. Add the provided scripts (**AudioManager**, **InterstitialAds**, and **RewardedAds**) as components.
3. Add two `AudioSource` components as children of `GameManager` and assign them in
   the `AudioManager` fields for music and sound effects.
4. If you create additional gameplay scripts, attach them here so other objects
   can reference the `GameManager` easily.

## Creating the Main Scene
1. From the Unity menu choose **File → New Scene** and save it in `Assets/Scenes`.
2. Add the `GameManager` object described above.
3. Create an empty `Grid` object or your own prefabs under the scene hierarchy.
4. Implement a script to detect swipes (e.g., using `Input.touches` or mouse
   drag events) and place it on the grid or a controller object.
5. During `Start` or `Awake`, instantiate your grid tiles or load a prefab to
   populate the board.

## Hooking Up Ads
The ad scripts contain placeholders for various networks. After importing your
actual SDK (Unity Ads, Google AdMob, AppLovin, etc.):

1. Open **InterstitialAds.cs** and **RewardedAds.cs** and replace the placeholder
   code with the SDK-specific load and show methods.
2. To trigger ads from UI elements, add a **Button** or **Event Trigger**
   component in the editor. In the **Inspector**, drag your `GameManager`
   object to the event field and select the appropriate method (`ShowAd`,
   `LoadAd`, etc.).
3. Unity's official documentation on [EventTriggers](https://docs.unity3d.com/Manual/script-EventTrigger.html)
   explains the available event types.
