using System.Collections.Generic;

namespace CustomConfig
{
    public class FileDetails
    {
        public string Filename { get; set; }
        public string ApiEntryPoint { get; set; }
    }

    public class MyConfig : ICustomConfig
    {
        public string Account { get; set; }
        public string Password { get; set; }
        public string BaseAddress { get; set; }
        public List<FileDetails> Data { get; set; }

        public MyConfig()
        {

        }

        public void Initialize()
        {
            Account = "account@domain.com";
            Password = "mypassword";
            BaseAddress = "https://localhost:44371";
            Data = new() { new() { Filename = "datafile.dat", ApiEntryPoint = "api/customroute/uploadfile" } };
        }
    }
}
