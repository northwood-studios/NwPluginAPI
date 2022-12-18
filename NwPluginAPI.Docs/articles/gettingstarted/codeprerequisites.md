# Plugin prerequisites
### The `Plugin` Class
- Your plugin must have a `Plugin` class.
- The `Plugin` class is the main class of your plugin. It contains the entry point of your plugin and is used to initialize your plugin.
  - It is typically named either `Plugin`, `MainClass`, or the name of your plugin.
- The `Plugin` class must have a method with the `PluginEntryPoint` attribute.
  - 4 parameters must be passed on to `PluginEntryPoint` attribute, in the following order: <br>
    Plugin Name, Plugin Version, Plugin Author, and Plugin Description.
  - If you are planning to use any kind of events, you would call `EventManager::RegisterEvents` in the `PluginEntryPoint` method, more on that in the EventHandlers section.
  - Here is also where a Singleton would be initialized.
### The `Config` Class
- #### The `Config` class isn't required, but is recommended since you will need to if you're planning on letting serverhosts make any changes to your plugin
- The `Config` class contains properties, which values will be serialized and deserialized into/from a YML file when the plugin loads.
  - Properties are similar to fields, except they have a getter and a setter. <br> `public string Text { get; set; }` is an example property.
  - Properties can be of any supported type, but they must be public.
  - You can prevent properties from being serialized using the `[YamlIgnore]` attribute, this, however, will require the `YamlDotNet` package to be installed.
  - Non-public properties and anything else that isn't a property will be ignored.
- You need to define your `Config` class in the `Plugin` class using the `PluginConfig` attribute, by adding it to a field with your `Config` class as type. <br> This typicially looks like this: <br>
  ```csharp
  [PluginConfig]
  public Config Config;
  ```
- You can access any values inside the config via its instance defined the the `Plugin` class.
  - If you need to read values outside the `Plugin` class, consider making your `Plugin` a [Singleton](https://csharpindepth.com/Articles/Singleton).
### Event Handlers
- An event handler is a method that are called when a specific event is triggered.
- An event handler is marked with the `PluginEvent(EventType)` attribute.
- Any class containing an event handler must be registered using `EventManager.RegisterEvents<CLASSNAME>(this);` in the `PluginEntryPoint` method.
  - If the event handler is in the `Plugin` class, you can simply call `EventManager.RegisterEvents(this);`.
- Here is an example of an event handler which displays a welcome message:
  ```csharp
  [PluginEvent(ServerEventType.PlayerJoined)]
  public void OnPlayerJoin(Player player)
  {
      player.SendBroadcast("Welcome to the server!", 5);
  }
  ```