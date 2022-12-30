using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjectApp01
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Submit_Clicked(object sender, EventArgs e)
        {
            List<String> Exp_List = new List<String>();
            var expList = Layout_experience.Children.ToList();
            foreach(var i in expList)
            {
                var myEntry = i as Entry;
                Exp_List.Add(myEntry.Text);
            }
            List<String> Skills_List = new List<String>();
            var skillsList = Layout_experience.Children.ToList();
            foreach (var i in skillsList)
            {
                var myEntry = i as Entry;
                Skills_List.Add(myEntry.Text);
            }
            List<String> Education_List = new List<String>();
            var educaList = Layout_experience.Children.ToList();
            foreach (var i in educaList)
            {
                var myEntry = i as Entry;
                Education_List.Add(myEntry.Text);
            }
            string name = EntryName.Text;
            string age= EntryAge.Text;
            string occupation = EntryOccupation.Text;
            string nationality= EntryNationality.Text;
            string number = EntryNumber.Text;
            string email=EntryEmail.Text;
            Application.Current.MainPage.Navigation.PushModalAsync(new CV_Template01(name, age, occupation, nationality, number, email, Exp_List, Skills_List, Education_List), true);
        }
        private void Button_clicked_experience(object sender, EventArgs e)
        {
            var entry = new Entry() { Placeholder = "Enter your experience" };
            Layout_experience.Children.Add(entry);
        }
        private void Button_clicked_skill(object sender, EventArgs e)
        {
            var entry = new Entry() { Placeholder = "Enter your skill" };
            Layout_skill.Children.Add(entry);
        }
        private void Button_clicked_education(object sender, EventArgs e)
        {
            var entry = new Entry() { Placeholder = "Enter your education" };
            Layout_education.Children.Add(entry);
        }
    }
}
