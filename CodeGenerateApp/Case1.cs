using System;
using System.Collections.Generic;
using System.Text;

namespace CodeGenerateApp
{
    /// <summary>
    /// Kod mantığı bize verilen karakter kümesi içinde random 8 haneli kod üretiliyor
    /// ardından her karakterin indexi benim belirlemiş olduğum unique anahtar ile kod yeniden oluşturuluyor aşağıda kod 
    /// içinde vermiş olduğum denklemler sayesinde 
    /// yani unique anahtar ve unique kod üretilmiş oluyor
    /// kodu çözmek içinde elimizde anahtarın olması gerekir tabiki.
    /// 
    /// anahtar = 438+5  
    /// 483 karani karakterlerinin ascii decimal toplamları  5 ise asıl unique liği saplayan yapı ben bunu bir veri tabanında tutulursa
    /// yada herhangi bir yerde diye index id si olsun diye ayarladım 5 burda değişkenlik gösteririr.
    /// 
    /// </summary>
    public static class Case1
    {
        public static void Generator()
        {
            var code = CodeCreator();
            var result =DecodeGenertor(code);
            Console.WriteLine($"{code}---->is True = {result}");

        }


        public static string CodeCreator()
        {
            List<char> characterArray = new List<char>()
        {
            'A', 'C', 'D', 'E', 'F', 'G', 'H', 'K', 'L', 'M', 'N', 'P', 'R', 'T', 'X', 'Y', 'Z', '2', '3', '4', '5', '7', '9'
        }; 

            int secretNumber = 438; // 438 sayısı KARANI kelimesinin ascıı toplamıdır. 5 ise belirlediğim key
            int dbindex = 5;


            StringBuilder kod = new StringBuilder();

            Random random = new Random();
            for (int i = 0; i < 8; i++)
            {
                int rastgeleIndex = random.Next(characterArray.Count);
                char rastgeleKarakter = characterArray[rastgeleIndex];
                kod.Append(rastgeleKarakter);
            }

            string sifreliKod = kod.ToString();
            string orijinalKod = "";

            foreach (char karakter in sifreliKod)
            {
                int index = characterArray.IndexOf(karakter);
                int yeniIndex = ((int)((secretNumber + dbindex) - index) % characterArray.Count);
                orijinalKod += characterArray[yeniIndex];
            }

            Console.WriteLine(orijinalKod);
            return orijinalKod;
        }

        /// <summary>
        /// daha önce vermiş olduğumuz 8 haneli kodun bize ait olup olmadığına bakar
        /// </summary>
        /// <param name="code">kod</param>
        /// <returns></returns>
        public static bool DecodeGenertor(string code)
        {
            if (code.Length != 8)
            {
                return false;
            }
            bool result = false;
            List<char> characterArray = new List<char>()
{
    'A', 'C', 'D', 'E', 'F', 'G', 'H', 'K', 'L', 'M', 'N', 'P', 'R', 'T', 'X', 'Y', 'Z', '2', '3', '4', '5', '7', '9'
}; 

            string gizliKod = code; 

            long secretNumber = 438 + 5;//438 sayısı KARANI kelimesinin ascıı toplamıdır. 5 ise belirlediğim key

            foreach (char character in gizliKod)
            {
                int index = characterArray.IndexOf(character);
                var oldIndex = ((int)((secretNumber) - index) % characterArray.Count);// denklem kodu
                if (index == -1)
                {
                    result = false;
                    return result;
                }
                else
                {
                    var x = SolveEquation(oldIndex, index, 438);
                    if (x == 5)
                    {
                        result = true;
                    }
                    else
                    {
                        return result = false;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 22 = ((438 + X) - 2) % 23 örnek denklemi çözer
        /// </summary>
        /// <param name="oldIndex">eski index</param>
        /// <param name="newIndex">yeni index</param>
        /// <param name="constant">karani kelimesinin ascii karakter decimal toplamı</param>
        /// <returns></returns>
        public static int SolveEquation(int oldIndex, int newIndex, int constant)
        {
            int x = 0;

            for (int i = 0; i < 23; i++)
            {
                if (((constant + i) - newIndex) % 23 == oldIndex)
                {
                    x = i;
                    break;
                }
            }

            return x;
        }

    }
}
