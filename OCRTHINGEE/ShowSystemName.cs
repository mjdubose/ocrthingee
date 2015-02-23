using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OCRTHINGEE
{
    public partial class ShowSystemName : Form
    {
        public ShowSystemName()
        {
            InitializeComponent();

        }

        /// <summary>
        ///     Calculate percentage similarity of two strings
        ///     <param name="source">Source String to Compare with</param>
        ///     <param name="target">Targeted String to Compare</param>
        ///     <returns>Return Similarity between two strings from 0 to 1.0</returns>
        /// </summary>
        private static double CalculateSimilarity(string source, string target)
        {
            if ((source == null) || (target == null)) return 0.0;
            if ((source.Length == 0) || (target.Length == 0)) return 0.0;
            if (source == target) return 1.0;

            var stepsToSame = ComputeLevenshteinDistance(source, target);
            return (1.0 - (stepsToSame/(double) Math.Max(source.Length, target.Length)));
        }

        /// <summary>
        ///     Returns the number of steps required to transform the source string
        ///     into the target string.
        /// </summary>
        private static int ComputeLevenshteinDistance(string source, string target)
        {
            if ((source == null) || (target == null)) return 0;
            if ((source.Length == 0) || (target.Length == 0)) return 0;
            if (source == target) return source.Length;

            var sourceWordCount = source.Length;
            var targetWordCount = target.Length;

            // Step 1
            if (sourceWordCount == 0)
                return targetWordCount;

            if (targetWordCount == 0)
                return sourceWordCount;

            var distance = new int[sourceWordCount + 1, targetWordCount + 1];

            // Step 2
            for (var i = 0; i <= sourceWordCount; distance[i, 0] = i++)
            {
            }
            for (var j = 0; j <= targetWordCount; distance[0, j] = j++)
            {
            }
            for (var i = 1; i <= sourceWordCount; i++)
            {
                for (var j = 1; j <= targetWordCount; j++)
                {
                    // Step 3
                    var cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

                    // Step 4
                    distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1),
                        distance[i - 1, j - 1] + cost);
                }
            }

            return distance[sourceWordCount, targetWordCount];
        }

        public string ReturnMostSimilarWord(string ocrword, List<string> items)
        {
            var thisword = new Closeness {Closeid = -1.0, Item = ""};

            foreach (var word in items)
            {
                var tmep = CalculateSimilarity(ocrword.Trim(), word.ToUpper());
                if (Math.Abs(tmep - 1.0) < .0001)
                {
                    return word;
                }

                if (!(thisword.Closeid < tmep)) continue;
                thisword.Closeid = tmep;
                thisword.Item = word;
            }

            return thisword.Item;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = @"Enter a valid Galaxy here!";
                return;
            }


            Form1.Systemname = textBox2.Text;
            Form1.Stationname = textBox1.Text;
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ShowSystemName_Load(object sender, EventArgs e)
        {
            var systemcollection = new AutoCompleteStringCollection();
            var stationcollection = new AutoCompleteStringCollection();


            using (var elite = new elite_testingEntities())
            {
                var systemlist = elite.Systems.ToList();
                var stationlist = elite.Stations.ToList();
                foreach (var x in systemlist)
                {
                    systemcollection.Add(x.name);
                }

                foreach (var x in stationlist)
                {
                    stationcollection.Add(x.name);
                }
            }

            textBox2.AutoCompleteCustomSource = systemcollection;
            textBox1.AutoCompleteCustomSource = stationcollection;

            textBox2.Text = Form1.Systemname;
            textBox1.Text = Form1.Stationname;
        }
    }
}