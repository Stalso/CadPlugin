This is simple AutoCAD .NET plugin with injectable command classes.
You can use it as starting template for plugins.
To make such plugin it's necessary to block AutoCAD to load command methods using [assembly: CommandClass(typeof(<PluginMainClass>))] attribute with your IExtensionApplication class.
Then you should call this.PrepareServices(); in your IExtensionApplication.Initialize().
Also you should have Startup.cs class where you can configure your plugin services.

