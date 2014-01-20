using System;
using System.Web;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace TextMining
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public static string ExtractText(string html)
        {
            if (html == null)
            {
                throw new ArgumentNullException("html");
            }

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

            doc.LoadHtml(html);

            var chunks = new List<string>();

            foreach (var item in doc.DocumentNode.DescendantsAndSelf())
            {
                if (item.NodeType == HtmlNodeType.Text)
                {
                    if (item.InnerText.Trim() != "")
                    {
                        chunks.Add(item.InnerText.Trim());
                    }
                }
            }
            return String.Join(" ", chunks);
        }

        public static DataTable HttpGet()
        {
            try
            {
                bool in_item = false;
                DataTable dt = new DataTable();

                string[] arr = { "", "", "" };
                
                DataRow dr;
                dt.Columns.Add("id");
                dt.Columns.Add("title");
                dt.Columns.Add("desc");
                
                WebClient client = new WebClient();

                // Add a user agent header in case the  
                // requested URI contains a query.

                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

                using (Stream data = client.OpenRead("http://news.google.com/?output=rss"))
                {
                    using (StreamReader stream = new StreamReader(data))
                    {
                        XmlTextReader reader = null;
                        reader = new XmlTextReader(stream);
                        while (reader.Read()) 
                        {
                            switch (reader.NodeType)
                            {
                                case XmlNodeType.Element: // The node is an Element.
                                    if (reader.Name == "item")
                                    {
                                        in_item = true;
                                    }
                                    if ((reader.Name == "title") && (in_item))
                                    {
                                        arr[1] = reader.ReadString();                         
                                    }
                                    if ((reader.Name == "guid") && (in_item))
                                    {
                                        arr[0] = reader.ReadString();
                                        
                                    }
                                    if ((reader.Name == "description") && (in_item))
                                    {
                                        arr[2] = reader.ReadString();

                                        dr = dt.NewRow();
                                        dr["id"] = arr[0];
                                        dr["title"] = arr[1];
                                        // prepare the text
                                        arr[2] = ExtractText(arr[2]);
                                        arr[2] = OmitObsolete(arr[2]);
                                        
                                        dr["desc"] = arr[2];
                                        dt.Rows.Add(dr);
                                    }

                                    break;
                                case XmlNodeType.Text: //Display the text in each element.
                                    // MessageBox.Show(reader.Value);
                                    break;
                                case XmlNodeType.EndElement: //Display end of element.
                                    // MessageBox.Show("</" + reader.Name);
                                    if (reader.Name == "item")
                                    {
                                        in_item = false;
                                    }
                                    break;
                            }
                            
                        }


                        // string s = reader.ReadToEnd();
                         // ds.ReadXml(reader);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private static string OmitObsolete(string str)
        {
            str = str.Replace("&nbsp;", " ");
            str = str.Replace("&quot", " ");
            str = str.Replace("&raquo;", " ");
            str = str.Replace("...", " ");
            str = str.Replace("&#39;", "");
            return str;
        }

        private static DataTable StringSplit(string text)
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

            string[] words = text.Split(delimiterChars);
            DataTable dt = new DataTable();
            dt.Columns.Add();
            DataRow dr;
                        
            foreach (string s in words)
            {
                // System.Console.WriteLine(s);
                dr = dt.NewRow();
                dr[0] = s;
                dt.Rows.Add(dr);
            }

            return dt;
        }


        private void getDataFromGoogleRSSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str;
            try
            {
                DataTable dt = new DataTable();
                dt = HttpGet();

                /*

                for (int x = 0; x < dt.Rows.Count; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        MessageBox.Show(dt.Rows[x][y].ToString());
                        if (y == 2)
                        {
                            str = ExtractText(dt.Rows[x][y].ToString());
                            str = OmitObsolete(str);
                            MessageBox.Show(str);
                            StringSplit(str);
                        }
                    }

                }
                 
               */
                
                
                                 
                // Lets play with DataGridView
                dataTextData.DataSource = dt;
                dataTextData.Columns[0].Width = 5;
                dataTextData.Columns[1].Width = 500;
                dataTextData.Columns[2].Width = 100;
                dataTextData.Refresh();
                
                /*

                DataTable dt_terms = new DataTable();
                DataRow dr_terms;
                DataTable temp = new DataTable();
                dt_terms.Columns.Add("id");
                dt_terms.Columns.Add("term");
                
                foreach (DataRow dr in dt.Rows)
                {
                    temp = StringSplit(dr["desc"].ToString());
                    foreach (DataRow dr_temp in temp.Rows)
                    {
                        dr_terms = dt_terms.NewRow();
                        dr_terms["id"] = dr[0]; // id from main table
                        dr_terms["term"] = dr_temp[0];
                        dt_terms.Rows.Add(dr_terms);
                    }
                    dgvTerms.DataSource = dt_terms;
                }
                
                */
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void splitIntoTermsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataTextData.DataSource;
            DataTable dt_terms = new DataTable();
            DataRow dr_terms;
            DataTable temp = new DataTable();
            dt_terms.Columns.Add("id");
            dt_terms.Columns.Add("term");

            foreach (DataRow dr in dt.Rows)
            {
                temp = StringSplit(dr["desc"].ToString());
                foreach (DataRow dr_temp in temp.Rows)
                {
                    dr_terms = dt_terms.NewRow();
                    dr_terms["id"] = dr[0]; // id from main table
                    dr_terms["term"] = dr_temp[0];
                    dt_terms.Rows.Add(dr_terms);
                }
                dgvTerms.DataSource = dt_terms;
            }

        }

        
    }
}
