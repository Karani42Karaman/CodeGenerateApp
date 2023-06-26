using CodeGenerateApp.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;


namespace CodeGenerateApp
{
    public static class Case2
    {
        /**
        * Case 2 gereği 
        * bana verilen fişin ocr ile json dosyasına dönüştürülmüş hali bana verilmiştir 
        * bu verilen dosyadaki verileri ise okumam istenmiştir yani json dosyasını okuyup parse etmem itendiğini anladım.
        * */
        public static void Parser()
        {
            var Content = File.ReadAllText(@"C:\Users\karam\Downloads\response.json");
            var myDeserializedClass = JsonConvert.DeserializeObject<List<Receipt>>(Content);// Json dosyasının inceleyerek model
            //haritasını çıkardım  ardından  Newtonsoft kütüphanesinin hazır mehodunu kullanarak  Receipt modeline mapledim.,
            //istediğim her yered kullanabilirm artık. istediğim her yere de kayıt edebilirm bana spesifik olarak bir kayıt etme yeri
            // verilmediği için kodu bu aşamada bıraktım .
        }



    }
}
