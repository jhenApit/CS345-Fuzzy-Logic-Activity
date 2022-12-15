using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DotFuzzy;
namespace AliacFuzzyLogic
{
    public partial class Form1 : Form
    {
        FuzzyEngine fe;
        MembershipFunctionCollection dirtType, dirtQuality, washTime;
        LinguisticVariable myDirtType, myDirtQuality, myWashTime;
        FuzzyRuleCollection myRules;


        public Form1()
        {
            InitializeComponent();
        }

    
        public void setMembers()
        {

            dirtType = new MembershipFunctionCollection
            {
                new MembershipFunction("NONGREASY", 0, 0, 33.3, 50),
                new MembershipFunction("MEDIUM", 33.3, 50, 50, 66.6),
                new MembershipFunction("GREASY", 50, 66.6, 100, 100)
            };
            myDirtType = new LinguisticVariable("TYPE", dirtType);


            dirtQuality = new MembershipFunctionCollection
            {
                new MembershipFunction("SMALL", 0, 0, 33.3, 50),
                new MembershipFunction("MEDIUM", 33.3, 50, 50, 66.6),
                new MembershipFunction("LARGE", 50, 66.6, 100, 100)
            };
            myDirtQuality = new LinguisticVariable("QUALITY", dirtQuality);

            washTime = new MembershipFunctionCollection
            {
                new MembershipFunction("VS", 0.0,0.0,2.0,4.0),
                new MembershipFunction("SHORT", 2.0, 4.0, 4.0, 6.0),
                new MembershipFunction("MEDIUM", 4.0, 6.0, 6.0, 8.0),
                new MembershipFunction("LONG", 6.0, 8.0, 8.0, 10.0),
                new MembershipFunction("VL", 8.0, 10.0, 10.0, 10.0)
            };
            myWashTime = new LinguisticVariable("WASHTIME", washTime);
        }

        public void setRules()
        {
            myRules = new FuzzyRuleCollection
            {
                new FuzzyRule("IF (QUALITY IS SMALL) AND (TYPE IS GREASY) THEN WASHTIME IS LONG"),
                new FuzzyRule("IF (QUALITY IS MEDIUM) AND (TYPE IS GREASY) THEN WASHTIME IS LONG"),
                new FuzzyRule("IF (QUALITY IS LARGE) AND (TYPE IS GREASY) THEN WASHTIME IS VL"),
                new FuzzyRule("IF (QUALITY IS SMALL) AND (TYPE IS MEDIUM) THEN WASHTIME IS MEDIUM"),
                new FuzzyRule("IF (QUALITY IS MEDIUM) AND (TYPE IS MEDIUM) THEN WASHTIME IS MEDIUM"),
                new FuzzyRule("IF (QUALITY IS LARGE) AND (TYPE IS MEDIUM) THEN WASHTIME IS MEDIUM"),
                new FuzzyRule("IF (QUALITY IS SMALL) AND (TYPE IS NONGREASY) THEN WASHTIME IS VS"),
                new FuzzyRule("IF (QUALITY IS MEDIUM) AND (TYPE IS NONGREASY) THEN WASHTIME IS SHORT"),
                new FuzzyRule("IF (QUALITY IS LARGE) AND (TYPE IS NONGREASY) THEN WASHTIME IS SHORT"),
            };
        }

        public void setFuzzyEngine()
        {
            fe = new FuzzyEngine();
            fe.LinguisticVariableCollection.Add(myDirtType);
            fe.LinguisticVariableCollection.Add(myDirtQuality);
            fe.LinguisticVariableCollection.Add(myWashTime);
            fe.FuzzyRuleCollection = myRules;
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setMembers();
            setRules();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myDirtType.InputValue=(Convert.ToDouble(textBox1.Text));
            myDirtType.Fuzzify("MEDIUM");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            myDirtQuality.InputValue = (Convert.ToDouble(textBox2.Text));
            myDirtQuality.Fuzzify("MEDIUM");       
        }

        public void fuziffyvalues()
        {
            myDirtType.InputValue = (Convert.ToDouble(textBox1.Text));
            myDirtType.Fuzzify("NONGREASY");
            myDirtQuality.InputValue = (Convert.ToDouble(textBox2.Text));
            myDirtQuality.Fuzzify("SMALL");     
        }
        public void defuzzy()
        {
            setFuzzyEngine();
            fe.Consequent = "WASHTIME";
            textBox3.Text = "" + fe.Defuzzify();
        }

        public void computenewtype()
        {
            double oldType = Convert.ToDouble(textBox1.Text);
            double oldWashTime = Convert.ToDouble(textBox3.Text);
            double oldQuality = Convert.ToDouble(textBox2.Text);
            double newType = ((1 - 0.1) * (oldType)) + (oldWashTime - (0.1 * oldQuality));
            textBox1.Text = "" + newType;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            setFuzzyEngine();
            fe.Consequent = "WASHTIME";
            textBox3.Text = "" + fe.Defuzzify();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            computenewtype();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            setMembers();
            setRules();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fuziffyvalues();
            defuzzy();
            computenewtype();
        }
    }
}
