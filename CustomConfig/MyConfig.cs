using System.Collections.Generic;

namespace CustomConfig
{  
    public class MyConfig : ICustomConfig
    {
        public string Account { get; set; } = "account@domain.com";
        public string Password { get; set; } = "mypassword";
        public string BaseAddress { get; set; } = "https://localhost:44371";
        public List<FileDetails> Data { get; set; } = new() { new() { Filename = "datafile.dat", ApiEntryPoint = "api/customroute/uploadfile" } };

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

    public class FileDetails
    {
        public string Filename { get; set; }
        public string ApiEntryPoint { get; set; }
    }
}
