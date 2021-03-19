# CustomConfig

<p>Allows to load/save a custom configuration JSON file.</p>

<h4>Usage</h4>

<ul>
  <li>Add the library reference to your project.</li>
  <li>Implement the ICustomConfig interface to allow object initialization.</li>
  <li>Create an instance of the CustomConfig using your config class and load the configuration.<br>
    <pre>CustomConfig&lt;MyConfig&gt; config = new(Filename);<br>bool loaded = await config.LoadConfigAsync();</pre>    
  </li>
  <li>Saving can be done doing a simple call to SaveConfigAsync().<br>
    <pre>bool saved = await config.SaveConfigAsync();</pre>
  </li>
</ul>
