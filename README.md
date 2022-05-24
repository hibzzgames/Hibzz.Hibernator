# Hibzz.Hibernator
![npm](https://img.shields.io/npm/dt/com.hibzz.hibernator?color=fb8717&style=for-the-badge) ![LICENSE](https://img.shields.io/badge/LICENSE-CC--BY--4.0-ee5b32?style=for-the-badge) [![Twitter Follow](https://img.shields.io/twitter/follow/hibzzgames?color=1a8cd8&style=for-the-badge)](https://twitter.com/hibzzgames) [![Discord](https://img.shields.io/discord/695898694083412048?color=788bd9&label=DIscord&style=for-the-badge)](https://discord.gg/tZdZFK7) ![Unity](https://img.shields.io/badge/unity-%23000000.svg?style=for-the-badge&logo=unity&logoColor=white) ![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)

 A library used to create low performant idle applications in Unity

**Without Hibernator**

![image](https://user-images.githubusercontent.com/37605842/169102028-5f13ad7d-8c4c-4934-80d8-ed9698bdfe7a.png)

**With Hibernator**

![image](https://user-images.githubusercontent.com/37605842/169102077-b522b8b3-dd25-4953-aa97-28d9548c9fc3.png)

<br>

## Installation
**Via NPM**
This package is published to the NPM registery, so users can install and get updates directly in the Unity Package Manager when the package is installed via NPM.
- Navigate to the advanced project settings menu in the Unity Package Manager
- Create a new scoped registry with the URL `https://registry.npmjs.org`
- Add `com.hibzz.hibernator` as scope
- Now you'll be able to view and install the package under the "My Registeries" in the Package Manager.

**Via Github**
This package can be installed in the Unity Package Manager using the following git URL.
```
https://github.com/Hibzz-Games/Hibzz.Hibernator.git
```

<br>

## Usage
Initializing the Hibernator
```c#
using Hibzz.Hibernator;

public class GameManager : MonoBehavior
{
    void start()
    {
        // Start the system
        Hibernator.Instance.Begin();

        // Optionally, you can specify render interval. Here, the screen is 
        // refreshed once every 15 seconds
        Hibernator.Instance.Begin(15.0f);
    }

    void OnDestroy()
    {
        // Stop the system
        Hibernator.Instance.Stop();
    }
}
```

Refreshing Graphics
```c#
using Hibzz.Hibernator;

public class RotateClass : MonoBehavior
{
    public float speed = 50.0f;

    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            transform.Rotate(Vector3.up, speed * Time.DeltaTime);
            Hibernator.Instance.Refresh(); // Requests the graphics system to be updated
        }
    }
}
```

<br>

### Optional Features
While refreshing the hibernator, users can optionally give a time and the system will keep refreshing for the given time. This time is scalable by Time.TimeScale.

```c#
// the hibernator will continue to run with max refresh rate for the next 4.5 seconds
Hibernator.Instance.Refresh(4.5f);
```
