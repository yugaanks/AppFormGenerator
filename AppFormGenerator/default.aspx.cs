using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppFormGenerator
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                clearFields();
            }
        }
        
        protected void Submit_button_Click(object sender, EventArgs e)
        {
            
            if(firstName == string.Empty || lastName == string.Empty)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Please enter your First and Last name')", true);
                clearFields();
                return;
            }
            generateText();
        }

        protected string SendEmail_Click()
        {
            var to = "mailto:secy-moef@nic.in";
            var cc = "?cc=menong@cag.gov.in";
            var subject = "&subject=Withdraw the draft EIA notification, " +
                "2020 [F.N.2-50/2018/IA.III] and defer the process of public comments in the light of the " +
                "Covid-2019 pandemic";
            var body = "&body=" + StripHTML(template);
            var url = to + cc + subject + body;
            return url;
        }

        protected void Form_Selection_Change(object sender, EventArgs e)
        {
            if(forms.SelectedValue == "EIANotification")
            {
                formPanel.Visible = true;
            }
            else
            {
                formPanel.Visible = false;
            }
        }

        protected string readFile(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourcePath = fileName;
            resourcePath = assembly.GetManifestResourceNames()
                    .Single(str => str.EndsWith(fileName));
            
            using (Stream stream = assembly.GetManifestResourceStream(resourcePath))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
        
        protected void generateText()
        {
            string text = readFile("EIANotification.txt");
            template = string.Format(text, firstName, lastName);
            if (template != string.Empty)
            {
                SendEmail.Enabled = true;
                SendEmail.OnClientClick = "location.href = '" + SendEmail_Click() + "'; return false;" ;
            }
        }

        protected void clearFields()
        {
            firstName = lastName = template = string.Empty;
            SendEmail.Enabled = false;
        }

        public static string StripHTML(string input)
        {
            return HttpUtility.HtmlDecode(Regex.Replace(input, "<.*?>", String.Empty)).Replace("\r\n\r\n", " %0D ");
        }

        string firstName
        {
            get { return CandidateFirstName.Text; }
            set { CandidateFirstName.Text = value; }
        }
        string lastName
        {
            get { return CandidateLastName.Text; }
            set { CandidateLastName.Text = value; }
        }
        string template
        {
            get { return Template.Text; }
            set { Template.Text = value; }
        }
    }
}