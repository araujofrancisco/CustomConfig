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

        public CustomConfig(string Filename)
        {
            this.Filename = Filename;
        }

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
