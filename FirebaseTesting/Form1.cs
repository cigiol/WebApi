using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirebaseTesting
{
    public partial class Form1 : Form
    {
        #region
        string authentication = "uKLB1Fcqv3Gog8KBraS1OqL3Tw92a2nYfDfdFqkx";
        string baseurl = "https://zurna-dbc48.firebaseio.com/";
        FireRepo<Country> repo;
        #endregion
        public Form1()
        {
            InitializeComponent();
            repo = new FireRepo<Country>(authentication, baseurl, $"{typeof(Country).Name.ToString()}/");
        }
        
        private async void button1_Click(object sender, EventArgs e)
        {
            bool result = await repo.ConnectionTest();
            MessageBox.Show(result.ToString());
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            Guid registerGuid = Guid.NewGuid();
            Country country = new Country() {
                id = registerGuid,
                Name = "Elazığ",
                Population = 580872
            };
            await repo.Add(country, registerGuid);

        }

        private async void button4_Click(object sender, EventArgs e)
        {
            List<Country> result
                = await repo.GetList();
            //Another using method for array
            Country[] resultArray
                = await repo.GetListSeries();
            //Another using method for array constrained :EG total 1 country list
            Country[] resultArrayLimit
                = await repo.GetListSeries(1);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            //For read function using methot >Find(Guid id)
            Country finded = await repo.Find(Guid.Parse("12208d50-1043-45dc-8cd6-983d12f5b272"));
            Console.WriteLine(finded.Name);
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            //For update hash/guid ='d601fa4b-fb16-4f86-b4e0-395c5695a5f5'
            Country targetData= await repo.Find(Guid.Parse("12208d50-1043-45dc-8cd6-983d12f5b272"));
            targetData.Name = ".Net City";
            targetData.Population = 1359876;
            await repo.Update(targetData.id, targetData);
        }
    }
    public class Country
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public double Population { get; set; }
    }
   
}
