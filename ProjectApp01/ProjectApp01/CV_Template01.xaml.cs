using PdfSharp.Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace ProjectApp01
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CV_Template01 : ContentPage
	{
		public CV_Template01 (string Name, string Age, string Occupation, string Nationality, string Number, string Email, List<String> Experience, List<String> Skill, List<String> Education)
        {
            InitializeComponent();

            LabelName.Text = Name;
            LabelAge.Text = Age;
            LabelOccupation.Text = Occupation;
            LabelNationality.Text = Nationality;
            LabelNumber.Text = Number;
            LabelEmail.Text = Email;

            foreach (var i in Experience)
            {
                var label = new Label { Text = i };
                StackExp.Children.Add(label);
            }

            foreach (var i in Skill)
            {
                var label = new Label { Text = i };
                StackSkill.Children.Add(label);
            }

            foreach (var i in Education)
            {
                var label = new Label { Text = i };
                StackEducation.Children.Add(label);
            }
        }
        private async void Button_Clicked_GeneradePDF(object sender, EventArgs e)
        {
            var pdf = PDFManager.GeneratePDFFromView(CV_Content);
            string filename = "MyCV.pdf";
            string path = System.IO.Path.Combine(FileSystem.CacheDirectory, filename);
            pdf.Save(path);
            var message = new EmailMessage
            {
                Subject = "",
                Body = "",
            };
            message.Attachments.Add(new EmailAttachment(path));
            await Email.ComposeAsync(message);
        }
    }
}