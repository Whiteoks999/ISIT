using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Обфускатор
{
    internal class Obfuskator
    {
        public static Obfuskator obfuskator = new Obfuskator();
        private string sourceCode;
        private string obfuscatedСode;
        private Obfuskator() { }
        //Какие-то изменения

        public static Obfuskator GetObfuskator() { return obfuskator; }
        //Какие-то изменения
        //Второе изменение
        //Третье изменение
        //Четвёртое изменение
        public void addSourceCode(string sourceCode) { 
        this.sourceCode = sourceCode;
        }

        public string obfuscate() {
            string st = sourceCode.Replace("\r\n", " "); //удаление переноса строк
            string[] wordsCode = st.Split(' '); 
            string oldClassName = "";
            string newClassName = randomNameClass();
            bool flag = false;

            obfuscatedСode += "/*" + randomComment() + "*/"; //добавление избыточных комментариев

            foreach (string word in wordsCode) { //поиск имени класса
                if (flag) oldClassName = word;
                flag = false;
                if (word.Equals("class")) flag=true;
            }
            
            foreach (string word in wordsCode) //замена старого имени класса на новое
            {
                if (word.Equals(oldClassName)) {
                    obfuscatedСode += " "+newClassName;
                }
                else if(word.Equals(oldClassName+"();")) obfuscatedСode += " " + newClassName+"();";

                else
                obfuscatedСode += " "+word;
            }

            obfuscatedСode += "/*" + randomComment() + "*/"; //добавление избыточных комментариев

            return obfuscatedСode;
        }

        private string randomNameClass() {
            char[] letters = "ABCDEuGeHIrJfvKzLbfMbNmkOPQRSTUVWXYZ".ToCharArray();

            Random rand = new Random();
                string word = "";
                for (int i = 1; i <= 30; i++)
                {
                    int letter_num = rand.Next(0, letters.Length - 1);
                    word += letters[letter_num];
                }  
           return word;
        }

        private string randomComment()
        {
            char[] letters = "qwertyuiopasdfghjklzxcvnm".ToCharArray();
            Random rand = new Random();
            string word = "";
            string comment = "";
            for (int i = 1; i <= 30; i++) {
                word = "";
                for (int j = 1; j <= 5; j++)
            {
                int letter_num = rand.Next(0, letters.Length - 1);
                word += letters[letter_num];
            }
                comment += " " + word;
            }
            return comment;
        }


    }
}
