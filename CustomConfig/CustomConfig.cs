using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace CustomConfig
{
    public class CustomConfig<TConfig>
        where TConfig : ICustomConfig, new()
    {
        private string Filename { get; set; }
        public TConfig Settings { get; set; }

        /// <summary>
        /// Constructor receives the configuration file name.
        /// </summary>
        /// <param name="Filename">Name of the file for configuration.</param>
        public CustomConfig(string Filename)
        {
            this.Filename = Filename;
        }

        /// <summary>
        /// Loads the configuration file asynchronously. A new configuration file is created if it does not exists.
        /// </summary>
        /// <returns>Returns true if it was able to load a configuration file.</returns>
        public async Task<bool> LoadConfigAsync()
        {
            bool retVal = false;

            // check if there is a config file
            if (!File.Exists(this.Filename))
            {
                // if file is not found we try to create and initialize it
                Settings = new TConfig();
                Settings.Initialize();
                retVal = await SaveConfigAsync();
            }
            else
            {
                try
                {
                    // proceed to load settings
                    using FileStream openFile = File.OpenRead(this.Filename);
                    Settings = await JsonSerializer.DeserializeAsync<TConfig>(openFile);
                    retVal = true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Failure during configuration loading.", ex);
                }
            }
            return retVal;
        }

        /// <summary>
        /// Saves configuration to a file asynchronously. The file will be created if it does not exists.
        /// </summary>
        /// <returns>Returns true if it was able to save the configuration.</returns>
        public async Task<bool> SaveConfigAsync()
        {
            bool retVal = false;
            try
            {
                using FileStream newFile = File.Create(this.Filename);
                await JsonSerializer.SerializeAsync(newFile, this.Settings);
                retVal = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Failure during configuration saving.", ex);
            }
            return retVal;
        }
    }
}
