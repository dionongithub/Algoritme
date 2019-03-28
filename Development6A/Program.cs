using System;
using System.Collections;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionMethods;
using Development6A.Resources;
using Development6A.Resources.BinaryTree;
using Development6A.Resources.Graph;

namespace Development6A
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] TestArray = new[] {"Kaas", "Hond", "Miami", "Piet"};
            int[] TestintArrayOrderd = new[] {1, 3, 4, 5, 7, 12, 14, 16};
            int[] TestintArrayUnOrderd = new int[] {8, 1, 6, 3, 7, 18, 13, 23, 17, 15, 5};
            int[] TestInsertionSort = TestintArrayUnOrderd.InsertionSort();
            /*foreach (var item in TestInsertionSort)
            {
                Console.WriteLine(item);
            }*/

            /*BinaryTree<int> boom = new BinaryTree<int>();
            boom.Add(10);
            boom.Add(30);
            boom.Add(5);
            boom.Add(6);
            boom.Add(4);
            boom.Add(2);
            boom.Add(3);

            boom.Remove(30);
            boom.Remove(10);*/

            /*hashtable<int, string> hashtable = new hashtable<int, string>();
            hashtable.add(900, "Kaas");
            hashtable.add(300, "mount");
            hashtable.add(548, "jfksdl");
            hashtable.add(17, "Dion");
            hashtable.add(924, "ibny");
            hashtable.add(305, "7ddv8");
            hashtable.add(1235, "jkiji");
            hashtable.add(354, "month");
            hashtable.add(7531, "cheese");
            hashtable.add(235, "8687bn");
            hashtable.add(2014, "Kaaujuis");
            hashtable.add(932, "1234");
            hashtable.add(231856, "sinterklaas");
            hashtable.add(1, "3");
            hashtable.add(3654, "mount");
            hashtable.add(3025, "sint");
            hashtable.add(78, "6");
            hashtable.add(360, "8");
            hashtable.add(15, "Leer");
            hashtable.add(28, "Mond");

            Option<KeyValuePair<int, string>> print = hashtable.search(900);

            Console.WriteLine(print.data.value);*/

            /*LinkedList<int> lijst = new LinkedList<int>();
            lijst.InsertOnStart(1);
            lijst.InsertOnStart(9);
            lijst.InsertOnStart(5);
            lijst.InsertOnAfter(2, 9);

            node<int> TMPlijst = lijst.StartingNode;

            while(TMPlijst != null)
            {
                Console.WriteLine(TMPlijst.Data);
                TMPlijst = TMPlijst.Next;
            }*/

            double[,] graph = new double[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };

            FloydWarshall t = new FloydWarshall(graph);
            var result = t.FloydWarshallAlgorithme();

            foreach (var item in result.Item1)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------");

            foreach (var item in result.Item2)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();

        }
    }
}
