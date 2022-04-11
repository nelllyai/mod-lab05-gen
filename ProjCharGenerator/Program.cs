using System;
using System.Collections.Generic;
using System.IO;

namespace generator
{
    class CharGenerator 
    {
        private string syms = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя"; 
        private char[] data;
        private int size;
        private Random random = new Random();
        public CharGenerator() 
        {
           size = syms.Length;
           data = syms.ToCharArray(); 
        }
        public char getSym() 
        {
           return data[random.Next(0, size)]; 
        }
    }

    class GramsGenerator
    {
        private string[] words = new string[] { "и", "в", "не", "на", "с", "что", "я", "а", "он", "как",
                                                "к", "по", "но", "его", "это", "из", "все", "у", "за", "от",
                                                "то", "о", "же", "так", "для", "было", "она", "только", "мы", "бы",
                                                "мне", "был", "ее", "или", "еще", "меня", "их", "они", "до", "когда",
                                                "уже", "ты", "если", "да", "вы", "вот", "при", "ни", "ему", "чтобы",
                                                "нет", "есть", "даже", "может", "быть", "во", "время", "очень", "были", "была",
                                                "сказал", "ли", "под", "со", "себя", "нас", "где", "него", "чем", "того",
                                                "без", "будет", "этого", "теперь", "после", "там", "можно", "этом", "раз", "себе",
                                                "тем", "этот", "ну", "том", "потом", "более", "них", "которые", "всех", "человек",
                                                "ничего", "надо", "тут", "тогда", "здесь", "потому", "один", "кто", "через", "который" };
        private int size;
        private Random random = new Random();
        int[] weights = new int[] { 7416716, 5842670, 3385161, 2936096, 2228350, 2210373, 1592127, 1541398, 1377314, 1300577,
                                    1132463, 1071698, 1048321, 983462, 957828, 836230, 817619, 798746, 754712, 747239,
                                    695763, 685187, 665139, 663853, 600197, 592525, 553635, 516518, 501250, 485709,
                                    449883, 442198, 438349, 434375, 432318, 422671, 415977, 412867, 400385, 390040,
                                    385992, 348216, 347484, 338405, 338350, 310419, 305370, 305025, 302129, 286114,
                                    269615, 267554, 264014, 263199, 262913, 259603, 255317, 252939, 249393, 246499,
                                    233062, 231733, 228843, 222715, 220734, 218046, 216726, 216511, 213262, 209534,
                                    205150, 204581, 202868, 201329, 195907, 192639, 189774, 189405, 184146, 180956,
                                    177179, 176597, 175961, 174807, 173458, 170327, 168703, 167945, 167764, 166587,
                                    163311, 162849, 160363, 159227, 158961, 157741, 157644, 156987, 153712, 151251};
        int[] np;
        int sum = 0;
        public GramsGenerator()
        {
            size = words.Length;
            if (size != weights.Length)
            {
                Console.WriteLine("Error!");
                Environment.Exit(1);
            }

            for (int i = 0; i < size; i++)
                sum += weights[i];

            np = new int[size];
            int s2 = 0;

            for (int i = 0; i < size; i++)
            {
                s2 += weights[i];
                np[i] = s2;
            }
        }

        public string getWord()
        {
            int m = random.Next(0, sum);
            int j;

            for (j = 0; j < size; j++)
            {
                if (m < np[j])
                    break;
            }
            return words[j];
        }
    }

    class TwoGramsGenerator
    {
        private string[] pairs = new string[] { "и не", "и в", "потому что", "я не", "у меня", "может быть", "то что", "что он", "не было", "в том",
                                                "у нас", "в этом", "у него", "что в", "не только", "том что", "что я", "и на", "ничего не", "так и",
                                                "и с", "он не", "и я", "о том", "и все", "но и", "с ним", "а в", "так как", "что это",
                                                "как бы", "все это", "как и", "да и", "вместе с", "не в", "то есть", "и что", "и он", "никогда не",
                                                "к нему", "не может", "если бы", "а я", "так что", "он был", "а не", "об этом", "и даже", "что не",
                                                "это не", "еще не", "но не", "и как", "не мог", "из них", "не знаю", "на него", "в нем", "а потом",
                                                "что же", "в то", "при этом", "уже не", "в его", "это было", "во время", "что она", "того что", "как будто",
                                                "то же", "но в", "как в", "ко мне", "так же", "а также", "и по", "что у", "у них", "и т",
                                                "и так", "и вот", "один из", "никто не", "в москве", "в его", "у вас", "к тому", "не могу", "в конце",
                                                "что вы", "но я", "что они", "я и", "только в", "его в", "таким образом", "что и", "в россии", "несмотря на" };
        private int size;
        private Random random = new Random();
        int[] weights = new int[] { 201352, 193983, 117401, 113767, 97102, 96065, 95251, 92743, 92729, 89842,
                                    86446, 84820, 82963, 80398, 80252, 77858, 75642, 74347, 71816, 71614,
                                    71079, 68787, 68653, 67202, 66971, 66247, 65937, 60045, 58376, 57962,
                                    56860, 52951, 50613, 50243, 49521, 49285, 49262, 49137, 48879, 48344,
                                    48225, 48027, 47665, 47558, 47525, 47234, 46620, 45100, 44977, 44953,
                                    44867, 44753, 44428, 42588, 42307, 41386, 40338, 40336, 40316, 40259,
                                    40197, 39971, 39931, 39037, 38517, 38081, 37952, 37436, 37244, 37176,
                                    37103, 36943, 36837, 36495, 36435, 36133, 35266, 35149, 34548, 33965,
                                    33734, 33586, 33342, 33320, 33159, 33095, 33010, 32814, 32714, 32590,
                                    32428, 31972, 31330, 31004, 30819, 30782, 30278, 30274, 29973, 29741};
        int[] np;
        int sum = 0;
        public TwoGramsGenerator()
        {
            size = pairs.Length;
            if (size != weights.Length)
            {
                Console.WriteLine("Error!");
                Environment.Exit(1);
            }

            for (int i = 0; i < size; i++)
                sum += weights[i];

            np = new int[size];
            int s2 = 0;

            for (int i = 0; i < size; i++)
            {
                s2 += weights[i];
                np[i] = s2;
            }
        }

        public string getPair()
        {
            int m = random.Next(0, sum);
            int j;

            for (j = 0; j < size; j++)
            {
                if (m < np[j])
                    break;
            }
            return pairs[j];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //CharGenerator gen = new CharGenerator();
            //SortedDictionary<char, int> stat = new SortedDictionary<char, int>();
            //for(int i = 0; i < 1000; i++) 
            //{
            //   char ch = gen.getSym(); 
            //   if (stat.ContainsKey(ch))
            //      stat[ch]++;
            //   else
            //      stat.Add(ch, 1); Console.Write(ch);
            //}
            //Console.Write('\n');
            //foreach (KeyValuePair<char, int> entry in stat) 
            //{
            //     Console.WriteLine("{0} - {1}",entry.Key,entry.Value/1000.0); 
            //}
            
            GramsGenerator gen2 = new GramsGenerator();
            string str2 = String.Empty;
            for (int i = 0; i < 1000; i++)
                str2 += (gen2.getWord() + " ");
            File.WriteAllText("UserFiles/test2.txt", str2);

            TwoGramsGenerator gen3 = new TwoGramsGenerator();
            string str3 = String.Empty;
            for (int i = 0; i < 1000; i++)
                str2 += (gen3.getPair() + " ");
            File.WriteAllText("UserFiles/test3.txt", str2);
        }
    }
}

